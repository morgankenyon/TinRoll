using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data.Entities;

namespace TinRoll.Data.Repositories.Interfaces
{
    public interface ITagRepository
    {
        Task<Tag> CreateTagAsync(Tag tag);
        Task<Tag> FindTagAsync(string tagText);
        Task<Tag> GetTagAsync(int id);
        Task<IEnumerable<Tag>> GetTagsAsync();
        Task<QuestionTag> CreateQuestionTagAsync(QuestionTag questionTag);
        Task<QuestionTag> GetQuestionTagAsync(int id);
        Task<IEnumerable<QuestionTag>> GetQuestionTagsAsync();
    }
}
