using System;
using System.Collections.Generic;
using System.Text;

namespace TinRoll.Data.Entities
{
    public abstract class Post : BaseEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
