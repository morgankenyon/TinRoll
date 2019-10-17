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
    public class AnswerMapperTests
    {
        [Fact]
        public void Test_Answer_To_AnswerDto()
        {
            var answer = new Answer
            {
                Id = 1,
                CreatedDate = DateTime.UtcNow,
                //Content = "This is content",
                UpdatedDate = DateTime.UtcNow,
                UserId = 10,
                QuestionId = 10
            };

            var answerDto = AnswerMapper.ToDto(answer);

            answerDto.Should().NotBeNull();
            answerDto.Id.Should().Be(answer.Id);
            answerDto.CreatedDate.Should().Be(answer.CreatedDate);
            //answerDto.Content.Should().Be(answer.Content);
            answerDto.UpdatedDate.Should().Be(answer.UpdatedDate);
            answerDto.UserId.Should().Be(answer.UserId);
            answerDto.QuestionId.Should().Be(answer.QuestionId);
        }

        [Fact]
        public void Test_NullDbToDto()
        {
            Answer answer = null;

            var answerDto = AnswerMapper.ToDto(answer);

            answerDto.Should().BeNull();
        }

        [Fact]
        public void Test_AnswerDto_To_Answer()
        {
            var answerDto = new AnswerDto
            {
                Id = 1,
                CreatedDate = DateTime.UtcNow,
                //Content = "This is content",
                UpdatedDate = DateTime.UtcNow,
                UserId = 10,
                QuestionId = 10
            };

            var answer = AnswerMapper.ToDb(answerDto);

            answer.Should().NotBeNull();
            answer.Id.Should().Be(answerDto.Id);
            answer.CreatedDate.Should().Be(answerDto.CreatedDate);
            //answer.Content.Should().Be(answerDto.Content);
            answer.UpdatedDate.Should().Be(answerDto.UpdatedDate);
            answer.UserId.Should().Be(answerDto.UserId);
            answer.QuestionId.Should().Be(answerDto.QuestionId);
            answer.User.Should().BeNull();
            answer.Question.Should().BeNull();

        }

        [Fact]
        public void Test_NullDtoToDb()
        {

            AnswerDto answerDto = null;

            var answer = AnswerMapper.ToDb(answerDto);

            answer.Should().BeNull();
        }
    }
}
