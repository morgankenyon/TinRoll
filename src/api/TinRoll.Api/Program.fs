open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Http
open Giraffe
open Microsoft.Extensions.Logging
open Microsoft.EntityFrameworkCore
open TinRoll.Data
open FSharp.Control.Tasks


type Message =
    {
        Text : string
    }

let helloWorld =
    {Text = "Hello World"}

let questionsHandler =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        let context = ctx.RequestServices.GetService(typeof<TinRollContext>) :?> TinRollContext
        QuestionRepo.getAll context |> ctx.WriteJsonAsync

let addQuestionHandler = 
    fun (next : HttpFunc) (ctx : HttpContext) -> 
        task { 
            use context = ctx.RequestServices.GetService(typeof<TinRollContext>) :?> TinRollContext
            let! question = ctx.BindJsonAsync<Question>()
            return! QuestionRepo.addQuestionAsync context question
                    |> Async.RunSynchronously
                    |> function 
                    | Some l -> (setStatusCode 200 >=> json l) next ctx
                    | None -> (setStatusCode 400 >=> json "Label not added") next ctx
        }

let getQuestions =
    [
        { Id = 1; Title = "Question #1"; Content = "Can you help me figure this out?"; CreatedDate = DateTime.UtcNow.AddDays(-1.0)};
        { Id = 2; Title = "Question #2"; Content = "Can you help me figure this out?"; CreatedDate = DateTime.UtcNow.AddDays(-2.0)};
        { Id = 3; Title = "Question #3"; Content = "Can you help me figure this out?"; CreatedDate = DateTime.UtcNow.AddDays(-3.0)};
        { Id = 4; Title = "Question #4"; Content = "Can you help me figure this out?"; CreatedDate = DateTime.UtcNow.AddDays(-4.0)};
        { Id = 5; Title = "Question #5"; Content = "Can you help me figure this out?"; CreatedDate = DateTime.UtcNow.AddDays(-5.0)};
        { Id = 6; Title = "Question #6"; Content = "Can you help me figure this out?"; CreatedDate = DateTime.UtcNow.AddDays(-6.0)}
    ]
    
let webApp =
    choose [
        GET >=> choose [
                route "/hello"       >=> json helloWorld
                route "/questions" >=> questionsHandler ]
        POST >=> route "/questions" >=> addQuestionHandler
    ]

let configureApp (app : IApplicationBuilder) =
    // Add Giraffe to the ASP.NET Core pipeline
    app.UseGiraffe webApp

let configureServices (services : IServiceCollection) =
    // Add Giraffe dependencies
    services.AddDbContext<TinRollContext>
        (fun (options : DbContextOptionsBuilder) ->
            options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=TinRollDb;Trusted_Connection=True;MultipleActiveResultSets=true", fun f -> f.MigrationsAssembly("TinRoll.Migrations") |> ignore) |> ignore) |> ignore
    services.AddGiraffe() |> ignore

let configureLogging (builder : ILoggingBuilder) =
    let filter (l : LogLevel) = l.Equals LogLevel.Error
    builder.AddFilter(filter).AddConsole().AddDebug() |> ignore

let CreateWebHostBuilder(args: string[]) =
    WebHostBuilder()
        .UseKestrel()
        .Configure(Action<IApplicationBuilder> configureApp)
        .ConfigureServices(configureServices)
        .ConfigureLogging(configureLogging)

[<EntryPoint>]
let main args =
    CreateWebHostBuilder(args).Build().Run()
    0