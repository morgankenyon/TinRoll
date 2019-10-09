using System;
using System.Collections.Generic;
using System.Text;

namespace TinRoll.Shared.Dtos
{
    public class CreateQuestionDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public IEnumerable<int> TagIds { get; set; }
    }
}
