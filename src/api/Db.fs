module Db
    open Shared
    open System
    open FSharp.Control.Tasks
    open System.Data
    open Npgsql
    open Dapper.FSharp
    open Dapper.FSharp.PostgreSQL
    open Models
    open Microsoft.Extensions.Logging

    //let connStr = "Data Source=LAPTOP-M5JK4R1J;Initial Catalog=tinroll;Integrated Security=True"
    let connStr = "Host=localhost;Username=postgres;Password=password123;Database=tinroll"

    let usersTable = table'<DbUser> "users" |> inSchema "tin"

    let getUsers (logger : ILogger<User>) =
        task {
            use conn = new NpgsqlConnection(connStr) :> IDbConnection
            conn.Open()

            try 
                let! users = 
                    select {
                        for p in usersTable do
                        selectAll
                    } |> conn.SelectAsync<DbUser>
                return Ok users
            with ex ->
                logger.LogError("Encountered exception while fetching users", ex)
                return Error "Could not users"
        }

    let insertUser (logger: ILogger<User>) (newUser : NewUser) =
        task {
            use conn = new NpgsqlConnection(connStr) :> IDbConnection
            conn.Open()

            let date = DateTime.UtcNow;

            let person : DbUser = { 
                Id = 0; 
                Username = newUser.Username
                FirstName = newUser.FirstName
                LastName = newUser.LastName
                Salt = "salt" //actually salt and hash password
                Hash = "hash"
                CreatedDate = date
                UpdatedDate = date
            }

            try 
                let! insertedCount = 
                    insert {
                        for p in usersTable do
                        value person
                        excludeColumn p.Id
                    } |> conn.InsertOutputAsync<DbUser, DbUser> //need generic parameters here, not sure how to get this to work
                
                //update to return user without salt/hash informatio
                //also fetch id from inserted statement
                return Ok insertedCount
            with ex ->
                logger.LogError("Encountered exception while inserting user", ex);
                return Error "Could not create user"
        }

