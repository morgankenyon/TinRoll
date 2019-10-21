using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data.Entities;
using TinRoll.Data.Repositories.Interfaces;

namespace TinRoll.Data.Repositories
{
    public class CreateQuestionRepository : ICreateQuestionRepository
    {
        readonly TinRollContext context;

        public CreateQuestionRepository(TinRollContext context)
        {
            this.context = context;
        }

        public async Task<Question> CreateQuestionAsync(Question question, QuestionPost questionPost, IEnumerable<int> TagIds)
        {
            context.Questions.Add(question);

            foreach (var tagId in TagIds)
            {
                context.QuestionTags.Add(new QuestionTag()
                {
                    TagId = tagId,
                    Question = question,
                    UserId = question.UserId
                });
            }

            context.QuestionPosts.Add(questionPost);

            await context.SaveChangesAsync();

            return question;
        }
    }
}
