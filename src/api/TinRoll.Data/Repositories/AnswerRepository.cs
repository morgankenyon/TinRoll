using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data.Entities;
using TinRoll.Data.Repositories.Interfaces;

namespace TinRoll.Data.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private IBaseRepository<Answer> _baseRepo;

        public AnswerRepository(IBaseRepository<Answer> baseRepo)
        {
            _baseRepo = baseRepo;
        }

        public async Task<Answer> CreateAnswerAsync(Answer answer)
        {
            return await _baseRepo.CreateAsync(answer);
        }

        public async Task<Answer> GetAnswerAsync(int id)
        {
            return await _baseRepo.GetAsync(id);
        }

        public async Task<IEnumerable<Answer>> GetAnswersAsync()
        {
            return await _baseRepo.GetAsync();
        }
    }
}
