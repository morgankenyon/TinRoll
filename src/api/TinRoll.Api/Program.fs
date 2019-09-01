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
open Microsoft.AspNetCore.Cors.Infrastructure



let getQuestions =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        let context = ctx.RequestServices.GetService(typeof<TinRollContext>) :?> TinRollContext
        QuestionRepo.getAll context |> ctx.WriteJsonAsync

let addQuestion = 
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
    
let webApp =
    choose [
        GET >=> choose [
                route "/api/questions" >=> getQuestions ]
        POST >=> route "/api/questions" >=> addQuestion
    ]

let configureCors (builder : CorsPolicyBuilder) =
    builder.WithOrigins("http://localhost:8080").AllowAnyMethod().AllowAnyHeader() |> ignore

let configureApp (app : IApplicationBuilder) =
    // Add Giraffe to the ASP.NET Core pipeline
    app.UseGiraffe webApp

let configureServices (services : IServiceCollection) =
    // Add Giraffe dependencies
    services.AddDbContext<TinRollContext>
        (fun (options : DbContextOptionsBuilder) ->
            options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=TinRollDb;Trusted_Connection=True;MultipleActiveResultSets=true", fun f -> f.MigrationsAssembly("TinRoll.Migrations") |> ignore) |> ignore) |> ignore
    services.AddCors() |> ignore
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