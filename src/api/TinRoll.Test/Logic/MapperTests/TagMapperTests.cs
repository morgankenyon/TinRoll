using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using TinRoll.Data.Entities;
using TinRoll.Logic.Mappers;
using TinRoll.Shared.Dtos;
using Xunit;

namespace TinRoll.Test.Logic.MapperTests
{
    public class TagMapperTests
    {
        [Fact]
        public void Test_Tag_To_TagDto()
        {
            var tag = new Tag
            {
                Id = 1,
                CreatedDate = DateTime.UtcNow,
                DisplayText = "C#",
                SearchText = "c#",
                UpdatedDate = DateTime.UtcNow,
                UserId = 23
            };

            var tagDto = TagMapper.ToDto(tag);

            tagDto.Should().NotBeNull();
            tagDto.Id.Should().Be(tag.Id);
            tagDto.CreatedDate.Should().Be(tag.CreatedDate);
            tagDto.TagText.Should().Be(tag.DisplayText);
            tagDto.UpdatedDate.Should().Be(tag.UpdatedDate);
            tagDto.UserId.Should().Be(tag.UserId);
        }

        [Fact]
        public void Test_TagDto_To_Tag()
        {
            var tagDto = new TagDto
            {
                Id = 1,
                CreatedDate = DateTime.UtcNow,
                TagText = "C#",
                UpdatedDate = DateTime.UtcNow,
                UserId = 33
            };

            var tag = TagMapper.ToDb(tagDto);

            tag.Should().NotBeNull();
            tag.Id.Should().Be(tagDto.Id);
            tag.CreatedDate.Should().Be(tagDto.CreatedDate);
            tag.DisplayText.Should().Be(tagDto.TagText);
            tag.SearchText.Should().Be(tagDto.TagText.ToLower());
            tag.UpdatedDate.Should().Be(tagDto.UpdatedDate);
            tag.UserId.Should().Be(tagDto.UserId);
        }
    }
}
