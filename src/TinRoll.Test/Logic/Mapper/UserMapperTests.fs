module Logic.Mapper.UserMapperTests

open Xunit
open TinRoll.Data
open TinRoll.Logic.Mapper
open System.Collections
open System
open NFluent

[<Fact>]
let ``Test User Db to Dto`` () =
    let user = new User (1, "terst@gail.com", "TestUsername", new Generic.List<Question>(), DateTime.MinValue, DateTime.MinValue)
    let dto = UserMapper.ToDto(user)

    Check.That(dto.Id).Equals(user.Id) |> ignore
    Check.That(dto.Email).Equals(user.Email) |> ignore
    Check.That(dto.UserName).Equals(user.Username) |> ignore
    //Check.That(dto.Questions).Equals(user.Questions) |> ignore
    
    Check.That(dto.CreatedDate).Equals(user.CreatedDate) |> ignore
    Check.That(dto.UpdatedDate).Equals(user.UpdatedDate) |> ignore