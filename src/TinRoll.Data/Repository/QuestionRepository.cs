using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data.Entities;
using TinRoll.Data.Repository.Interface;

namespace TinRoll.Data.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly TinRollContext context;
        public QuestionRepository(TinRollContext context)
        {
            this.context = context;
        }

        public async Task<Question> CreateQuestionAsync(Question question)
        {
            await context.Questions.AddAsync(question);
            await context.SaveChangesAsync();
            return question;
        }

        public async Task<Question> GetQuestionAsync(int id)
        {
            return await context.Questions.FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<IEnumerable<Question>> GetQuestionsAsync()
        {
            return await context.Questions.ToListAsync();
        }
    }
}
