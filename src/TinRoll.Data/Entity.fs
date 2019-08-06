namespace TinRoll.Data

open System
open System.Collections.Generic

type BaseEntity (createdDate: DateTime, updatedDate: DateTime) =
    let mutable _createdDate = createdDate
    let mutable _updatedDate = updatedDate
    

    member x.CreatedDate with get() = _createdDate and set v = _createdDate <- v
    member x.UpdatedDate with get() = _updatedDate and set v = _updatedDate <- v
    new() = BaseEntity(DateTime.MinValue, DateTime.MinValue)


type Question (id: int, title: string, text: string, userId: int, user: User, createdDate: DateTime, updatedDate: DateTime) =
    inherit BaseEntity(createdDate, updatedDate)
    let mutable _id = id
    let mutable _title = title
    let mutable _text = text
    let mutable _userId = userId
    let mutable _user = user
    
    member x.Id with get() = _id and set v = _id <- v
    member x.Title with get() = _title and set v = _title <- v
    member x.Text with get() = _text and set v = _text <- v
    member x.UserId with get() = _userId and set v = _userId <- v
    member x.User with get() = _user and set v = _user <- v
    new() = Question(0, "", "", 0, new User(), DateTime.MinValue, DateTime.MinValue)

and User (id: int, email: string, username: string, questions: IEnumerable<Question>, createdDate: DateTime, updatedDate: DateTime) =
    inherit BaseEntity(createdDate, updatedDate)
    let mutable _id = id
    let mutable _email = email
    let mutable _username = username
    let mutable _questions = questions

    member x.Id with get() = _id and set v = _id <- v
    member x.Email with get() = _email and set v = _email <- v
    member x.Username with get() = _username and set v = _username <- v
    member x.Questions with get() = _questions and set v = _questions <- v
    new() = User(0, "", "", new List<Question>(), DateTime.MinValue, DateTime.MinValue)