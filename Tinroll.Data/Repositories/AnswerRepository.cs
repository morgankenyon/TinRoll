using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tinroll.Data.Entity;
using Tinroll.Data.Repositories.Interfaces;

namespace Tinroll.Data.Repositories {
    public class AnswerRepository : IAnswerRepository
    {
        private readonly TinContext _dbContext;
        public AnswerRepository(TinContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAnswerAsync(Answer answer)
        {
            answer.User = null;
            answer.Question = null;
            await _dbContext.Answers.AddAsync(answer);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Answer>> GetAllAnswersAsync() => await _dbContext.Answers.ToListAsync();

        public async Task<Answer> GetAnswerAsync(Guid answerId) => await _dbContext.Answers.FindAsync(answerId);

        public async Task<int> UpdateAnswerAsync(Answer answer)
        {   
            answer.User = null;
            answer.Question = null;
            _dbContext.Answers.Update(answer);
            return await _dbContext.SaveChangesAsync();
        }
    }
}