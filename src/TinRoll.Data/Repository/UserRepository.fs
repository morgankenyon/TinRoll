namespace TinRoll.Data.Repository

open TinRoll.Data

//type IUserRepository =
//    abstract member GetAsync : int -> User
//    abstract member CreateAsync : User -> User

module UserRepository =
    let getUserAsync (context: TinRollContext) id =
        query {
            for user in context.Users do
                where (user.Id = id)
                select user
                exactlyOne
        } |> (fun x -> if box x = null then None else Some x)

    let getUsersAsync (context: TinRollContext) =
        context.Users
            
