using System;
using System.Collections.Generic;
using System.Text;

namespace TinRoll.Shared
{
    public class UserDto : BaseDto
    { 
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public List<QuestionDto> Questions { get; set; }
    }
}
