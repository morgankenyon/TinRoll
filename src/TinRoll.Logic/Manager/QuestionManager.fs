namespace TinRoll.Logic.Manager

open TinRoll.Shared
open TinRoll.Data.Repository
open TinRoll.Logic.Mapper
open System.Threading.Tasks


type IQuestionManager =
    interface
        abstract member GetQuestionAsync : int -> Task<QuestionDto>
        abstract member GetQuestionsAsync : unit -> Task<QuestionDto list>
        abstract member CreateQuestionAsync : QuestionDto -> int Task
    end

type QuestionManager(questionRepo: IQuestionRepository) =
    interface IQuestionManager with
        member this.GetQuestionAsync id =
            let asyncOp = async {
                let dbQuestion = questionRepo.GetQuestionAsync id
                                 |> Async.RunSynchronously
                return match dbQuestion with
                       | Some q -> QuestionMapper.ToDto q
                       | None -> Unchecked.defaultof<QuestionDto>
            }
            Async.StartAsTask(asyncOp)

        member this.GetQuestionsAsync () =
            let asyncOp = async {
                return questionRepo.GetQuestionsAsync ()
                |> Async.RunSynchronously
                |> List.map QuestionMapper.ToDto
            }
            Async.StartAsTask(asyncOp)

        member this.CreateQuestionAsync question =
            let dbQuestion = QuestionMapper.ToDb question
            let asyncOp = async {
                return questionRepo.CreateQuestionAsync dbQuestion
                       |> Async.RunSynchronously
            }
            Async.StartAsTask(asyncOp)
            //let dbQuestion = QuestionMapper.ToDb question
            //questionRepo.CreateQuestionAsync dbQuestion
            //    |> Async.RunSynchronously