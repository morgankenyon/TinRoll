using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Shared.Dtos;

namespace TinRoll.Logic.Managers.Interfaces
{
    public interface ITagManager
    {
        Task<TagDto> CreateTagAsync(TagDto Tag);
        Task<TagDto> GetTagAsync(int id);
        Task<IEnumerable<TagDto>> GetTagsAsync(string searchText);
        Task<IEnumerable<TagDto>> GetTagsAsync();
    }
}
