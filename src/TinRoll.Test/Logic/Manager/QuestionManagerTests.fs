module Logic.Manager.QuestionManagerTests

open Xunit
open TinRoll.Data
open System
open Moq
open TinRoll.Data.Repository
open TinRoll.Logic.Manager
open NFluent
open TinRoll.Shared

let GetTestDbQuestion () =
    new Question(1, "Test Title", "Test Text", 1, DateTime.Now, DateTime.Now)
let GetTestDtoQuestion () =
    new QuestionDto(Id = 1, Title = "Title", Text = "Text", UserId = 24, CreatedDate = DateTime.MinValue, UpdatedDate = DateTime.MinValue)

[<Fact>] 
let ``Test Get Questions`` () =
    let dbQuestions = [GetTestDbQuestion()]

    let mock = Mock<IQuestionRepository>()
    mock.Setup(fun qRepo -> qRepo.GetQuestions()).Returns(dbQuestions) |> ignore

    let questionManager = new QuestionManager(mock.Object) :> IQuestionManager
    let questions = questionManager.GetQuestions()

    Check.That(questions.Length).IsEqualTo(1) |> ignore
    Check.That(questions.Head.Id).IsEqualTo(1) |> ignore

[<Fact>]
let ``Test Get Question`` () =
    let dbQuestion = GetTestDbQuestion()

    let mock = new Mock<IQuestionRepository>()
    mock.Setup(fun qRepo -> qRepo.GetQuestion(It.IsAny<int>())).Returns(dbQuestion) |> ignore
    
    let questionManager = new QuestionManager(mock.Object) :> IQuestionManager
    let question = questionManager.GetQuestion 1

    Check.That(question).IsNotNull() |> ignore
    Check.That(question.Id).IsEqualTo(1) |> ignore

[<Fact>]
let ``Test CreateQuestion`` () =
    let dbQuestion = GetTestDbQuestion()
    let dtoQuestion = GetTestDtoQuestion()

    let mock = Mock<IQuestionRepository>()
    mock.Setup(fun qRepo -> qRepo.CreateQuestion(It.IsAny<Question>())).Returns(dbQuestion) |> ignore
    
    let questionManager = new QuestionManager(mock.Object) :> IQuestionManager
    let question = questionManager.CreateQuestion dtoQuestion

    Check.That(question).IsNotNull() |> ignore
    Check.That(question.Id).IsEqualTo(1) |> ignore