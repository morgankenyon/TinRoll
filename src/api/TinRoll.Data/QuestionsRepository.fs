namespace TinRoll.Data

module QuestionRepo =
    let getAll (context : TinRollContext) = context.Questions |> Seq.toList
    let getQuestion (context : TinRollContext) id = 
        context.Questions 
        |> Seq.tryFind (fun q -> q.Id = id)

    let addQuestionAsync (context : TinRollContext) (entity : Question) =
        async {
            context.Questions.AddAsync(entity)
            |> Async.AwaitTask
            |> ignore

            let! result = context.SaveChangesAsync true |> Async.AwaitTask
            let result = if result >= 1 then Some(entity) else None
            return result
        } 