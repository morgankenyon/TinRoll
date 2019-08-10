module Logic.Manager.QuestionManagerTests

open Xunit
open TinRoll.Data
open System
open Moq
open TinRoll.Data.Repository
open TinRoll.Logic.Manager
open NFluent
open TinRoll.Shared
open System.Threading.Tasks

let GetTestDbQuestion () =
    new Question(1, "Test Title", "Test Text", 1, DateTime.Now, DateTime.Now)
let GetTestDtoQuestion () =
    new QuestionDto(Id = 1, Title = "Title", Text = "Text", UserId = 24, CreatedDate = DateTime.MinValue, UpdatedDate = DateTime.MinValue)

[<Fact>] 
let ``Test Get Questions`` () =
    let dbQuestions = async { 
        return [GetTestDbQuestion()]
    }

    let mock = Mock<IQuestionRepository>()
    mock.Setup(fun qRepo -> qRepo.GetQuestionsAsync()).Returns(dbQuestions) |> ignore

    let questionManager = new QuestionManager(mock.Object) :> IQuestionManager
    let questions = questionManager.GetQuestionsAsync()
                    |> Async.AwaitTask
                    |> Async.RunSynchronously

    Check.That(questions.Length).IsEqualTo(1) |> ignore
    Check.That(questions.Head.Id).IsEqualTo(1) |> ignore

[<Fact>]
let ``Test Get Question`` () =
    let dbQuestion = async {
        return Some (GetTestDbQuestion())
    }

    let mock = new Mock<IQuestionRepository>()
    mock.Setup(fun qRepo -> qRepo.GetQuestionAsync(It.IsAny<int>())).Returns(dbQuestion) |> ignore
    
    let questionManager = new QuestionManager(mock.Object) :> IQuestionManager
    let question = questionManager.GetQuestionAsync 1
                   |> Async.AwaitTask
                   |> Async.RunSynchronously

    Check.That(question).IsNotNull() |> ignore
    Check.That(question.Id).IsEqualTo(1) |> ignore

[<Fact>]
let ``Test CreateQuestion`` () =
    let dbQuestion = GetTestDbQuestion()
    let dtoQuestion = GetTestDtoQuestion()

    let questionId = async {
        return 1
    }

    let mock = Mock<IQuestionRepository>()
    mock.Setup(fun qRepo -> qRepo.CreateQuestionAsync(It.IsAny<Question>())).Returns(questionId) |> ignore
    
    let questionManager = new QuestionManager(mock.Object) :> IQuestionManager
    let questionId = questionManager.CreateQuestionAsync dtoQuestion
                     |> Async.AwaitTask
                     |> Async.RunSynchronously

    Check.That(questionId).IsEqualTo(1) |> ignore