open FSharp.Control.Tasks
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection
open Giraffe
open Db
open Shared

let getUsersHandler =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        task {
            let! users = getUsers
            return! ctx.WriteJsonAsync users
        }

let addUserHandler = 
    fun (next : HttpFunc) (ctx : HttpContext) ->
        task {
            let! newPerson = ctx.BindJsonAsync<NewPersonRequest>()
            let! createdUser = insertUser newPerson
            return! ctx.WriteJsonAsync createdUser
        }

let usersRoutes = 
    choose [
        GET >=> 
            choose [
                route "" >=> getUsersHandler
            ]
        POST >=>
            choose [
                route "" >=> addUserHandler
            ]
    ]


let webApp =
    choose [
        subRoute "/users" usersRoutes
        route "/ping"   >=> text "pong"
        route "/"       >=> text "root of project" 
    ]


let configureApp (app : IApplicationBuilder) =
    // Add Giraffe to the ASP.NET Core pipeline
    app.UseGiraffe webApp

let configureServices (services : IServiceCollection) =
    // Add Giraffe dependencies
    services.AddGiraffe() |> ignore

[<EntryPoint>]
let main _ =
    Host.CreateDefaultBuilder()
        .ConfigureWebHostDefaults(
            fun webHostBuilder ->
                webHostBuilder
                    .Configure(configureApp)
                    .ConfigureServices(configureServices)
                    |> ignore)
        .Build()
        .Run()
    0