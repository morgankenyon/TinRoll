using System;
using Tinroll.Business.Mapping;
using Tinroll.Data.Entity;
using Tinroll.Model.Dto.Entity;
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
                QuestionId = Guid.NewGuid(),
                QuestionText = "This is the question",
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,    
            };

            //Act
            var questionDto = QuestionMapper.ToDto(questionEntity);

            //Assert
            Assert.Equal(questionEntity.QuestionId, questionDto.QuestionId);
            Assert.Equal(questionEntity.QuestionText, questionDto.QuestionText);
            Assert.Equal(questionEntity.CreatedDate, questionDto.CreatedDate);
            Assert.Equal(questionEntity.ModifiedDate, questionDto.ModifiedDate);
        }

        [Fact]
        public void MapQuestionToEntity()
        {
            //Arrange
            var questionDto = new QuestionDto()
            {
                QuestionId = Guid.NewGuid(),
                QuestionText = "This is the best thing every",
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,    
            };

            //Act
            var questionEntity = QuestionMapper.ToEntity(questionDto);

            //Assert
            Assert.Equal(questionDto.QuestionId, questionEntity.QuestionId);
            Assert.Equal(questionDto.QuestionText, questionEntity.QuestionText);
            Assert.Equal(questionDto.CreatedDate, questionEntity.CreatedDate);
            Assert.Equal(questionDto.ModifiedDate, questionEntity.ModifiedDate);
        }
    }
}