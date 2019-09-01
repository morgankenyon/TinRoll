namespace TinRoll.Data

module AnswerRepo =
    let getAll (context : TinRollContext) = context.Answers |> Seq.toList

    let getQuestion (context : TinRollContext) id =
        context.Questions
        |> Seq.tryFind (fun a -> a.Id = id)

    let addAnswerAsync (context : TinRollContext) (entity : Answer) =
        async {
            context.Answers.AddAsync(entity)
            |> Async.AwaitTask
            |> ignore

            let! result = context.SaveChangesAsync true |> Async.AwaitTask
            let result = if result >= 1 then Some(entity) else None
            return result
        }

