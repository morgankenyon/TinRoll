using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data.Entities;
using TinRoll.Data.Repositories.Interfaces;

namespace TinRoll.Data.Repositories
{
    public class TagRepository : ITagRepository
    {
        private IBaseRepository<Tag> _tagRepo;
        private IBaseRepository<QuestionTag> _questionTagRepo;

        public TagRepository(IBaseRepository<Tag> tagRepo, 
            IBaseRepository<QuestionTag> questionTagRepo)
        {
            _tagRepo = tagRepo;
            _questionTagRepo = questionTagRepo;
        }

        public async Task<QuestionTag> CreateQuestionTagAsync(QuestionTag questionTag)
        {
            return await _questionTagRepo.CreateAsync(questionTag);
        }

        public async Task<Tag> CreateTagAsync(Tag tag)
        {
            return await _tagRepo.CreateAsync(tag);
        }

        public async Task<IEnumerable<Tag>> FindTagsAsync(string tagText)
        {
            Expression<Func<Tag, bool>> findByText = (t) => t.SearchText.StartsWith(tagText.ToLower());
            var tagsByName = await _tagRepo.GetAsync(filter: findByText);
            return tagsByName;
        }

        public async Task<QuestionTag> GetQuestionTagAsync(int id)
        {
            return await _questionTagRepo.GetAsync(id);
        }

        public async Task<IEnumerable<QuestionTag>> GetQuestionTagsAsync()
        {
            return await _questionTagRepo.GetAsync();
        }

        public async Task<Tag> GetTagAsync(int id)
        {
            return await _tagRepo.GetAsync(id);
        }

        public async Task<IEnumerable<Tag>> GetTagsAsync()
        {
            return await _tagRepo.GetAsync();
        }
    }
}
