namespace TinRoll.Logic.Manager

open TinRoll.Shared
open TinRoll.Data.Repository
open TinRoll.Logic.Mapper

type IUserManager =
    interface
        abstract member GetUser : int -> UserDto
        abstract member GetUsers : unit -> UserDto list
        abstract member CreateUser : UserDto -> UserDto
    end

type UserManager(userRepo: IUserRepository) =
    interface IUserManager with
        member this.GetUser id =
            let dbUser = userRepo.GetUser id
            UserMapper.ToDto dbUser
        member this.GetUsers () =
            let dtoUsers = userRepo.GetUsers ()
                          |> List.map UserMapper.ToDto
            dtoUsers
        member this.CreateUser user =
            let dbuser = UserMapper.ToDb user
            let createdUser = userRepo.CreateUser dbuser
            UserMapper.ToDto createdUser
            