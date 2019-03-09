using System;
using Tinroll.Business.Mapping;
using Tinroll.Data.Entity;
using Tinroll.Model.Dto.Entity;
using Xunit;

namespace Tinroll.Test.MappingTests
{
    public class AnswerMappingTest 
    {

        [Fact]
        public void MapAnswerToDto() 
        {
            //Arrange
            var user = new User {
                UserId = Guid.NewGuid(),
                UserName = "morganTest"
            };
            var question = new Question {
                QuestionId = Guid.NewGuid(),
                User = user
            };

            var answer = new Answer 
            {
                AnswerId = Guid.NewGuid(),
                AnswerText = "Answer text",
                CreatedDate = DateTime.Today,
                ModifiedDate = DateTime.Today,
                Question = question,
                QuestionId = Guid.NewGuid(),
                User = user,
                UserId = Guid.NewGuid(),
            };

            //Act
            var answerDto = AnswerMapper.ToDto(answer);
            
            //Assert
            Assert.Equal(answer.AnswerId, answerDto.AnswerId);
            Assert.Equal(answer.AnswerText, answerDto.AnswerText);
            Assert.Equal(answer.CreatedDate, answerDto.CreatedDate);
            Assert.Equal(answer.ModifiedDate, answerDto.ModifiedDate);
            Assert.Equal(answer.QuestionId, answerDto.QuestionId);
            Assert.Equal(answer.UserId, answerDto.UserId);
        }

        [Fact]
        public void MapAnswerToEntity()
        {
            //Arrange
            var userDto = new UserDto {
                UserId = Guid.NewGuid(),
                UserName = "morganTest"
            };
            var questionDto = new QuestionDto {
                QuestionId = Guid.NewGuid(),
            };

            var answerDto = new AnswerDto
            {
                AnswerId = Guid.NewGuid(),
                AnswerText = "Answer text",
                CreatedDate = DateTime.Today,
                ModifiedDate = DateTime.Today,
                QuestionId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
            };

            //Act
            var answer = AnswerMapper.ToEntity(answerDto);

            //Assert
            Assert.Equal(answerDto.AnswerId, answer.AnswerId);
            Assert.Equal(answerDto.AnswerText, answer.AnswerText);
            Assert.Equal(answerDto.CreatedDate, answer.CreatedDate);
            Assert.Equal(answerDto.ModifiedDate, answer.ModifiedDate);
            Assert.Equal(answerDto.QuestionId, answer.QuestionId);
            Assert.Equal(answerDto.UserId, answer.UserId);
        }

        [Fact]
        public void MapAnswerToEntityWithNull()
        {
            var answer = AnswerMapper.ToEntity(null);

            Assert.Null(answer);
        }

        [Fact]
        public void MapAnswerToDtoWithNull()
        {
            var answerDto = AnswerMapper.ToDto(null);

            Assert.Null(answerDto);
        }

    }

}