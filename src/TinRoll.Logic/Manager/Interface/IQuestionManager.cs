using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Shared;

namespace TinRoll.Logic.Manager.Interface
{
    public interface IQuestionManager
    {
        Task<QuestionDto> CreateQuestionAsync(QuestionDto question);
        Task<QuestionDto> GetQuestionAsync(int id);
        Task<IEnumerable<QuestionDto>> GetQuestionsAsync();
    }
}
