using System;
using System.Collections.Generic;
using System.Text;

namespace TinRoll.Shared
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
    }
}
