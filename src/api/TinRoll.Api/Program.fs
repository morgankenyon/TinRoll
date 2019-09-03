open System
open Microsoft.AspNetCore.Cors
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

let getQuestion (questionId : int) =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        let context = ctx.RequestServices.GetService(typeof<TinRollContext>) :?> TinRollContext
        match QuestionRepo.getQuestion context questionId with
        | Some q -> ctx.WriteJsonAsync q
        | None -> (setStatusCode 400 >=> json "Question not found") next ctx


let addQuestion = 
    fun (next : HttpFunc) (ctx : HttpContext) -> 
        task { 
            use context = ctx.RequestServices.GetService(typeof<TinRollContext>) :?> TinRollContext
            let! question = ctx.BindJsonAsync<Question>()
            return! QuestionRepo.addQuestionAsync context question
                    |> Async.RunSynchronously
                    |> function 
                    | Some l -> (setStatusCode 200 >=> json l) next ctx
                    | None -> (setStatusCode 400 >=> json "Question not added") next ctx
        }

let getAnswers =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        let context = ctx.RequestServices.GetService(typeof<TinRollContext>) :?> TinRollContext
        AnswerRepo.getAll context |> ctx.WriteJsonAsync
        
let addAnswer = 
    fun (next : HttpFunc) (ctx : HttpContext) -> 
        task { 
            use context = ctx.RequestServices.GetService(typeof<TinRollContext>) :?> TinRollContext
            let! answer = ctx.BindJsonAsync<Answer>()
            return! AnswerRepo.addAnswerAsync context answer
                    |> Async.RunSynchronously
                    |> function 
                    | Some l -> (setStatusCode 200 >=> json l) next ctx
                    | None -> (setStatusCode 400 >=> json "Question not added") next ctx
        }
    
    
let webApp =
    choose [
        GET >=> choose [
                route "/api/questions" >=> getQuestions
                routef "/api/questions/%i" getQuestion
                route "/api/answers" >=> getAnswers ]
        POST >=> choose [
                route "/api/questions" >=> addQuestion 
                route "/api/answers" >=> addAnswer ]
    ]

let configureCors (builder : CorsPolicyBuilder) =
    builder.WithOrigins("http://localhost:8080").AllowAnyMethod().AllowAnyHeader() |> ignore

let configureApp (app : IApplicationBuilder) =
    // Configure CORS
    app.UseCors(fun b -> configureCors(b)) |> ignore
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