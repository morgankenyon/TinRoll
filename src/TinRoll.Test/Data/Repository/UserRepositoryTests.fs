module Data.Repository.UserRepositoryTests

open Xunit
open TinRoll.Data
open System
open TinRoll.Data.Repository
open NFluent


let GetIUserRepo dbName =
    let options = RepositoryTests.BuildInMemoryDatabase dbName
    let context = new TinRollContext(options)
    new UserRepository(context) :> IUserRepository


[<Fact>]
let ``Test Create User`` () =

    let user = RepositoryTests.GetTestUser()
    let userRepo = GetIUserRepo "Test_Create_User"
    let createdUserId = userRepo.CreateUserAsync(user)
                      |> Async.RunSynchronously

    Assert.Equal(1, createdUserId)
    
[<Fact>]
let ``Test Get User Success`` () =
    let userRepo = GetIUserRepo "Test_Get_User_Success"
    let user = RepositoryTests.GetTestUser()
    let createdUserId = 
        userRepo.CreateUserAsync user
        |> Async.RunSynchronously
                    
    
    
    let searchedUser = 
        userRepo.GetUserAsync createdUserId
        |> Async.RunSynchronously
    
    Assert.NotNull(searchedUser)
    Check.That(Option.isSome searchedUser) |> ignore
        
[<Fact>]
let ``Test Get User Fail`` () =
    let userRepo = GetIUserRepo "Test_Get_User_Fail"
        
        
    let searchedUser = 
        userRepo.GetUserAsync 1
        |> Async.RunSynchronously
        
    Check.That(Option.isNone searchedUser)