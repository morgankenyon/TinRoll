open System
open FSharp.Control.Tasks
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection
open Giraffe

type Model =
    { Message : string }

type User = 
    { Id : Guid; FirstName : string; LastName : string; UserName : string }


let someHandler =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        task {
            let thisisaname = { Message = "hello from Giraffe" }
            return! ctx.WriteJsonAsync thisisaname
        }

let getUsersHandler =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        task {
            let user = { Id = Guid.NewGuid(); UserName = "morgankenyon"; FirstName = "Morgan"; LastName = "Kenyon" }
            let users = [user]
            return! ctx.WriteJsonAsync users            
        }

let usersRoutes = 
    choose [
        GET >=> 
            choose [
                route "" >=> getUsersHandler
            ]
    ]


let webApp =
    choose [
        subRoute "/users" usersRoutes
        route "/ping"   >=> text "pong"
        route "/message" >=> someHandler 
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