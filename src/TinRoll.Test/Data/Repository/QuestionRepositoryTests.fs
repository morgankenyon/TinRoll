module Data.Repository.QuestionRepositoryTests

open TinRoll.Data
open TinRoll.Data.Repository
open System
open Xunit

let GetIQuestionRepo dbName =
    let options = RepositoryTests.BuildInMemoryDatabase dbName
    let context = new TinRollContext(options)
    new QuestionRepository(context) :> IQuestionRepository


let GetTestQuestion () =
    new Question(0, "Test Title", "Test Text", 0, DateTime.Now, DateTime.Now)

[<Fact>]
let ``Test Create Question`` () =

    //let user = RepositoryTests.GetTestUser()
    let question = GetTestQuestion()
    let questionRepo = GetIQuestionRepo "Test_Create_Question"
    //let createdUser = userRepo.CreateUser(user)
    let createdQuestion = questionRepo.CreateQuestion(question)

    Assert.NotNull(createdQuestion)
    Assert.Equal(1, createdQuestion.Id)

[<Fact>]
let ``Test Get Question`` () =
    let question = GetTestQuestion()
    let questionRepo = GetIQuestionRepo "Test_Get_Question"
    let createdQuestion = questionRepo.CreateQuestion(question)

    let searchedQuestion = questionRepo.GetQuestion createdQuestion.Id

    Assert.NotNull(createdQuestion)
    Assert.Equal(1, searchedQuestion.Id)

[<Fact>]
let ``Test Get Questions`` () =
    let firstQuestion = GetTestQuestion()
    let secondQuestion = GetTestQuestion()
    let questionRepo = GetIQuestionRepo "Test_Get_Questions"
    questionRepo.CreateQuestion firstQuestion |> ignore
    questionRepo.CreateQuestion secondQuestion |> ignore

    let questions = questionRepo.GetQuestions()

    Assert.Equal(2, questions.Length)

[<Fact>]
let ``Test Get Question Fail`` () =
    let questionRepo = GetIQuestionRepo "Test_Get_Question_Fail"
    
    let searchedQuestion = questionRepo.GetQuestion 23

    Assert.Null(searchedQuestion)