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
    public class QuestionManager : IQuestionManager
    {
        private readonly IQuestionRepository _questionRepo;
        private readonly ICreateQuestionRepository _createQuestionRepo;

        public QuestionManager(IQuestionRepository questionRepo, ICreateQuestionRepository createQuestionRepo)
        {
            _questionRepo = questionRepo;
            _createQuestionRepo = createQuestionRepo;
        }

        public async Task<QuestionDto> CreateQuestionAsync(CreateQuestionDto question)
        {
            var dbQuestion = QuestionMapper.ToDb(question);
            await _createQuestionRepo.CreateQuestionAsync(dbQuestion, question.TagIds);

            return QuestionMapper.ToDto(dbQuestion);
        }

        public async Task<QuestionDto> GetQuestionAsync(int id)
        {
            var dbQuestion = await _questionRepo.GetQuestionAsync(id);
            return QuestionMapper.ToDto(dbQuestion);
        }

        public async Task<IEnumerable<QuestionDto>> GetQuestionsAsync()
        {
            var dbQuestions = await _questionRepo.GetQuestionsAsync();
            var questions = dbQuestions.Select(q => QuestionMapper.ToDto(q));
            return questions;
        }
    }
}
