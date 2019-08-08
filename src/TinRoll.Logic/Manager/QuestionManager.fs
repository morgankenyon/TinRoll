namespace TinRoll.Logic.Manager

open TinRoll.Shared
open TinRoll.Data.Repository
open TinRoll.Logic.Mapper


type IQuestionManager =
    interface
        abstract member GetQuestion : int -> QuestionDto
        abstract member GetQuestions : unit -> QuestionDto list
        abstract member CreateQuestion : QuestionDto -> QuestionDto
    end

type QuestionManager(questionRepo: IQuestionRepository) =
    interface IQuestionManager with
        member this.GetQuestion id =
            let dbQuestion = questionRepo.GetQuestion id
            QuestionMapper.ToDto dbQuestion
        member this.GetQuestions () =
            let dtoQuestions = questionRepo.GetQuestions ()
                               |> List.map QuestionMapper.ToDto
            dtoQuestions
        member this.CreateQuestion question =
            let dbQuestion = QuestionMapper.ToDb question
            let createdQuestion = questionRepo.CreateQuestion dbQuestion
            QuestionMapper.ToDto createdQuestion