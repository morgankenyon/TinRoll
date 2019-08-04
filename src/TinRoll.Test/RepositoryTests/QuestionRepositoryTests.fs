module QuestionRepositoryTests

open TinRoll.Data
open TinRoll.Data.Repository
open System
open Xunit

let GetIQuestionRepo dbName =
    let options = RepositoryTests.BuildInMemoryDatabase dbName
    let context = new TinRollContext(options)
    new QuestionRepository(context) :> IQuestionRepository


let GetTestQuestion () =
    let user = RepositoryTests.GetTestUser()
    user.Id = 0
    {Id = 0; Title = "Test Title"; Text = "Test Text"; UserId = 0; User = user; CreatedDate = DateTime.Now; UpdatedDate = DateTime.Now}

[<Fact>]
let ``Test Create Question`` () =

    //let user = RepositoryTests.GetTestUser()
    let question = GetTestQuestion()
    let questionRepo = GetIQuestionRepo "Test_Create_Question"
    //let createdUser = userRepo.CreateUser(user)
    let createdQuestion = questionRepo.CreateQuestion(question)

    Assert.NotNull(createdQuestion)
    Assert.Equal(1, createdQuestion.Id)