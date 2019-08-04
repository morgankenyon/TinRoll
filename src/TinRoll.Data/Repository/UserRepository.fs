namespace TinRoll.Data.Repository

open TinRoll.Data

type IUserRepository =
    interface
        abstract member GetUser : int -> User
        abstract member GetUsers : unit -> User list
        abstract member CreateUser : User -> User
    end


type UserRepository(context: TinRollContext) =
    interface IUserRepository with
        member this.GetUser id =
            query {
                for user in context.Users do
                    where (user.Id = id)
                    select user
                    exactlyOneOrDefault
            }
        member this.GetUsers () =
            query {
                for user in context.Users do 
                    select user
            } |> Seq.toList

        member this.CreateUser entity =
            context.Users.Add(entity) |> ignore
            context.SaveChanges true |> ignore
            entity