open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Giraffe

type Question =
    {
        Title : string
        Content : string
        CreatedDate : DateTime
    }
type Message =
    {
        Text : string
    }

let helloWorld =
    {Text = "Hello World"}

let getQuestions =
    [
        { Title = "Question #1"; Content = "Can you help me figure this out?"; CreatedDate = DateTime.UtcNow.AddDays(-1.0)};
        { Title = "Question #2"; Content = "Can you help me figure this out?"; CreatedDate = DateTime.UtcNow.AddDays(-2.0)};
        { Title = "Question #3"; Content = "Can you help me figure this out?"; CreatedDate = DateTime.UtcNow.AddDays(-3.0)};
        { Title = "Question #4"; Content = "Can you help me figure this out?"; CreatedDate = DateTime.UtcNow.AddDays(-4.0)};
        { Title = "Question #5"; Content = "Can you help me figure this out?"; CreatedDate = DateTime.UtcNow.AddDays(-5.0)};
        { Title = "Question #6"; Content = "Can you help me figure this out?"; CreatedDate = DateTime.UtcNow.AddDays(-6.0)}
    ]

// let questionsHandler = 
//     fun (next : HttpFunc) (ctx : HttpContext) ->
//         let context = ctx.RequestServices.GetService(tyoeof<LabelsContext>) :?> LabelsContext    
    
let webApp =
    choose [
        GET >=>
            choose [
                route "/hello"       >=> json helloWorld
                route "/questions" >=> json getQuestions
            ]
        // POST >=> 
        //     choose [
        //         route "/questions" >=> 
        //     ]        
    ]

let configureApp (app : IApplicationBuilder) =
    // Add Giraffe to the ASP.NET Core pipeline
    app.UseGiraffe webApp

let configureServices (services : IServiceCollection) =
    // Add Giraffe dependencies
    services.AddGiraffe() |> ignore

[<EntryPoint>]
let main _ =
    WebHostBuilder()
        .UseKestrel()
        .Configure(Action<IApplicationBuilder> configureApp)
        .ConfigureServices(configureServices)
        .Build()
        .Run()
    0