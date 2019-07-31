namespace TinRoll.Data

open System


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
        Questions : Question list
        CreatedDate : DateTime
        UpdatedDate : DateTime
    }