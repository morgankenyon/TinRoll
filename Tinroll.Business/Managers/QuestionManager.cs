using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tinroll.Business.Managers.Interfaces;
using Tinroll.Business.Mapping;
using Tinroll.Data.Entity;
using Tinroll.Data.Repositories.Interfaces;
using Tinroll.Model.Dto.Entity;

namespace Tinroll.Business.Managers {
    public class QuestionManager : IQuestionManager
    {
        private IQuestionRepository _questionRepo;
        public QuestionManager(IQuestionRepository questionRepository) {
            _questionRepo = questionRepository;
        }

        public async Task CreateQuestionAsync(QuestionDto questionDto)
        {
            var question = QuestionMapper.ToEntity(questionDto);

            question.QuestionId = Guid.Empty;
            await _questionRepo.CreateAsync(question);
        }

        public async Task<IEnumerable<QuestionDto>> GetAllQuestionsAsync()
        {
            var questions = await _questionRepo.GetAllAsync();

            var questionDtos = new List<QuestionDto>();
            foreach(var question in questions) {
                questionDtos.Add(QuestionMapper.ToDto(question));
            }

            return questionDtos;
        }

        public async Task<QuestionDto> GetQuestionAsync(Guid questionId)
        {
            var question = await _questionRepo.GetByIdAsync(questionId);

            return QuestionMapper.ToDto(question);
        }

        public async Task UpdateQuestionAsync(QuestionDto questionDto)
        {
            var question = QuestionMapper.ToEntity(questionDto);

            await _questionRepo.UpdateAsync(question);
        }
    }
}