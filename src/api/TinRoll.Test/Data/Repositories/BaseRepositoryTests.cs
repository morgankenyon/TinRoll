using System;
using System.Collections.Generic;
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
        [Fact]
        public async Task Test_CreateAsync()
        {
            var options = RepositoryHelpers.BuildInMemoryDatabaseOptions("Base.CreateAsync");
            var newQuestion = new Question
            {
                Title = "Unit Test Question",
                UserId = 1,
                Content = "Question Text"
            };

            Question dbQuestion = null;
            using (var context = new TinRollContext(options))
            {
                var baseRepo = new BaseRepository<Question>(context);
                dbQuestion = await baseRepo.CreateAsync(newQuestion);
            }

            dbQuestion.Should().NotBeNull();
            dbQuestion.Id.Should().Be(1);
            dbQuestion.UserId.Should().Be(1);// Do I need to create user a head of time
            using (var context = new TinRollContext(options))
            {
                var questionCount = await context.Questions.CountAsync();
                questionCount.Should().Be(1);
            }
        }
    }
}
