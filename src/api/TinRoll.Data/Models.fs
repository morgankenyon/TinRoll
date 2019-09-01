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
and [<CLIMutable>] Answer =
    {
        Id : int
        Content : string
        CreatedDate : DateTime
        QuestionId : int
        Question : Question
    }