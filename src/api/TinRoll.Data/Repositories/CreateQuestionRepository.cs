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

        public async Task CreateQuestionAsync(Question question, IEnumerable<int> TagIds)
        {
            using (var transaction = await context.Database.BeginTransactionAsync())
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

                await context.SaveChangesAsync();
                transaction.Commit();
            }
        }
    }
}
