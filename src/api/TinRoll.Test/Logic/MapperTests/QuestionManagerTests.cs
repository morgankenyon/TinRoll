using System;
using System.Collections.Generic;
using System.Text;
using TinRoll.Data.Entities;
using TinRoll.Logic.Mappers;
using TinRoll.Shared.Dtos;
using Xunit;

namespace TinRoll.Test.Logic.MapperTests
{
    public class QuestionMapperTests
    {
        [Fact]
        public void Test_Question_ToQuestionDto()
        {
            var question = new Question
            {
                Id = 1,
                Title = "Question Title",
                Content = "Question Text",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                UserId = 1
            };

            var questionDto = QuestionMapper.ToDto(question);

            Assert.NotNull(questionDto);
            Assert.Equal(question.Id, questionDto.Id);
            Assert.Equal(question.Title, questionDto.Title);
            Assert.Equal(question.Content, questionDto.Content);
            Assert.Equal(question.CreatedDate, questionDto.CreatedDate);
            Assert.Equal(question.UpdatedDate, questionDto.UpdatedDate);
            Assert.Equal(question.UserId, questionDto.UserId);
        }

        [Fact]
        public void Test_QuestionDto_To_Question()
        {
            var questionDto = new QuestionDto
            {
                Id = 1,
                Title = "Question Title",
                Content = "Question Text",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                UserId = 1
            };

            var question = QuestionMapper.ToDb(questionDto);

            Assert.NotNull(question);
            Assert.Equal(questionDto.Id, question.Id);
            Assert.Equal(questionDto.Title, question.Title);
            Assert.Equal(questionDto.Content, question.Content);
            Assert.Equal(questionDto.CreatedDate, question.CreatedDate);
            Assert.Equal(questionDto.UpdatedDate, question.UpdatedDate);
            Assert.Equal(questionDto.UserId, question.UserId);
        }
    }
}
