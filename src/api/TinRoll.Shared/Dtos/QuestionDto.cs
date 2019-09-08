using System;
using System.Collections.Generic;
using System.Text;

namespace TinRoll.Shared.Dtos
{
    public class QuestionDto : BaseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
    }
}
