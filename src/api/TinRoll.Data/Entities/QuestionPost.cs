using System;
using System.Collections.Generic;
using System.Text;

namespace TinRoll.Data.Entities
{
    public class QuestionPost : Post
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
