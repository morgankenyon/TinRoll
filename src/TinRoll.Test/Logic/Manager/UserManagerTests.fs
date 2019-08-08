module Logic.Manager.UserManagerTests

open Xunit
open NFluent
open TinRoll.Logic.Manager
open TinRoll.Data
open System
open Moq
open TinRoll.Data.Repository
open TinRoll.Shared
open System.Collections

let GetTestDbUser () =
    new User (1, "terst@gail.com", "TestUsername", new Generic.List<Question>(), DateTime.MinValue, DateTime.MinValue)
let GetTestDtoUser () =
    new UserDto (Id = 1, Email = "tesrst@gmail.com", Username = "Testusername", Questions = new Generic.List<QuestionDto>(), CreatedDate = DateTime.MinValue, UpdatedDate = DateTime.MinValue)

[<Fact>]
let ``Test Get Users`` () =
    let dbUsers = [GetTestDbUser()]
    let mock = Mock<IUserRepository>();
    mock.Setup(fun userRepo -> userRepo.GetUsers()).Returns(dbUsers) |> ignore

    let userManager = new UserManager(mock.Object) :> IUserManager
    let users = userManager.GetUsers()

    Check.That(users.Length).IsEqualTo(1) |> ignore
    Check.That(users.Head.Id).IsEqualTo(1) |> ignore

[<Fact>]
let ``Test Get User`` () =
    let dbUser = GetTestDbUser()

    let mock = Mock<IUserRepository>();
    mock.Setup(fun userRepo -> userRepo.GetUser(It.IsAny<int>())).Returns(dbUser) |> ignore

    let userManager = new UserManager(mock.Object) :> IUserManager
    let user = userManager.GetUser 1

    Check.That(user).IsNotNull() |> ignore
    Check.That(user.Id).IsEqualTo(1) |> ignore

[<Fact>]
let ``Test Create User`` () =
    let dbUser = GetTestDbUser()
    let dtoUser = GetTestDtoUser()

    let mock = Mock<IUserRepository>();
    mock.Setup(fun userRepo -> userRepo.CreateUser(It.IsAny<User>())).Returns(dbUser) |> ignore
    
    let userManager = new UserManager(mock.Object) :> IUserManager
    let createdDtoUser = userManager.CreateUser dtoUser
    
    Check.That(createdDtoUser).IsNotNull() |> ignore
    Check.That(createdDtoUser.Id).IsEqualTo(1) |> ignore