using System;
using System.Collections.Generic;
using System.Text;

namespace TinRoll.Shared.Dtos
{
    public abstract class BaseDto
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
