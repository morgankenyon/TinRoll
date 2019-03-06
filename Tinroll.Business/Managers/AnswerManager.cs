using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tinroll.Business.Managers.Interfaces;
using Tinroll.Business.Mapping;
using Tinroll.Data.Repositories.Interfaces;
using Tinroll.Model.Dto.Entity;

namespace Tinroll.Business.Managers {
    public class AnswerManager : IAnswerManager
    {
        private IAnswerRepository _answerRepo;

        public AnswerManager(IAnswerRepository answerRepo)
        {
            _answerRepo = answerRepo;
        }
        
        public async Task CreateAnswerAsync(AnswerDto answerDto)
        {
            var answer = AnswerMapper.ToEntity(answerDto);

            answer.AnswerId = Guid.Empty;
            await _answerRepo.CreateAsync(answer);
        }

        public async Task<IEnumerable<AnswerDto>> GetAllAnswersAsync()
        {
            var answers = await _answerRepo.GetAllAsync();

            var answerDtos = new List<AnswerDto>();
            foreach(var answer in answers) 
            {
                answerDtos.Add(AnswerMapper.ToDto(answer));
            }

            return answerDtos;
        }

        public async Task<AnswerDto> GetAnswerAsync(Guid answerId)
        {
            var answer = await _answerRepo.GetByIdAsync(answerId);

            return AnswerMapper.ToDto(answer);
        }

        public async Task UpdateAnswerAsync(AnswerDto answerDto)
        {
            var answer = AnswerMapper.ToEntity(answerDto);

            await _answerRepo.UpdateAsync(answer);
        }
    }
}