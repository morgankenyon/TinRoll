using System;
using System.Collections.Generic;
using System.Text;
using TinRoll.Data.Entities;
using TinRoll.Shared.Dtos;

namespace TinRoll.Logic.Mappers
{
    public static class PostMapper
    {
        public static PostDto ToDto(this Post post) => post == null ? null :
            new PostDto
            {
                Content = post.Content
            };
    }
}
