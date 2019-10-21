using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            var questionPost1 = new QuestionPost
            {
                Content = "Content1"
            };
            var questionPost2 = new QuestionPost
            {
                Content = "Content2"
            };
            var questionPost3 = new QuestionPost
            {
                Content = "Content3"
            };
            return new List<Question>
            {
                new Question
                {
                    UserId = 1,
                    Title = "Question1",
                    QuestionPosts = new List<QuestionPost>
                    {
                        questionPost1
                    },
                    LatestQuestionPost = questionPost1
                },
                new Question
                {
                    UserId = 2,
                    Title = "Question2",
                    QuestionPosts = new List<QuestionPost>
                    {
                        questionPost2
                    },
                    LatestQuestionPost = questionPost2
                },
                new Question
                {
                    UserId = 3,
                    Title = "Question3",
                    QuestionPosts = new List<QuestionPost>
                    {
                        questionPost3
                    },
                    LatestQuestionPost = questionPost3
                }
            };
        }

        [Fact]
        public async Task Test_CreateAsync()
        {
            var options = RepositoryHelpers.BuildInMemoryDatabaseOptions("Base.CreateAsync");
            var newQuestion = GetQuestions().First();

            Question dbQuestion = null;
            using (var context = new TinRollContext(options))
            {
                var baseRepo = new BaseRepository<Question>(context);
                dbQuestion = await baseRepo.CreateAsync(newQuestion);
            }

            dbQuestion.Should().NotBeNull();
            dbQuestion.Id.Should().Be(1);
            dbQuestion.UserId.Should().Be(1);
            dbQuestion.QuestionPosts.Should().NotBeEmpty();
            dbQuestion.QuestionPosts.First().Id.Should().Be(1);
            using (var context = new TinRollContext(options))
            {
                var questionCount = await context.Questions.CountAsync();
                questionCount.Should().Be(1);

                var questionPostsCount = await context.QuestionPosts.CountAsync();
                questionPostsCount.Should().Be(1);
            }
        }

        [Fact]
        public async Task Test_GetAsyncById()
        {
            var options = RepositoryHelpers.BuildInMemoryDatabaseOptions("Base.GetAsyncById");
            var questions = GetQuestions();

            using (var context = new TinRollContext(options))
            {
                context.Questions.AddRange(questions);
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
            questionCount.Should().Be(3);
        }

        [Fact]
        public async Task Test_GetAsyncByIdInclude()
        {
            var options = RepositoryHelpers.BuildInMemoryDatabaseOptions("Base.GetAsyncByIdInclude");
            var questions = GetQuestions();

            using (var context = new TinRollContext(options))
            {
                context.Questions.AddRange(questions);
                context.SaveChanges();
            }

            Question dbQuestion = null;
            Expression<Func<Question, bool>> findById = (q) => q.Id == 2;
            using (var context = new TinRollContext(options))
            {
                var baseRepo = new BaseRepository<Question>(context);
                dbQuestion = await baseRepo.FindAsync(findById, "QuestionPosts");
            }

            dbQuestion.Should().NotBeNull();
            dbQuestion.LatestQuestionPost.Should().NotBeNull();
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

            IEnumerable<Question> dbQuestions = null;
            using (var context = new TinRollContext(options))
            {
                var baseRepo = new BaseRepository<Question>(context);
                dbQuestions = await baseRepo.GetAsync();
            }

            dbQuestions.Should().NotBeNull();
            dbQuestions.Count().Should().Be(3);
        }

        [Fact]
        public async Task Test_GetAsyncInclude()
        {
            var options = RepositoryHelpers.BuildInMemoryDatabaseOptions("Base.GetAsyncInclude");
            var questions = GetQuestions();

            using (var context = new TinRollContext(options))
            {
                context.Questions.AddRange(questions);
                context.SaveChanges();
            }

            IEnumerable<Question> dbQuestions = null;
            using (var context = new TinRollContext(options))
            {
                var baseRepo = new BaseRepository<Question>(context);
                dbQuestions = await baseRepo.GetAsync(includeProperties: "QuestionPosts");
            }

            dbQuestions.Should().NotBeNull();
            dbQuestions.Count().Should().Be(3);
            dbQuestions.All(dq => dq.QuestionPosts.Count == 1).Should().BeTrue();

        }
    }
}
