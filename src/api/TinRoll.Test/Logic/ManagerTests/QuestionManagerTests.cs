using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using TinRoll.Data.Entities;
using TinRoll.Data.Repositories.Interfaces;
using TinRoll.Logic.Managers;
using TinRoll.Shared.Dtos;
using Xunit;

namespace TinRoll.Test.Logic.ManagerTests
{
    public class QuestionManagerTests
    {
        [Fact]
        public async Task Test_Create_Question()
        {
            var mockQuestion = new Question
            {
                Id = 1
            };
            var mockTagIds = new List<int>() { 1, 2, 3 };

            var mockQuestionRepo = new Mock<IQuestionRepository>();
            var mockCreateQuestionRepo = new Mock<ICreateQuestionRepository>();

            mockCreateQuestionRepo.Setup(u => u.CreateQuestionAsync(It.IsAny<Question>(),  
                It.IsAny<IEnumerable<int>>())).ReturnsAsync(mockQuestion);

            var questionManager = new QuestionManager(mockQuestionRepo.Object,
                mockCreateQuestionRepo.Object);

            var questionToTest = new CreateQuestionDto()
            {
                Content = "stuff",
                TagIds = new List<int>() { 1, 2, 3 }
            };
            var createdQuestion = await questionManager.CreateQuestionAsync(questionToTest);

            createdQuestion.Should().NotBeNull();
            createdQuestion.Id.Should().Be(1);
            mockCreateQuestionRepo.Verify(u => u.CreateQuestionAsync(It.IsAny<Question>(),
                It.IsAny<IEnumerable<int>>()), Times.Once);
        }

        //[Fact]
        //public async Task Test_Get_Question()
        //{
        //    var mockQuestion = new Question
        //    {
        //        Id = 1
        //    };

        //    var mockQuestionRepo = new Mock<IQuestionRepository>();

        //    mockQuestionRepo.Setup(u => u.GetQuestionAsync(It.Is<int>(u => u == 1)))
        //        .ReturnsAsync(mockQuestion);

        //    var questionManager = new QuestionManager(mockQuestionRepo.Object);

        //    var question = await questionManager.GetQuestionAsync(1);

        //    Assert.NotNull(question);
        //    Assert.Equal(1, question.Id);
        //    mockQuestionRepo.Verify(u => u.GetQuestionAsync(It.Is<int>(u => u == 1)), Times.Once);
        //}

        //[Fact]
        //public async Task Test_Get_Questions()
        //{
        //    var mockQuestion1 = new Question
        //    {
        //        Id = 1
        //    };
        //    var mockQuestion2 = new Question
        //    {
        //        Id = 2
        //    };

        //    var mockQuestionList = new List<Question>() { mockQuestion1, mockQuestion2 };

        //    var mockQuestionRepo = new Mock<IQuestionRepository>();

        //    mockQuestionRepo.Setup(u => u.GetQuestionsAsync())
        //        .ReturnsAsync(mockQuestionList);

        //    var questionManager = new QuestionManager(mockQuestionRepo.Object);

        //    var questions = await questionManager.GetQuestionsAsync();

        //    Assert.NotNull(questions);
        //    Assert.Equal(2, questions.Count());

        //    var firstQuestion = questions.First();
        //    Assert.NotNull(firstQuestion);
        //    Assert.Equal(1, firstQuestion.Id);

        //    var secondQuestion = questions.Last();
        //    Assert.NotNull(secondQuestion);
        //    Assert.Equal(2, secondQuestion.Id);
        //}
    }
}
