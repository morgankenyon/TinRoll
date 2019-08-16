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
    let dbUsers = async {
        return [GetTestDbUser()]
    }
    let mock = Mock<IUserRepository>();
    mock.Setup(fun ur -> ur.GetUsersAsync()).Returns(dbUsers) |> ignore

    let userManager = new UserManager(mock.Object) :> IUserManager
    let users = 
        userManager.GetUsersAsync()
        |> Async.AwaitTask
        |> Async.RunSynchronously


    Check.That(users.Length).IsEqualTo(1) |> ignore
    Check.That(users.Head.Id).IsEqualTo(1) |> ignore

[<Fact>]
let ``Test Get User`` () =
    let dbUser = async {
        return Some (GetTestDbUser())
    }

    let mock = Mock<IUserRepository>();
    mock.Setup(fun userRepo -> userRepo.GetUserAsync(It.IsAny<int>())).Returns(dbUser) |> ignore

    let userManager = new UserManager(mock.Object) :> IUserManager
    let user = 
        userManager.GetUserAsync 1
        |> Async.AwaitTask
        |> Async.RunSynchronously

    Check.That(user).IsNotNull() |> ignore
    Check.That(user.Id).IsEqualTo(1) |> ignore

[<Fact>]
let ``Test Create User`` () =
    let dtoUser = GetTestDtoUser()

    let userId = async {
        return 1
    }

    let mock = Mock<IUserRepository>();
    mock.Setup(fun userRepo -> userRepo.CreateUserAsync(It.IsAny<User>())).Returns(userId) |> ignore
    
    let userManager = new UserManager(mock.Object) :> IUserManager
    let userId = 
        userManager.CreateUserAsync dtoUser
        |> Async.AwaitTask
        |> Async.RunSynchronously
    
    Check.That(userId).IsEqualTo(1) |> ignore