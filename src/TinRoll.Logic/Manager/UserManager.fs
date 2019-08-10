namespace TinRoll.Logic.Manager

open TinRoll.Shared
open TinRoll.Data.Repository
open TinRoll.Logic.Mapper
open System.Threading.Tasks

type IUserManager =
    interface
        abstract member GetUserAsync : int -> UserDto Task
        abstract member GetUsersAsync : unit -> UserDto list Task
        abstract member CreateUserAsync : UserDto -> int Task
    end

type UserManager(userRepo: IUserRepository) =
    interface IUserManager with
        member this.GetUserAsync id =
            let asyncOp = async {
                let dbUser = 
                    userRepo.GetUserAsync id
                    |> Async.RunSynchronously
                return match dbUser with 
                    | Some u -> UserMapper.ToDto u
                    | None -> Unchecked.defaultof<UserDto>
            }
            Async.StartAsTask(asyncOp)
        member this.GetUsersAsync () =
            let asyncOp = async {
                return userRepo.GetUsersAsync ()
                |> Async.RunSynchronously
                |> List.map UserMapper.ToDto
            }
            Async.StartAsTask(asyncOp)
        member this.CreateUserAsync user =
            let dbUser = UserMapper.ToDb user
            let asyncOp = async {
                return userRepo.CreateUserAsync dbUser
                       |> Async.RunSynchronously
            }
            Async.StartAsTask(asyncOp)
            