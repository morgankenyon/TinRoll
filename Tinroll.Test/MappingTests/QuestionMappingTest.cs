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
                UserId = Guid.NewGuid()   
            };

            //Act
            var questionDto = QuestionMapper.ToDto(questionEntity);

            //Assert
            Assert.Equal(questionEntity.QuestionId, questionDto.QuestionId);
            Assert.Equal(questionEntity.QuestionText, questionDto.QuestionText);
            Assert.Equal(questionEntity.CreatedDate, questionDto.CreatedDate);
            Assert.Equal(questionEntity.ModifiedDate, questionDto.ModifiedDate);
            Assert.Equal(questionEntity.UserId, questionDto.UserId);
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
                UserId = Guid.NewGuid()
            };

            //Act
            var questionEntity = QuestionMapper.ToEntity(questionDto);

            //Assert
            Assert.Equal(questionDto.QuestionId, questionEntity.QuestionId);
            Assert.Equal(questionDto.QuestionText, questionEntity.QuestionText);
            Assert.Equal(questionDto.CreatedDate, questionEntity.CreatedDate);
            Assert.Equal(questionDto.ModifiedDate, questionEntity.ModifiedDate);
            Assert.Equal(questionDto.UserId, questionEntity.UserId);
        }

        [Fact]
        public void MapQuestionToEntityWithNull()
        {
            var question = QuestionMapper.ToEntity(null);

            Assert.Null(question);
        }

        [Fact]
        public void MapQuestionToDtoWithNull()
        {
            var questionDto = QuestionMapper.ToDto(null);

            Assert.Null(questionDto);
        }
    }
}