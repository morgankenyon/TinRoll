module Logic.Mapper.QuestionMapperTests

open Xunit
open TinRoll.Data
open System
open TinRoll.Logic.Mapper
open TinRoll.Shared
open NFluent

[<Fact>]
let ``Test Question db to dto`` () =
    let mutable db = new Question(1, "Title", "Text", 23, DateTime.MinValue, DateTime.MinValue)
    db.User <- new User()
    db.User.Id <- 23
    let dto = QuestionMapper.ToDto(db)

    Check.That(dto.Id).Equals(db.Id) |> ignore
    Check.That(dto.Title).Equals(db.Title) |> ignore
    Check.That(dto.Text).Equals(db.Text) |> ignore
    Check.That(dto.UserId).Equals(db.UserId) |> ignore
    //Check.That(dto.User.Id).Equals(db.User.Id) |> ignore
    Check.That(dto.CreatedDate).Equals(db.CreatedDate) |> ignore
    Check.That(dto.UpdatedDate).Equals(db.UpdatedDate) |> ignore

[<Fact>]
let ``Question Dto to Db`` () =
    let mutable dto = new QuestionDto(Id = 1, Title = "Title", Text = "Text", UserId = 24, CreatedDate = DateTime.MinValue, UpdatedDate = DateTime.MinValue)
    dto.User <- new UserDto()
    dto.User.Id <- 24
    let db = QuestionMapper.ToDb(dto)

    Check.That(db.Id).Equals(dto.Id) |> ignore
    Check.That(db.Title).Equals(dto.Title) |> ignore
    Check.That(db.Text).Equals(dto.Text) |> ignore
    Check.That(db.UserId).Equals(dto.UserId) |> ignore
    Check.That(db.CreatedDate).Equals(dto.CreatedDate) |> ignore
    Check.That(db.UpdatedDate).Equals(dto.UpdatedDate) |> ignore

