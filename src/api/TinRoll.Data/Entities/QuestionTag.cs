using System;
using System.Collections.Generic;
using System.Text;

namespace TinRoll.Data.Entities
{
    public class QuestionTag : BaseEntity
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
