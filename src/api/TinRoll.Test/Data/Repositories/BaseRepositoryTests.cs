using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using TinRoll.Data;
using TinRoll.Data.Entities;
using TinRoll.Data.Repositories;
using Xunit;

namespace TinRoll.Test.Data.Repositories
{
    public class BaseRepositoryTests
    {

        private List<Question> GetQuestions()
        {
            return new List<Question>
            {
                new Question
                {
                    UserId = 1,
                    Title = "Question1",
                },
                new Question
                {
                    UserId = 2,
                    Title = "Question2",
                },
                new Question
                {
                    UserId = 3,
                    Title = "Question3",
                }
            };
        }

        [Fact]
        public async Task Test_CreateAsync()
        {
            var options = RepositoryHelpers.BuildInMemoryDatabaseOptions("Base.CreateAsync");
            var newQuestion = new Question
            {
                Title = "Unit Test Question",
                UserId = 1,
                //Content = "Question Text"
            };

            Question dbQuestion = null;
            using (var context = new TinRollContext(options))
            {
                var baseRepo = new BaseRepository<Question>(context);
                dbQuestion = await baseRepo.CreateAsync(newQuestion);
            }

            dbQuestion.Should().NotBeNull();
            dbQuestion.Id.Should().Be(1);
            dbQuestion.UserId.Should().Be(1);
            using (var context = new TinRollContext(options))
            {
                var questionCount = await context.Questions.CountAsync();
                questionCount.Should().Be(1);
            }
        }

        [Fact]
        public async Task Test_GetAsyncById()
        {
            var options = RepositoryHelpers.BuildInMemoryDatabaseOptions("Base.GetAsyncById");
            var questionOne = new Question
            {
                Title = "Question 1",
                UserId = 1,
                //Content = "Question One"
            };
            var questionTwo = new Question
            {
                Title = "Question 2",
                UserId = 2,
                //Content = "Question Two"
            };

            using (var context = new TinRollContext(options))
            {
                context.Questions.Add(questionOne);
                context.Questions.Add(questionTwo);
                context.SaveChanges();
            }

            Question dbQuestion = null;
            int questionCount = -1;
            using (var context = new TinRollContext(options))
            {
                var baseRepo = new BaseRepository<Question>(context);
                dbQuestion = await baseRepo.GetAsync(2);
                questionCount = context.Questions.Count();
            }

            dbQuestion.Should().NotBeNull();
            dbQuestion.Id.Should().Be(2);
            dbQuestion.UserId.Should().Be(2);
            questionCount.Should().Be(2);
        }

        [Fact]
        public async Task Test_GetAsync()
        {
            var options = RepositoryHelpers.BuildInMemoryDatabaseOptions("Base.GetAsync");
            var questions = GetQuestions();

            using (var context = new TinRollContext(options))
            {
                context.Questions.AddRange(questions);
                context.SaveChanges();
            }

            Question dbQuestion = null;
            using (var context = new TinRollContext(options))
            {
                var baseRepo = new BaseRepository<Question>(context);
                dbQuestion = await baseRepo.GetAsync(2);
            }

            dbQuestion.Should().NotBeNull();
            dbQuestion.Id.Should().Be(2);
        }
    }
}
