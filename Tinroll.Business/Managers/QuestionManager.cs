using System.Collections.Generic;
using System.Threading.Tasks;
using Tinroll.Business.Managers.Interfaces;
using Tinroll.Business.Mapping;
using Tinroll.Data.Entities;
using Tinroll.Data.Repositories.Interfaces;
using Tinroll.Model.Question;

namespace Tinroll.Business.Managers {
    public class QuestionManager : IQuestionManager
    {
        private IQuestionRepository _questionRepo;
        public QuestionManager(IQuestionRepository questionRepository) {
            _questionRepo = questionRepository;
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
    }
}