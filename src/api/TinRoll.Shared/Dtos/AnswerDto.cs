using System;
using System.Collections.Generic;
using System.Text;

namespace TinRoll.Shared.Dtos
{
    public class AnswerDto : BaseDto
    {
        public int Id { get; set; }
        public PostDto PostDto { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
    }
}
