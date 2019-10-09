using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data.Repositories.Interfaces;
using TinRoll.Logic.Managers.Interfaces;
using TinRoll.Logic.Mappers;
using TinRoll.Shared.Dtos;

namespace TinRoll.Logic.Managers
{
    public class TagManager : ITagManager
    {
        private readonly ITagRepository _tagRepo;

        public TagManager(ITagRepository tagRepo)
        {
            _tagRepo = tagRepo;
        }

        public async Task<TagDto> CreateTagAsync(TagDto Tag)
        {
            var dbTag = TagMapper.ToDb(Tag);
            var createdTag = await _tagRepo.CreateTagAsync(dbTag);
            return TagMapper.ToDto(createdTag);
        }

        public async Task<TagDto> GetTagAsync(int id)
        {
            var dbTag = await _tagRepo.GetTagAsync(id);
            return TagMapper.ToDto(dbTag);
        }

        public async Task<IEnumerable<TagDto>> GetTagsAsync(string searchText)
        {
            var dbTags = await _tagRepo.FindTagsAsync(searchText);
            var tags = dbTags.Select(t => TagMapper.ToDto(t));
            return tags;
        }

        public async Task<IEnumerable<TagDto>> GetTagsAsync()
        {
            var dbTags = await _tagRepo.GetTagsAsync();
            var tags = dbTags.Select(t => TagMapper.ToDto(t));
            return tags;
        }
    }
}
