using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using TinRoll.Data.Entities;
using TinRoll.Logic.Mappers;
using TinRoll.Shared.Dtos;
using Xunit;

namespace TinRoll.Test.Logic.Mappers
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
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                UserId = 1,
                LatestQuestionPost = new QuestionPost
                {
                    Content = "Hello"
                }
            };

            var questionDto = QuestionMapper.ToDto(question);

            questionDto.Should().NotBeNull();
            questionDto.Id.Should().Be(question.Id);
            questionDto.Title.Should().Be(question.Title);
            questionDto.CreatedDate.Should().Be(question.CreatedDate);
            questionDto.UpdatedDate.Should().Be(question.UpdatedDate);
            questionDto.UserId.Should().Be(question.UserId);

            questionDto.PostDto.Should().NotBeNull();
            questionDto.PostDto.Content.Should().Be("Hello");
        }

        [Fact]
        public void Test_NullDbToDto()
        {
            Question question = null;

            var questionDto = QuestionMapper.ToDto(question);

            questionDto.Should().BeNull();
        }

        [Fact]
        public void Test_QuestionDto_To_Question()
        {
            var questionDto = new QuestionDto
            {
                Id = 1,
                Title = "Question Title",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                UserId = 1
            };

            var question = QuestionMapper.ToDb(questionDto);

            question.Should().NotBeNull();
            question.Id.Should().Be(questionDto.Id);
            question.Title.Should().Be(questionDto.Title);
            question.CreatedDate.Should().Be(questionDto.CreatedDate);
            question.UpdatedDate.Should().Be(questionDto.UpdatedDate);
            question.UserId.Should().Be(questionDto.UserId);
            question.User.Should().BeNull();
            question.QuestionTags.Should().BeNull();
        }

        [Fact]
        public void Test_NullDtoToDb()
        {
            QuestionDto qd = null;

            var q = QuestionMapper.ToDb(qd);

            q.Should().BeNull();
        }

        [Fact]
        public void Test_CreateQuestionDto_To_Question()
        {
            var cdto = new CreateQuestionDto()
            {
                Content = "thie",
                Title = "title",
                UserId = 23
            };

            var q = QuestionMapper.ToDb(cdto);

            q.Title.Should().Be(cdto.Title);
            q.UserId.Should().Be(cdto.UserId);

            q.Id.Should().Be(0);
            q.QuestionTags.Should().BeNull();
            q.UpdatedDate.Should().Be(DateTime.MinValue);
            q.CreatedDate.Should().Be(DateTime.MinValue);
            q.User.Should().BeNull();
            q.Answers.Should().BeNull();
            q.LatestQuestionPost.Should().NotBeNull();
            q.LatestQuestionPost.Content.Should().Be("thie");
        }

        [Fact]
        public void Test_NullCreateQuestionDtoToDb()
        {
            CreateQuestionDto cdto = null;

            var q = QuestionMapper.ToDb(cdto);

            q.Should().BeNull();
        }
    }
}
