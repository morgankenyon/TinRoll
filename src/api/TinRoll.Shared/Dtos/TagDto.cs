using System;
using System.Collections.Generic;
using System.Text;

namespace TinRoll.Shared.Dtos
{
    public class TagDto : BaseDto
    {
        public int Id { get; set; }
        public string TagText { get; set; }
        public int UserId { get; set; }
    }
}
