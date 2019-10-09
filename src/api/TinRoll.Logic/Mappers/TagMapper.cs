using System;
using System.Collections.Generic;
using System.Text;
using TinRoll.Data.Entities;
using TinRoll.Shared.Dtos;

namespace TinRoll.Logic.Mappers
{
    public static class TagMapper
    {
        public static TagDto ToDto(Tag tag)
        {
            return new TagDto
            {
                Id = tag.Id,
                TagText = tag.TagText,
                CreatedDate = tag.CreatedDate,
                UpdatedDate = tag.UpdatedDate,
                UserId = tag.UserId
            };
        }

        public static Tag ToDb(TagDto tagDto)
        {
            return new Tag
            {
                Id = tagDto.Id,
                TagText = tagDto.TagText,
                CreatedDate = tagDto.CreatedDate,
                UpdatedDate = tagDto.UpdatedDate,
                UserId = tagDto.UserId
            };
        }
    }
}
