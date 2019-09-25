using System;
using System.Collections.Generic;
using System.Text;

namespace TinRoll.Data.Entities
{
    public class Tag : BaseEntity
    {
        public int Id { get; set; }
        public string TagText { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
