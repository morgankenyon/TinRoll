using System;
using System.Collections.Generic;
using System.Text;

namespace TinRoll.Shared.Dtos
{
    public class PostDto : BaseDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
    }
}
