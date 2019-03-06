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
                User = user
            };

            //Act
            var answerDto = AnswerMapper.ToDto(answer);
            
            //Assert
            Assert.Equal(answer.AnswerId, answerDto.AnswerId);
            Assert.Equal(answer.AnswerText, answerDto.AnswerText);
            Assert.Equal(answer.CreatedDate, answerDto.CreatedDate);
            Assert.Equal(answer.ModifiedDate, answerDto.ModifiedDate);
            Assert.Equal(answer.User.UserId, answerDto.User.UserId);
            Assert.Equal(answer.Question.QuestionId, answerDto.Question.QuestionId);
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
                User = userDto
            };

            var answerDto = new AnswerDto
            {
                AnswerId = Guid.NewGuid(),
                AnswerText = "Answer text",
                CreatedDate = DateTime.Today,
                ModifiedDate = DateTime.Today,
                Question = questionDto,
                User = userDto
            };

            //Act
            var answer = AnswerMapper.ToEntity(answerDto);

            //Assert
            Assert.Equal(answerDto.AnswerId, answer.AnswerId);
            Assert.Equal(answerDto.AnswerText, answer.AnswerText);
            Assert.Equal(answerDto.CreatedDate, answer.CreatedDate);
            Assert.Equal(answerDto.ModifiedDate, answer.ModifiedDate);
            Assert.Equal(answerDto.User.UserId, answer.User.UserId);
            Assert.Equal(answerDto.Question.QuestionId, answer.Question.QuestionId);

        }

    }

}