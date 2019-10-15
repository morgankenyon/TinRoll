using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using TinRoll.Data.Entities;
using TinRoll.Data.Repositories.Interfaces;
using TinRoll.Logic.Managers;
using TinRoll.Shared.Dtos;
using Xunit;

namespace TinRoll.Test.Logic.ManagerTests
{
    public class AnswerManagerTests
    {

        [Fact]
        public async Task Test_Create_Answer()
        {
            var mockAnswer = new Answer
            {
                Id = 1
            };

            var mockAnswerRepo = new Mock<IAnswerRepository>();

            mockAnswerRepo.Setup(a => a.CreateAnswerAsync(It.IsAny<Answer>()))
                .ReturnsAsync(mockAnswer);

            var answerManager = new AnswerManager(mockAnswerRepo.Object);

            var answerToTest = new AnswerDto();

            var createdAnswer = await answerManager.CreateAnswerAsync(answerToTest);

            createdAnswer.Should().NotBeNull();
            createdAnswer.Id.Should().Be(1);
            mockAnswerRepo.Verify(u => u.CreateAnswerAsync(It.IsAny<Answer>()), Times.Once);
        }

        [Fact]
        public async Task Test_Get_Answer()
        {
            var mockAnswer = new Answer
            {
                Id = 1
            };

            var mockAnswerRepo = new Mock<IAnswerRepository>();

            mockAnswerRepo.Setup(a => a.GetAnswerAsync(It.IsAny<int>()))
                .ReturnsAsync(mockAnswer);

            var answerManager = new AnswerManager(mockAnswerRepo.Object);

            var answer = await answerManager.GetAnswerAsync(1);

            answer.Should().NotBeNull();
            answer.Id.Should().Be(1);
            mockAnswerRepo.Verify(u => u.GetAnswerAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task Test_Get_Answers()
        {
            var mockAnswers = new List<Answer>
            {
                new Answer
                {
                    Id = 1
                },
                new Answer
                {
                    Id = 2
                }
            };

            var mockAnswerRepo = new Mock<IAnswerRepository>();

            mockAnswerRepo.Setup(a => a.GetAnswersAsync())
                .ReturnsAsync(mockAnswers);

            var answerManager = new AnswerManager(mockAnswerRepo.Object);

            var answers = await answerManager.GetAnswersAsync();

            answers.Should().HaveCount(2);
            answers.First().Id.Should().Be(1);
            answers.Skip(1).First().Id.Should().Be(2);
            mockAnswerRepo.Verify(u => u.GetAnswersAsync(), Times.Once);
        }
    }
}
