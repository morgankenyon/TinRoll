using System;
using System.Collections.Generic;
using System.Text;

namespace TinRoll.Shared
{
    public abstract class BaseDto
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
