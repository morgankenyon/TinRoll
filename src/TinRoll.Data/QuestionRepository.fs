namespace TinRoll.Data.Repository

open TinRoll.Data

type IQuestionRepository =
    interface
        abstract member GetQuestion : int -> Question
        abstract member GetQuestions : unit -> Question list
        abstract member CreateQuestion : Question -> Question
    end


type QuestionRepository(context: TinRollContext) =
    interface IQuestionRepository with
        member this.GetQuestion id =
            query {
                for question in context.Questions do
                    where (question.Id = id)
                    select question
                    exactlyOne
            }
        member this.GetQuestions () =
            query {
                for question in context.Questions do 
                    select question
            } |> Seq.toList

        member this.CreateQuestion entity =
            context.Questions.Add(entity) |> ignore
            context.SaveChanges true |> ignore
            entity