using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using TinRoll.Data.Entities;
using TinRoll.Data.Repositories.Interfaces;
using TinRoll.Logic.Managers;
using TinRoll.Shared.Dtos;
using Xunit;

namespace TinRoll.Test.Logic.Managers
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

            var mockQuestionRepo = new Mock<IBaseRepository<Question>>();
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

        [Fact]
        public async Task Test_Get_Question()
        {
            var mockQuestion = new Question
            {
                Id = 1
            };

            var mockQuestionRepo = new Mock<IBaseRepository<Question>>();
            var mockCreateQuestionRepo = new Mock<ICreateQuestionRepository>();

            mockQuestionRepo.Setup(u => u.GetAsync(It.Is<int>(p => p == 1), It.IsAny<string>()))
                .ReturnsAsync(mockQuestion);

            var questionManager = new QuestionManager(mockQuestionRepo.Object, mockCreateQuestionRepo.Object);

            var question = await questionManager.GetQuestionAsync(1);

            question.Should().NotBeNull();
            question.Id.Should().Be(1);
            mockQuestionRepo.Verify(u => u.GetAsync(It.Is<int>(p => p == 1), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task Test_Get_Questions()
        {
            var mockQuestions = new List<Question>
            {
                new Question
                {
                    Id = 1
                },
                new Question
                {
                    Id = 2
                }
            };

            var mockQuestionRepo = ManagerHelpers.MockRepoGetAsync(mockQuestions);
            var mockCreateQuestionRepo = new Mock<ICreateQuestionRepository>();

            var questionManager = new QuestionManager(mockQuestionRepo.Object, mockCreateQuestionRepo.Object);

            var questions = await questionManager.GetQuestionsAsync();
           
            questions.Should().HaveCount(2);
            questions.First().Id.Should().Be(1);
            questions.Skip(1).First().Id.Should().Be(2);
            ManagerHelpers.VerifyGetAsync(mockQuestionRepo, Times.Once());
        }
    }
}
