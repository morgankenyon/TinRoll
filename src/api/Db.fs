module Db
    open System.Collections.Generic
    open Shared
    open FSharp.Control.Tasks
    open System.Data
    open Npgsql
    open Dapper.FSharp
    open Dapper.FSharp.PostgreSQL

    //let connStr = "Data Source=LAPTOP-M5JK4R1J;Initial Catalog=tinroll;Integrated Security=True"
    let connStr = "Host=localhost;Username=postgres;Password=password123;Database=tinroll"

    let personTable = table'<Person> "person" |> inSchema "public"

    let getUsers =
        task {
            use conn = new NpgsqlConnection(connStr) :> IDbConnection
            conn.Open()

            let! users = 
                select {
                    for p in personTable do
                    selectAll
                } |> conn.SelectAsync<Person>
            return users
        }

    let insertUser (newUser : NewPersonRequest) =
        task {
            use conn = new NpgsqlConnection(connStr) :> IDbConnection
            conn.Open()
            let person : Person = { id = 0; username = newUser.UserName; firstname = newUser.FirstName; lastname = newUser.LastName }

            let! insertedCount = 
                insert {
                    for p in personTable do
                    value person
                    excludeColumn p.id
                } |> conn.InsertAsync
            
            return insertedCount
        }

