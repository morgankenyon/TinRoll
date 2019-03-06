using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tinroll.Model.Dto.Entity;

namespace Tinroll.Business.Managers.Interfaces {
    public interface IAnswerManager {
        Task<IEnumerable<AnswerDto>> GetAllAnswersAsync();
        Task<AnswerDto> GetAnswerAsync(Guid answerId);
        Task CreateAnswerAsync(AnswerDto answerDto);
        Task UpdateAnswerAsync(AnswerDto answerDto);
        
    }
}