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
                Name = tag.Name,
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
                Name = tagDto.Name.ToLower(),
                CreatedDate = tagDto.CreatedDate,
                UpdatedDate = tagDto.UpdatedDate,
                UserId = tagDto.UserId
            };
        }
    }
}
