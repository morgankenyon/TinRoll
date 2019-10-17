using System;
using System.Collections.Generic;
using System.Text;

namespace TinRoll.Data.Entities
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
