using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data.Entities;
using TinRoll.Data.Repositories.Interfaces;
using TinRoll.Logic.Managers.Interfaces;
using TinRoll.Logic.Mappers;
using TinRoll.Shared.Dtos;

namespace TinRoll.Logic.Managers
{
    public class AnswerManager : IAnswerManager
    {
        private readonly IBaseRepository<Answer> _answerRepo;

        public AnswerManager(IBaseRepository<Answer> answerRepo)
        {
            _answerRepo = answerRepo;
        }

        public async Task<AnswerDto> CreateAnswerAsync(AnswerDto answer)
        {
            var (dbAnswer, _) = answer.ToDb();
            var createdAnswer = await _answerRepo.CreateAsync(dbAnswer);
            return createdAnswer.ToDto();
        }

        public async Task<AnswerDto> GetAnswerAsync(int id)
        {
            Expression<Func<Answer, bool>> findById = (a) => a.Id == id;
            var dbAnswer = await _answerRepo.FindAsync(findById, "LatestAnswerPost");
            return dbAnswer.ToDto();
        }

        public async Task<IEnumerable<AnswerDto>> GetAnswersAsync()
        {
            var dbAnswers = await _answerRepo.GetAsync();
            var answers = dbAnswers.Select(a => a.ToDto());
            return answers;
        }
    }
}
