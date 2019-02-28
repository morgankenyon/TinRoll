using System.Collections.Generic;
using System.Threading.Tasks;
using Tinroll.Data.Entities;
using Tinroll.Model.Question;

namespace Tinroll.Business.Managers.Interfaces {
    public interface IQuestionManager {
        Task<IEnumerable<QuestionDto>> GetAllQuestionsAsync();
    }
}