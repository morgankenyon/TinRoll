using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using TinRoll.Data.Entities;
using TinRoll.Data.Repositories.Interfaces;
using TinRoll.Logic.Managers;
using TinRoll.Shared.Dtos;
using Xunit;

namespace TinRoll.Test.Logic.Managers
{
    public class TagManagerTests
    {
        [Fact]
        public async Task Test_Create_Tag()
        {
            var mockTag = new Tag
            {
                Id = 1
            };

            var mockTagRepo = new Mock<IBaseRepository<Tag>>();
            var mockQuestionTagRepo = new Mock<IBaseRepository<QuestionTag>>();

            mockTagRepo.Setup(a => a.CreateAsync(It.IsAny<Tag>()))
                .ReturnsAsync(mockTag);

            var tagManager = new TagManager(mockTagRepo.Object, mockQuestionTagRepo.Object);

            var tagToTest = new TagDto()
            {
                Name = "c#"
            };

            var createdTag = await tagManager.CreateTagAsync(tagToTest);

            createdTag.Should().NotBeNull();
            createdTag.Id.Should().Be(1);
            mockTagRepo.Verify(u => u.CreateAsync(It.IsAny<Tag>()), Times.Once);
        }

        [Fact]
        public async Task Test_Get_Tag()
        {
            var mockTag = new Tag
            {
                Id = 1
            };

            var mockTagRepo = new Mock<IBaseRepository<Tag>>();
            var mockQuestionTagRepo = new Mock<IBaseRepository<QuestionTag>>();

            mockTagRepo.Setup(a => a.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(mockTag);

            var tagManager = new TagManager(mockTagRepo.Object, mockQuestionTagRepo.Object);

            var tag = await tagManager.GetTagAsync(1);

            tag.Should().NotBeNull();
            tag.Id.Should().Be(1);
            mockTagRepo.Verify(u => u.GetAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task Test_Get_Tags()
        {
            var mockTags = new List<Tag>
            {
                new Tag
                {
                    Id = 1
                },
                new Tag
                {
                    Id = 2
                }
            };

            var mockTagRepo = new Mock<IBaseRepository<Tag>>();
            var mockQuestionTagRepo = new Mock<IBaseRepository<QuestionTag>>();

            mockTagRepo.Setup(a => a.GetAsync())
                .ReturnsAsync(mockTags);

            var tagManager = new TagManager(mockTagRepo.Object, mockQuestionTagRepo.Object);

            var tags = await tagManager.GetTagsAsync();

            tags.Should().HaveCount(2);
            tags.First().Id.Should().Be(1);
            tags.Skip(1).First().Id.Should().Be(2);
            mockTagRepo.Verify(u => u.GetAsync(), Times.Once);
        }

        [Fact]
        public async Task Test_Get_Tags_By_Text()
        {
            var mockTags = new List<Tag>
            {
                new Tag
                {
                    Id = 1,
                    Name = "c#"
                },
                new Tag
                {
                    Id = 2,
                    Name = "c"
                }
            };

            var mockTagRepo = new Mock<IBaseRepository<Tag>>();
            var mockQuestionTagRepo = new Mock<IBaseRepository<QuestionTag>>();

            mockTagRepo.Setup(a => a.GetAsync(It.IsAny<Expression<Func<Tag, bool>>>()))
                .ReturnsAsync(mockTags);

            var tagManager = new TagManager(mockTagRepo.Object, mockQuestionTagRepo.Object);

            var tags = await tagManager.GetTagsAsync("c");

            tags.Should().HaveCount(2);
            tags.First().Id.Should().Be(1);
            tags.First().Name.Should().Be("c#");
            tags.Skip(1).First().Id.Should().Be(2);
            tags.Skip(1).First().Name.Should().Be("c");
        }

        [Fact]
        public async Task Test_GetTagsByQuestionId()
        {
            var mockQuestionTags = new List<QuestionTag>
            {
                new QuestionTag
                {
                    QuestionId = 1,
                    Tag = new Tag
                    {
                        Id = 1,
                        Name = "c#"
                    }
                },
                new QuestionTag
                {
                    QuestionId = 1,
                    Tag = new Tag
                    {
                        Id = 2,
                        Name = "c"
                    }
                }
            };

            var mockTagRepo = new Mock<IBaseRepository<Tag>>();
            var mockQuestionTagRepo = new Mock<IBaseRepository<QuestionTag>>();

            mockQuestionTagRepo.Setup(a => a.GetAsync(It.IsAny<Expression<Func<QuestionTag, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(mockQuestionTags);

            var tagManager = new TagManager(mockTagRepo.Object, mockQuestionTagRepo.Object);
            
            var tags = await tagManager.GetTagsAsync(1);

            tags.Should().HaveCount(2);
            tags.First().Id.Should().Be(1);
            tags.Skip(1).First().Id.Should().Be(2);
        }
    }
}
