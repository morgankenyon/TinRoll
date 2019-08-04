module RepositoryTests

open Microsoft.EntityFrameworkCore
open TinRoll.Data
open System
open System.Linq

let BuildInMemoryDatabase dbName =
    DbContextOptionsBuilder<TinRollContext>()
        .UseInMemoryDatabase(dbName)
        .Options

let GetTestUser () =
    {Id = 0; Email = "testEmail"; UserName = "userName"; Questions = new System.Collections.Generic.List<Question>(); CreatedDate = DateTime.Now; UpdatedDate = DateTime.Now}