using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using TinRoll.Data.Entities;
using TinRoll.Logic.Mappers;
using Xunit;

namespace TinRoll.Test.Logic.Mappers
{
    public class PostMapperTests
    {

        [Fact]
        public void Test_QuestionDbToDto()
        {
            var testDate = DateTime.UtcNow;

            var questionPost = new QuestionPost
            {
                Id = 1,
                Content = "This is the content",
                CreatedDate = testDate,
                UpdatedDate = testDate,
                QuestionId = 1,
                UserId = 1
            };

            var dto = questionPost.ToDto();

            dto.Content.Should().Be("This is the content");
        }

        [Fact]
        public void Test_AnswerDbToDto()
        {
            var testDate = DateTime.UtcNow;

            var answerPost = new AnswerPost
            {
                Id = 1,
                Content = "This is the content",
                CreatedDate = testDate,
                UpdatedDate = testDate,
                AnswerId = 1,
                UserId = 1
            };

            var dto = answerPost.ToDto();

            dto.Content.Should().Be("This is the content");
        }
    }
}
