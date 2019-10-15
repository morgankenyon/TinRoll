using System;
using System.Collections.Generic;
using System.Text;

namespace TinRoll.Data.Entities
{
    public class AnswerPost : Post
    {
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
    }
}
