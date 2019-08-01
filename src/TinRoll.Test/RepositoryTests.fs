module RepositoryTests

open Xunit
open Microsoft.EntityFrameworkCore
open TinRoll.Data

let BuildMemoryDatabase dbName =
    DbContextOptionsBuilder<TinRollContext>()
        .UseInMemoryDatabase(dbName)
        .Options


[<Fact>]
let ``My test`` () =
    Assert.True(true)

[<Fact>]
let ``Build In Memory Database`` () =
    let options = BuildMemoryDatabase "test"
    //let user = new User (Id = 1, Email = "testEmail", UserName = "userName")
    Assert.True(true)