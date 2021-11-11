namespace Shared

type NewPersonRequest = 
    { FirstName : string; LastName : string; UserName : string }

type NewPerson = 
    { firstname : string; lastname : string; username : string }

type Person = 
    { id : int; firstname : string; lastname : string; username : string }