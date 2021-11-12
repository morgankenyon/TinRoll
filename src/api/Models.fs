module Models
    open System
    
    type NewUser = 
        { FirstName : string; LastName : string; Username : string; Password: string }

    type DbUser =
        { Id: int; FirstName : string; LastName : string; Username : string; Salt: string; Hash: string; CreatedDate: DateTime; UpdatedDate: DateTime }

    type ErrorMsg = { Error : string }