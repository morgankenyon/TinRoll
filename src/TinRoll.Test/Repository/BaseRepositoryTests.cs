//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;
//using TinRoll.Data;
//using TinRoll.Data.Entities;
//using TinRoll.Data.Repository;
//using Xunit;

//namespace TinRoll.Test.Repository
//{
//    public class BaseRepositoryTests : RepositoryTest
//    {
//        [Fact]
//        public async Task Test_Create_Question()
//        {
//            var options = BuildInMemoryDatabase("Create_Question");

//            var newQuestion = new Question
//            {
//                Title = "Unit Test Question",
//                UserId = 1,
//                Text = "Question Text"
//            };

//            Question dbQuestion = null;
//            using (var context = new TinRollContext(options))
//            {
//                var baseRepo = new BaseRepository<Question>(context);
//                dbQuestion = await baseRepo.CreateAsync(newQuestion);
//            }

//            Assert.NotNull(dbQuestion);
//            Assert.Equal(1, dbQuestion.Id);
//            Assert.Equal(1, dbQuestion.UserId);
//            using (var context = new TinRollContext(options))
//            {
//                var questionCount = await context.Questions.CountAsync();
//                Assert.Equal(1, questionCount);
//            }
//        }

//        [Fact]
//        public async Task Test_Get_Question()
//        {
//            var options = BuildInMemoryDatabase("Get_Question");

//            var questionToGet = new Question
//            {
//                Title = "Unit Test Question",
//                UserId = 1,
//                Text = "Question Text"
//            };

//            //create question to fetch
//            using (var context = new TinRollContext(options))
//            {
//                context.Questions.Add(questionToGet);
//                context.SaveChanges();
//            }

//            //test get question
//            Question dbQuestion = null;
//            using (var context = new TinRollContext(options))
//            {
//                var baseRepo = new BaseRepository<Question>(context);
//                dbQuestion = await baseRepo.GetAsync(questionToGet.Id);
//            }

//            Assert.NotNull(dbQuestion);
//            Assert.Equal(questionToGet.Id, dbQuestion.Id);
//        }

//        [Fact]
//        public async Task Test_Get_Questions()
//        {
//            var options = BuildInMemoryDatabase("Get_Questions");

//            var questionToGet = new Question
//            {
//                Title = "Unit Test Question",
//                UserId = 1,
//                Text = "Question Text"
//            };

//            var questionToGet2 = new Question
//            {
//                Title = "Uni Test Question 2",
//                UserId = 1,
//                Text = "Question Text 2"
//            };

//            //create questions to fetch
//            using (var context = new TinRollContext(options))
//            {
//                context.Questions.Add(questionToGet);
//                context.Questions.Add(questionToGet2);
//                context.SaveChanges();
//            }

//            //test get questions
//            IEnumerable<Question> dbQuestions = null;
//            using (var context = new TinRollContext(options))
//            {
//                var baseRepo = new BaseRepository<Question>(context);
//                dbQuestions = await baseRepo.GetAsync();
//            }

//            Assert.NotNull(dbQuestions);
//            Assert.Equal(2, dbQuestions.Count());
//        }

//        [Fact]
//        public async Task Test_GetQuestions_OrderByIdDescending()
//        {
//            var options = BuildInMemoryDatabase("Get_Questions_OrderByIdDescending");

//            var questionOne = new Question();
//            var questionTwo = new Question();

//            using (var context = new TinRollContext(options))
//            {
//                context.Questions.Add(questionOne);
//                context.Questions.Add(questionTwo);
//                context.SaveChanges();
//            }

//            IEnumerable<Question> dbQuestions = null;
//            Func<IQueryable<Question>, IOrderedQueryable<Question>> orderByFunc = x =>
//                x.OrderByDescending(q => q.Id);
//            using (var context = new TinRollContext(options))
//            {
//                var baseRepo = new BaseRepository<Question>(context);
//                dbQuestions = await baseRepo.GetAsync(orderBy: orderByFunc);
//            }

//            Assert.NotNull(dbQuestions);
//            Assert.Equal(2, dbQuestions.Count());
//            Assert.Equal(2, dbQuestions.First().Id);
//            Assert.Equal(1, dbQuestions.Skip(1).First().Id);
//        }

//        [Fact]
//        public async Task Test_GetQuestion_FilterById()
//        {
//            var options = BuildInMemoryDatabase("Get_Questions_FilterById");

//            var questionList = new List<Question>()
//            {
//                new Question() { Id = 1 },
//                new Question() { Id = 2 },
//                new Question() { Id = 3 },
//                new Question() { Id = 4 },
//            };

//            using (var context = new TinRollContext(options))
//            {
//                context.Questions.AddRange(questionList);
//                context.SaveChanges();
//            }

//            IEnumerable<Question> dbQuestions = null;
//            Expression<Func<Question, bool>> filterById = x => x.Id > 2;
//            using (var context = new TinRollContext(options))
//            {
//                var baseRepo = new BaseRepository<Question>(context);
//                dbQuestions = await baseRepo.GetAsync(filter: filterById);
//            }

//            Assert.NotNull(dbQuestions);
//            Assert.Equal(2, dbQuestions.Count());
//            Assert.Equal(3, dbQuestions.First().Id);
//            Assert.Equal(4, dbQuestions.Skip(1).First().Id);
//        }

//        [Fact]
//        public async Task Test_GetQuestions_IncludeUser()
//        {
//            var options = BuildInMemoryDatabase("GetQuestions_IncludeUser");

//            var question = new Question()
//            {
//                User = new User()
//            };

//            using (var context = new TinRollContext(options))
//            {
//                context.Questions.Add(question);
//                context.SaveChanges();
//            }


//            IEnumerable<Question> dbQuestions = null;
//            using (var context = new TinRollContext(options))
//            {
//                var baseRepo = new BaseRepository<Question>(context);
//                dbQuestions = await baseRepo.GetAsync(includeProperties: "User");
//            }

//            Assert.NotNull(dbQuestions);
//            Assert.Single(dbQuestions);
//            var firstQuestion = dbQuestions.First();
//            Assert.NotNull(firstQuestion.User);
//            Assert.Equal(1, firstQuestion.User.Id);
//        }
//    }
//}
