module Shared
    open System

    type NewUserRequest = 
        { FirstName : string; LastName : string; Username : string; Password : string }

    type User = 
        { id : int; FirstName : string; LastName : string; Username : string; CreatedDate : DateTime; UpdateDate : DateTime }