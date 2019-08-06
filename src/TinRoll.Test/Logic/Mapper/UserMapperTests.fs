module Logic.Mapper.UserMapperTests

open Xunit
open TinRoll.Data
open TinRoll.Logic.Mapper
open System.Collections
open System
open NFluent
open TinRoll.Shared

[<Fact>]
let ``Test User Db to Dto`` () =
    let user = new User (1, "terst@gail.com", "TestUsername", new Generic.List<Question>(), DateTime.MinValue, DateTime.MinValue)
    let dto = UserMapper.ToDto(user)

    Check.That(dto.Id).Equals(user.Id) |> ignore
    Check.That(dto.Email).Equals(user.Email) |> ignore
    Check.That(dto.Username).Equals(user.Username) |> ignore    
    Check.That(dto.CreatedDate).Equals(user.CreatedDate) |> ignore
    Check.That(dto.UpdatedDate).Equals(user.UpdatedDate) |> ignore

[<Fact>]
let ``Test User Dto to Db`` () =
    let dto = new UserDto (Id = 1, Email = "tesrst@gmail.com", Username = "Testusername", Questions = new Generic.List<QuestionDto>(), CreatedDate = DateTime.MinValue, UpdatedDate = DateTime.MinValue)
    let db = UserMapper.ToDb(dto)

    Check.That(db).IsNotNull() |> ignore
    Check.That(db.Id).Equals(dto.Id) |> ignore
    Check.That(db.Email).Equals(dto.Email) |> ignore
    Check.That(db.Username).Equals(dto.Username) |> ignore
    Check.That(db.CreatedDate).Equals(dto.CreatedDate) |> ignore
    Check.That(db.UpdatedDate).Equals(dto.UpdatedDate) |> ignore