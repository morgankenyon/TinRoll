using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data;
using TinRoll.Data.Entities;
using TinRoll.Data.Repository;
using Xunit;

namespace TinRoll.Test.Repository
{
    public class BaseRepositoryTests : RepositoryTest
    {
        [Fact]
        public async Task Test_Create_Question()
        {
            var options = BuildInMemoryDatabase("Create_Question");

            var newQuestion = new Question
            {
                Title = "Unit Test Question",
                UserId = 1,
                Text = "Question Text"
            };

            Question dbQuestion = null;
            using (var context = new TinRollContext(options))
            {
                var baseRepo = new BaseRepository<Question>(context);
                dbQuestion = await baseRepo.CreateAsync(newQuestion);
            }

            Assert.NotNull(dbQuestion);
            Assert.Equal(1, dbQuestion.Id);
            Assert.Equal(1, dbQuestion.UserId);
            using (var context = new TinRollContext(options))
            {
                var questionCount = await context.Questions.CountAsync();
                Assert.Equal(1, questionCount);
            }
        }

        [Fact]
        public async Task Test_Get_Question()
        {
            var options = BuildInMemoryDatabase("Get_Question");

            var questionToGet = new Question
            {
                Title = "Unit Test Question",
                UserId = 1,
                Text = "Question Text"
            };

            //create question to fetch
            using (var context = new TinRollContext(options))
            {
                context.Questions.Add(questionToGet);
                context.SaveChanges();
            }

            //test get question
            Question dbQuestion = null;
            using (var context = new TinRollContext(options))
            {
                var baseRepo = new BaseRepository<Question>(context);
                dbQuestion = await baseRepo.GetAsync(questionToGet.Id);
            }

            Assert.NotNull(dbQuestion);
            Assert.Equal(questionToGet.Id, dbQuestion.Id);
        }

        [Fact]
        public async Task Test_Get_Questions()
        {
            var options = BuildInMemoryDatabase("Get_Questions");

            var questionToGet = new Question
            {
                Title = "Unit Test Question",
                UserId = 1,
                Text = "Question Text"
            };

            var questionToGet2 = new Question
            {
                Title = "Uni Test Question 2",
                UserId = 1,
                Text = "Question Text 2"
            };

            //create questions to fetch
            using (var context = new TinRollContext(options))
            {
                context.Questions.Add(questionToGet);
                context.Questions.Add(questionToGet2);
                context.SaveChanges();
            }

            //test get questions
            IEnumerable<Question> dbQuestions = null;
            using (var context = new TinRollContext(options))
            {
                var baseRepo = new BaseRepository<Question>(context);
                dbQuestions = await baseRepo.GetAsync();
            }

            Assert.NotNull(dbQuestions);
            Assert.Equal(2, dbQuestions.Count());
        }
    }
}
