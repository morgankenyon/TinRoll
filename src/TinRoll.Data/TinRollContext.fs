namespace TinRoll.Data

open Microsoft.EntityFrameworkCore
open Microsoft.EntityFrameworkCore.ChangeTracking
open System


type TinRollContext(options : DbContextOptions<TinRollContext>) =
    inherit DbContext(options)

    override x.SaveChangesAsync cancellationToken =
        let AddedQuestions = x.ChangeTracker.Entries<Question>() |> Seq.where (fun q -> q.State = EntityState.Added) |> Seq.toList //.Where(e => e.State == EntityState.Added).ToList()


                                
        base.SaveChangesAsync()

    override x.SaveChanges () =
        let AddedQuestions = x.ChangeTracker.Entries<Question>() |> Seq.where (fun q -> q.State = EntityState.Added) |> Seq.toList
        
        for addedQuestion in AddedQuestions do
            
            let mutable createdDate = addedQuestion.Property(fun q -> q.CreatedDate)
            createdDate.CurrentValue <- DateTime.UtcNow
            createdDate.IsModified <- true

            let mutable updatedDate = addedQuestion.Property(fun q -> q.UpdatedDate)
            updatedDate.CurrentValue <- DateTime.UtcNow
            updatedDate.IsModified <- true

        let UpdatedQuestions = x.ChangeTracker.Entries<Question>() |> Seq.where (fun q -> q.State = EntityState.Modified) |> Seq.toList

        for updatedQuestion in UpdatedQuestions do
            let mutable updatedDate = updatedQuestion.Property(fun q -> q.UpdatedDate)
            updatedDate.CurrentValue <- DateTime.UtcNow
            updatedDate.IsModified <- true
            

        base.SaveChanges()


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

