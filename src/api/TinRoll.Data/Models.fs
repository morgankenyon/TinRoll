namespace TinRoll.Data
open System

[<CLIMutable>]
type Question =
    {
        Id : int        
        Title : string
        Content : string
        CreatedDate : DateTime
    }