open FSharp.Control.Tasks
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection
open Giraffe
open Shared
open Microsoft.Extensions.Logging
open Models

let getUsersHandler =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        task {
            let logger = ctx.GetService<ILogger<User>>()
            
            let! userResult = Db.getUsers logger

            return! 
                match userResult with
                | Ok users -> ctx.WriteJsonAsync users
                | Error errMsg -> ctx.WriteJsonAsync { Error = errMsg }
        }

let addUserHandler = 
    fun (next : HttpFunc) (ctx : HttpContext) ->
        task {
            let! newUserRequest = ctx.BindJsonAsync<NewUserRequest>()

            let newUser = Mapper.toNewUser newUserRequest

            let logger = ctx.GetService<ILogger<User>>();

            let! createUserResult = Db.insertUser logger newUser

            return
                match createUserResult with
                | Ok obj -> Successful.CREATED obj
                | Error errMsg -> setStatusCode 500
        }

let usersRoutes = 
    choose [
        GET >=> 
            choose [
                route "" >=> warbler (fun _ -> getUsersHandler)
            ]
        POST >=>
            choose [
                route "" >=> addUserHandler
            ]
    ]

let time() = System.DateTime.Now.ToString()

let webApp =
    choose [
        subRoute "/users" usersRoutes
        route "/ping"   >=> text "pong"
        route "/"       >=> text "root of project"
        route "/normal"  >=> text (time())
        route "/warbler" >=> warbler (fun _ -> text (time()))
    ]


let configureApp (app : IApplicationBuilder) =
    // Add Giraffe to the ASP.NET Core pipeline
    app.UseGiraffe webApp

let configureServices (services : IServiceCollection) =
    // Add Giraffe dependencies
    services.AddGiraffe() |> ignore
    services.AddLogging() |> ignore

let configureLogging (builder : ILoggingBuilder) =
    // Set a logging filter (optional)
    //let filter (l : LogLevel) = l.Equals LogLevel.Error

    // Configure the logging factory
    builder.ClearProviders()
           .AddConsole()      
           .AddDebug()        

           // Add additional loggers if wanted...
    |> ignore

[<EntryPoint>]
let main _ =
    Host.CreateDefaultBuilder()
        .ConfigureWebHostDefaults(
            fun webHostBuilder ->
                webHostBuilder
                    .Configure(configureApp)
                    .ConfigureServices(configureServices)
                    .ConfigureLogging(configureLogging)
                    |> ignore)
        .Build()
        .Run()
    0