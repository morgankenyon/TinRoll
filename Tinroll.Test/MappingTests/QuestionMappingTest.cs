using Tinroll.Business.Mapping;
using Tinroll.Data.Entities;
using Tinroll.Model.Question;
using Xunit;

namespace Tinroll.Test.MappingTests
{
    public class QuestionMappingTest
    {
        
        [Fact]
        public void MapQuestionToDto()
        {
            //Arrange
            var questionEntity = new Question() 
            {
                QuestionId = 1,
                QuestionText = "This is the question"    
            };

            //Act
            var questionDto = QuestionMapper.ToDto(questionEntity);

            //Assert
            Assert.Equal(questionEntity.QuestionId, questionDto.QuestionId);
            Assert.Equal(questionEntity.QuestionText, questionDto.QuestionText);
        }

        [Fact]
        public void MapQuestionToEntity()
        {
            //Arrange
            var questionDto = new QuestionDto()
            {
                QuestionId = 234,
                QuestionText = "This is the best thing every"
            };

            //Act
            var questionEntity = QuestionMapper.ToEntity(questionDto);

            //Assert
            Assert.Equal(questionDto.QuestionId, questionEntity.QuestionId);
            Assert.Equal(questionDto.QuestionText, questionEntity.QuestionText);
        }
    }
}