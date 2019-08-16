namespace TinRoll.Data.Repository

open TinRoll.Data

type IUserRepository =
    interface
        abstract member GetUserAsync : int -> User option Async
        abstract member GetUsersAsync : unit -> User list Async
        abstract member CreateUserAsync : User -> int Async
    end


type UserRepository(context: TinRollContext) =
    interface IUserRepository with
        member this.GetUserAsync id =
            async {
                return context.Users
                       |> Seq.tryFind (fun u -> u.Id = id)
            }

        member this.GetUsersAsync () =
            async {
                return context.Users |> Seq.toList
            }

        member this.CreateUserAsync entity =
            async {
                context.Users.Add(entity) |> ignore
                context.SaveChangesAsync()
                    |> Async.AwaitTask
                    |> Async.RunSynchronously
                    |> ignore
                return entity.Id
            }