namespace TinRoll.Data.Repository

open TinRoll.Data
open Microsoft.EntityFrameworkCore
open System.Linq

type IUserRepository =
    interface
        abstract member GetUserAsync : TinRollContext -> int -> User
        abstract member GetUsersAsync : TinRollContext -> User IQueryable
        abstract member CreateUserAsync : TinRollContext -> User -> Async<User>
    end
    

type UserRepository =
    interface IUserRepository with
        member this.GetUserAsync context id =
            query {
                for user in context.Users do
                    where (user.Id = id)
                    select user
                    exactlyOne
            }
        member this.GetUsersAsync context =
            //DbSet.toList context.Users
            query {
                for user in context.Users do 
                    select user
            }

        member this.CreateUserAsync context entity =
            async {
                context.Users.Add(entity) |> ignore
                let! _ = context.SaveChangesAsync true |> Async.AwaitTask
                return entity
            }
    //member GetUserAsync (context: TinRollContext) id =
    //    query {
    //        for user in context.Users do
    //            where (user.Id = id)
    //            select user
    //            exactlyOne
    //    } 

    //let GetUsersAsync (context: TinRollContext) =
    //    context.Users
         
    //let CreateUserAsync (context: TinRollContext) (entity: User) =
    //    async {
    //        context.Users.Add(entity) |> ignore
    //        let! _ = context.SaveChangesAsync true |> Async.AwaitTask
    //        return entity
    //    }
