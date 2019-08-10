namespace TinRoll.Data.Repository

open TinRoll.Data

type IQuestionRepository =
    interface
        abstract member GetQuestionAsync : int -> Async<Question option>
        abstract member GetQuestionsAsync : unit -> Async<Question list>
        abstract member CreateQuestionAsync : Question -> int Async
    end


type QuestionRepository(context: TinRollContext) =
    interface IQuestionRepository with
        member this.GetQuestionAsync id =
            async {
                let question = context.Questions
                               |> Seq.tryFind (fun q -> q.Id = id)
                return question
            }
            
        member this.GetQuestionsAsync () =
            async {
                return context.Questions |> Seq.toList
            }

        member this.CreateQuestionAsync entity =
            async {
                context.Questions.Add(entity) |> ignore
                context.SaveChangesAsync()
                    |> Async.AwaitTask
                    |> Async.RunSynchronously
                    |> ignore
                return entity.Id
            }