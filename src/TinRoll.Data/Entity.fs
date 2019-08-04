namespace TinRoll.Data

open System
open System.Collections.Generic


type [<CLIMutable>] Question = 
    {
        Id : int
        Title : string
        Text : string
        UserId : int
        User : User
        CreatedDate : DateTime
        UpdatedDate : DateTime
    }
and [<CLIMutable>] User =
    {
        Id : int
        Email : string
        UserName : string
        Questions : System.Collections.Generic.List<Question>
        CreatedDate : DateTime
        UpdatedDate : DateTime
    }