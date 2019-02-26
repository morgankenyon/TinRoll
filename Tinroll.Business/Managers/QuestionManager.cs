using System.Collections.Generic;
using System.Threading.Tasks;
using Tinroll.Business.Managers.Interfaces;
using Tinroll.Data.Entities;
using Tinroll.Data.Repositories.Interfaces;

namespace Tinroll.Business.Managers {
    public class QuestionManager : IQuestionManager
    {
        private IQuestionRepository _questionRepo;
        public QuestionManager(IQuestionRepository questionRepository) {
            _questionRepo = questionRepository;
        }
        public async Task<IEnumerable<Question>> GetAllQuestions()
        {
            return await _questionRepo.GetAllQuestions();
        }
    }
}