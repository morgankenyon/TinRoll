module Data.Repository.UserRepositoryTests

open Xunit
open TinRoll.Data
open System
open TinRoll.Data.Repository


let GetIUserRepo dbName =
    let options = RepositoryTests.BuildInMemoryDatabase dbName
    let context = new TinRollContext(options)
    new UserRepository(context) :> IUserRepository


[<Fact>]
let ``Test Create User`` () =

    let user = RepositoryTests.GetTestUser()
    let userRepo = GetIUserRepo "Test_Create_User"
    let createdUser = userRepo.CreateUser(user)

    Assert.NotNull(createdUser)
    Assert.Equal(1, createdUser.Id)
    
[<Fact>]
let ``Test Get User Success`` () =
    let userRepo = GetIUserRepo "Test_Get_User_Success"
    let user = RepositoryTests.GetTestUser()
    let createdUser = userRepo.CreateUser user
    
    
    let searchedUser = userRepo.GetUser createdUser.Id
    
    Assert.NotNull(searchedUser)
    Assert.Equal(1, searchedUser.Id)
        
[<Fact>]
let ``Test Get User Fail`` () =
    let userRepo = GetIUserRepo "Test_Get_User_Fail"
        
        
    let searchedUser = userRepo.GetUser 1
        
    Assert.Null(searchedUser) ///needs to return an option type at some point