using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Tinroll.Data.Entity;
using Tinroll.Data.Repositories.Interfaces;

namespace Tinroll.Data.Repositories {
    public class QuestionRepository : IQuestionRepository
    {
        private TinContext _dbContext;
        public QuestionRepository(TinContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateQuestionAsync(Question question)
        {
            question.User = null;
            await _dbContext.Questions.AddAsync(question);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsAsync() => await _dbContext.Questions.ToListAsync();

        public async Task<Question> GetQuestionAsync(Guid questionId) 
        {
            return await _dbContext.Questions
                .Include(q => q.User)
                .FirstOrDefaultAsync(q => q.QuestionId == questionId);
        } 

        public async Task<int> UpdateQuestionAsync(Question question)
        {
            question.User = null;
            _dbContext.Questions.Update(question);
            return await _dbContext.SaveChangesAsync();
        }
    }
}