module Data.Repository.QuestionRepositoryTests

open TinRoll.Data
open TinRoll.Data.Repository
open System
open Xunit
open NFluent

let GetIQuestionRepo dbName =
    let options = RepositoryTests.BuildInMemoryDatabase dbName
    let context = new TinRollContext(options)
    new QuestionRepository(context) :> IQuestionRepository


let GetTestQuestion () =
    new Question(0, "Test Title", "Test Text", 0, DateTime.Now, DateTime.Now)

[<Fact>]
let ``Test Create Question`` () =

    let question = GetTestQuestion()
    let questionRepo = GetIQuestionRepo "Test_Create_Question"
    let createdQuestionId = Async.RunSynchronously (questionRepo.CreateQuestionAsync(question))

    Assert.NotNull(1, createdQuestionId)

[<Fact>]
let ``Test Get Question`` () =
    let question = GetTestQuestion()
    let questionRepo = GetIQuestionRepo "Test_Get_Question"
    let createdQuestionId = Async.RunSynchronously (questionRepo.CreateQuestionAsync(question))

    let searchedQuestion = Async.RunSynchronously (questionRepo.GetQuestionAsync createdQuestionId)

    Check.That(Option.isSome searchedQuestion) |> ignore

[<Fact>]
let ``Test Get Questions`` () =
    let firstQuestion = GetTestQuestion()
    let secondQuestion = GetTestQuestion()
    let questionRepo = GetIQuestionRepo "Test_Get_Questions"

    Async.RunSynchronously(questionRepo.CreateQuestionAsync firstQuestion) |> ignore
    Async.RunSynchronously(questionRepo.CreateQuestionAsync secondQuestion) |> ignore

    let questions = Async.RunSynchronously(questionRepo.GetQuestionsAsync())

    Assert.Equal(2, questions.Length)

[<Fact>]
let ``Test Get Question Fail`` () =
    let questionRepo = GetIQuestionRepo "Test_Get_Question_Fail"
    
    let searchedQuestion = Async.RunSynchronously(questionRepo.GetQuestionAsync 23)

    Check.That(Option.isNone searchedQuestion) |> ignore