using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data.Entities;
using TinRoll.Data.Repository.Interface;
using TinRoll.Logic.Manager;
using TinRoll.Shared;
using Xunit;

namespace TinRoll.Test.Manager
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

            var mockQuestionRepo = new Mock<IQuestionRepository>();

            mockQuestionRepo.Setup(u => u.CreateQuestionAsync(It.IsAny<Question>()))
                .ReturnsAsync(mockQuestion);

            var questionManager = new QuestionManager(mockQuestionRepo.Object);

            var questionToTest = new QuestionDto();
            var createdQuestion = await questionManager.CreateQuestionAsync(questionToTest);

            Assert.NotNull(createdQuestion);
            Assert.Equal(1, createdQuestion.Id);
            mockQuestionRepo.Verify(u => u.CreateQuestionAsync(It.IsAny<Question>()), Times.Once);
        }

        [Fact]
        public async Task Test_Get_Question()
        {
            var mockQuestion = new Question
            {
                Id = 1
            };

            var mockQuestionRepo = new Mock<IQuestionRepository>();

            mockQuestionRepo.Setup(u => u.GetQuestionAsync(It.Is<int>(u => u == 1)))
                .ReturnsAsync(mockQuestion);

            var questionManager = new QuestionManager(mockQuestionRepo.Object);

            var question = await questionManager.GetQuestionAsync(1);

            Assert.NotNull(question);
            Assert.Equal(1, question.Id);
            mockQuestionRepo.Verify(u => u.GetQuestionAsync(It.Is<int>(u => u == 1)), Times.Once);
        }

        [Fact]
        public async Task Test_Get_Questions()
        {
            var mockQuestion1 = new Question
            {
                Id = 1
            };
            var mockQuestion2 = new Question
            {
                Id = 2
            };

            var mockQuestionList = new List<Question>() { mockQuestion1, mockQuestion2 };

            var mockQuestionRepo = new Mock<IQuestionRepository>();

            mockQuestionRepo.Setup(u => u.GetQuestionsAsync())
                .ReturnsAsync(mockQuestionList);

            var questionManager = new QuestionManager(mockQuestionRepo.Object);

            var questions = await questionManager.GetQuestionsAsync();

            Assert.NotNull(questions);
            Assert.Equal(2, questions.Count());

            var firstQuestion = questions.First();
            Assert.NotNull(firstQuestion);
            Assert.Equal(1, firstQuestion.Id);

            var secondQuestion = questions.Last();
            Assert.NotNull(secondQuestion);
            Assert.Equal(2, secondQuestion.Id);
        }
    }
}
