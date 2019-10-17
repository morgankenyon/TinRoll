using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using TinRoll.Data;
using TinRoll.Data.Entities;
using TinRoll.Data.Repositories;
using Xunit;

namespace TinRoll.Test.Data.Repositories
{
    public class CreateQuestionRepositoryTests
    {
        [Fact]
        public async Task Test_CreateQuestion()
        {
            var options = RepositoryHelpers.BuildInMemoryDatabaseOptions("CreateQuestionRepository");
            var newQuestion = new Question
            {
                Title = "Unit Test Question",
                UserId = 1,
                //Content = "Question Text"
            };
            var tag = new Tag
            {
                Name = "c#",
                UserId = 1
            };

            using (var context = new TinRollContext(options))
            {
                context.Tags.Add(tag);
                context.SaveChanges();
            }

            using (var context = new TinRollContext(options))
            {
                var createQuestionRepo = new CreateQuestionRepository(context);

                await createQuestionRepo.CreateQuestionAsync(newQuestion, new List<int>() { 1 });
            }

            var questions = new List<Question>();
            var questionTags = new List<QuestionTag>();
            using (var context = new TinRollContext(options))
            {
                questions = context.Questions.ToList();
                questionTags = context.QuestionTags.ToList();
            }

            questions.Should().HaveCount(1);
            questions.First().Id.Should().Be(1);
            //questions.First().Content.Should().Be("Question Text");

            questionTags.Should().HaveCount(1);
            questionTags.First().TagId.Should().Be(1);
            questionTags.First().QuestionId.Should().Be(questions.First().Id);
        }
    }
}
