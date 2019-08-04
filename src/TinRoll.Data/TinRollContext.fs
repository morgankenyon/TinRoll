namespace TinRoll.Data

open Microsoft.EntityFrameworkCore
open Microsoft.EntityFrameworkCore.ChangeTracking
open System


type TinRollContext(options : DbContextOptions<TinRollContext>) =
    inherit DbContext(options)

//    override SaveChangesAsync(Cancellation)
    //override __.SaveChangesAsync CancellationToken
    override x.SaveChangesAsync cancellationToken =
        let AddedQuestions = x.ChangeTracker.Entries<Question>() |> Seq.where (fun q -> q.State = EntityState.Added) |> Seq.toList //.Where(e => e.State == EntityState.Added).ToList()


                                
        base.SaveChangesAsync()

    override x.SaveChanges () =
        let AddedQuestions = x.ChangeTracker.Entries<Question>() |> Seq.where (fun q -> q.State = EntityState.Added) |> Seq.toList //.Where(e => e.State == EntityState.Added).ToList()
                    
        for addedQuestion in AddedQuestions do
            let createdDateProperty = addedQuestion.Property(Question.CreatedDate)
            createdDateProperty.CurrentValue = DateTime.UtcNow
            createdDateProperty.IsModified = true

            addedQuestion.Property(p.CreatedDate).CurrentValue = DateTime.UtcNow

        base.SaveChanges()

    //override x.SaveChanges acceptAllChangesOnSuccess =
    //    let AddedQuestions = x.ChangeTracker.Entries<Question>() |> Seq.where (fun q -> q.State = EntityState.Added) |> Seq.toList //.Where(e => e.State == EntityState.Added).ToList()
                    
    //    base.SaveChanges acceptAllChangesOnSuccess


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

