namespace TinRoll.Data

open Microsoft.EntityFrameworkCore


type TinRollContext(options : DbContextOptions<TinRollContext>) =
    inherit DbContext(options)

    [<DefaultValue>]
    val mutable questions : DbSet<Question>
    member x.Questions
        with get() = x.questions
        and set v = x.questions <- v

    [<DefaultValue>]
    val mutable users : DbSet<User>
    member x.Users
        with get() = x.users
        and set v = x.users <- v

