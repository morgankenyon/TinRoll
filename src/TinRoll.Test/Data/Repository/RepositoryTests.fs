module Data.Repository.RepositoryTests

open Microsoft.EntityFrameworkCore
open TinRoll.Data
open System
open System.Collections

let BuildInMemoryDatabase dbName =
    DbContextOptionsBuilder<TinRollContext>()
        .UseInMemoryDatabase(dbName)
        .Options

let GetTestUser () =
    new User(0, "testEmail", "userName", new Generic.List<Question>(), DateTime.Now, DateTime.Now)