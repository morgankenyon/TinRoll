using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tinroll.Data.Entity;
using Tinroll.Model.Dto.Entity;

namespace Tinroll.Business.Managers.Interfaces {
    public interface IQuestionManager {
        Task<IEnumerable<QuestionDto>> GetAllQuestionsAsync();
        Task<QuestionDto> GetQuestionAsync(Guid questionId);
        Task CreateQuestionAsync(QuestionDto questionDto);
        Task UpdateQuestionAsync(QuestionDto questionDto);
    }
}