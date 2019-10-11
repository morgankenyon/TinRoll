using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
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

            questionDto.Should().NotBeNull();
            questionDto.Id.Should().Be(question.Id);
            questionDto.Title.Should().Be(question.Title);
            questionDto.Content.Should().Be(question.Content);
            questionDto.CreatedDate.Should().Be(question.CreatedDate);
            questionDto.UpdatedDate.Should().Be(question.UpdatedDate);
            questionDto.UserId.Should().Be(question.UserId);
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

            question.Should().NotBeNull();
            question.Id.Should().Be(questionDto.Id);
            question.Title.Should().Be(questionDto.Title);
            question.Content.Should().Be(questionDto.Content);
            question.CreatedDate.Should().Be(questionDto.CreatedDate);
            question.UpdatedDate.Should().Be(questionDto.UpdatedDate);
            question.UserId.Should().Be(questionDto.UserId);
            question.User.Should().BeNull();
            question.QuestionTags.Should().BeNull();
        }
    }
}
