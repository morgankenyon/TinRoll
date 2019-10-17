using System;
using System.Collections.Generic;
using System.Linq;
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
            var dbAnswer = AnswerMapper.ToDb(answer);
            var createdAnswer = await _answerRepo.CreateAsync(dbAnswer);
            return AnswerMapper.ToDto(createdAnswer);
        }

        public async Task<AnswerDto> GetAnswerAsync(int id)
        {
            var dbAnswer = await _answerRepo.GetAsync(id);
            return AnswerMapper.ToDto(dbAnswer);
        }

        public async Task<IEnumerable<AnswerDto>> GetAnswersAsync()
        {
            var dbAnswers = await _answerRepo.GetAsync();
            var answers = dbAnswers.Select(a => AnswerMapper.ToDto(a));
            return answers;
        }
    }
}
