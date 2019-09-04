using System;
using System.Collections.Generic;
using System.Text;

namespace TinRoll.Data.Entities
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public List<Question> Questions { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
