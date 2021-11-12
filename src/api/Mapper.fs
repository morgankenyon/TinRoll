module Mapper
    open Models
    open Shared

    let toNewUser (newUser: NewUserRequest) : NewUser =
        { FirstName = newUser.FirstName; LastName = newUser.LastName; Username = newUser.Username; Password = newUser.Password }