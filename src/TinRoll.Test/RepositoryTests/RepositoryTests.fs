module RepositoryTests

open Microsoft.EntityFrameworkCore
open TinRoll.Data
open System

let BuildInMemoryDatabase dbName =
    DbContextOptionsBuilder<TinRollContext>()
        .UseInMemoryDatabase(dbName)
        .Options

let GetTestUser () =
    {Id = 0; Email = "testEmail"; UserName = "userName"; Questions = List.empty<Question>; CreatedDate = DateTime.Now; UpdatedDate = DateTime.Now}