using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Tinroll.Business.Managers;
using Tinroll.Business.Managers.Interfaces;
using Tinroll.Business.Mapping;
using Tinroll.Data.Entities;
using Tinroll.Data.Repositories.Interfaces;
using Tinroll.Model.Question;
using Xunit;

namespace Tinroll.Test.MappingTests
{
    public class QuestionManagerTest
    {
        
        [Fact]
        public async Task GetAllQuestionsTest()
        {
            //Arrange
            IEnumerable<Question> questions = new List<Question>() 
            {
                new Question() 
                {
                    QuestionId = 1,
                    QuestionText = "This is the question"    
                },
                new Question()
                {
                    QuestionId = 2,
                    QuestionText = "This is the question 2"
                }
            };

            var mockRepo = new Mock<IQuestionRepository>();

            mockRepo.Setup(m => m.GetAllQuestionsAsync())
                .Returns(Task.FromResult(questions));

            var questionManager = new QuestionManager(mockRepo.Object);

            //Act
            var questionDtos = await questionManager.GetAllQuestionsAsync();

            //Assert
            Assert.Equal(2, questionDtos.Count());
            Assert.Equal(1, questionDtos.First().QuestionId);
            Assert.Equal(2, questionDtos.Last().QuestionId);
        }
    }
}