using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data;
using TinRoll.Data.Entities;
using TinRoll.Data.Repository;
using TinRoll.Data.Repository.Interface;
using Xunit;

namespace TinRoll.Test.Repository
{
    public class QuestionRepositoryTests : RepositoryTest
    {

        [Fact]
        public async Task Test_Create_Question()
        {

            var newQuestion = new Question
            {
                Id = 1,
                Title = "Unit Test Question",
                UserId = 1,
                Text = "Question Text"
            };

            var mockBaseRepo = new Mock<IBaseRepository<Question>>();

            mockBaseRepo.Setup(m => m.CreateAsync(It.IsAny<Question>()))
                .ReturnsAsync(newQuestion);

            var questionRepo = new QuestionRepository(mockBaseRepo.Object);
            var dbQuestion = await questionRepo.CreateQuestionAsync(newQuestion);

            Assert.NotNull(dbQuestion);
            Assert.Equal(1, dbQuestion.Id);
        }

        [Fact]
        public async Task Test_Get_Question()
        {

            var questionToGet = new Question
            {
                Title = "Unit Test Question",
                UserId = 1,
                Text = "Question Text"
            };

            var mockBaseRepo = new Mock<IBaseRepository<Question>>();

            mockBaseRepo.Setup(m => m.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(questionToGet);

            
            var questionRepo = new QuestionRepository(mockBaseRepo.Object);
            var dbQuestion = await questionRepo.GetQuestionAsync(questionToGet.Id);

            Assert.NotNull(dbQuestion);
            Assert.Equal(questionToGet.Id, dbQuestion.Id);
        }

        [Fact]
        public async Task Test_Get_Questions()
        {
            var questionToGet = new Question
            {
                Title = "Unit Test Question",
                UserId = 1,
                Text = "Question Text"
            };

            var questionToGet2 = new Question
            {
                Title = "Uni Test Question 2",
                UserId = 1,
                Text = "Question Text 2"
            };
            var questions = new List<Question>() { questionToGet, questionToGet2 };

            var mockBaseRepo = new Mock<IBaseRepository<Question>>();

            mockBaseRepo.Setup(m => m.GetAsync(null, null, null))
                .ReturnsAsync(questions);

            var questionRepo = new QuestionRepository(mockBaseRepo.Object);
            var dbQuestions = await questionRepo.GetQuestionsAsync();
            
            Assert.NotNull(dbQuestions);
            Assert.Equal(2, dbQuestions.Count());
        }
    }
}
