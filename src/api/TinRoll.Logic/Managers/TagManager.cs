using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data.Entities;
using TinRoll.Data.Repositories.Interfaces;
using TinRoll.Logic.Managers.Interfaces;
using TinRoll.Logic.Mappers;
using TinRoll.Shared.Dtos;

namespace TinRoll.Logic.Managers
{
    public class TagManager : ITagManager
    {
        private readonly IBaseRepository<Tag> _tagRepo;
        private readonly IBaseRepository<QuestionTag> _questionTagRepo;

        public TagManager(IBaseRepository<Tag> tagRepo,
            IBaseRepository<QuestionTag> questionTagRepo)
        {
            _tagRepo = tagRepo;
            _questionTagRepo = questionTagRepo;
        }

        public async Task<TagDto> CreateTagAsync(TagDto tag)
        {
            var dbTag = tag.ToDb();
            var createdTag = await _tagRepo.CreateAsync(dbTag);
            return createdTag.ToDto();
        }

        public async Task<TagDto> GetTagAsync(int id)
        {
            var dbTag = await _tagRepo.GetAsync(id);
            return dbTag.ToDto();
        }

        public async Task<IEnumerable<TagDto>> GetTagsAsync(string searchText)
        {
            Expression<Func<Tag, bool>> findByText = (t) => t.Name.StartsWith(searchText.ToLower());
            var dbTags = await _tagRepo.GetAsync(filter: findByText);
            var tags = dbTags.Select(t => t.ToDto());
            return tags;
        }

        public async Task<IEnumerable<TagDto>> GetTagsAsync()
        {
            var dbTags = await _tagRepo.GetAsync();
            var tags = dbTags.Select(t => t.ToDto());
            return tags;
        }

        public async Task<IEnumerable<TagDto>> GetTagsAsync(int questionId)
        {
            Expression<Func<QuestionTag, bool>> findByQuestionId = (qt) => qt.QuestionId == questionId;
            var questionTags = await _questionTagRepo.GetAsync(filter: findByQuestionId, includeProperties: "Tag");
            var tags = questionTags.Select(t => t.Tag.ToDto());
            return tags;
        }
    }
}
