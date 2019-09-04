using System;
using System.Collections.Generic;
using System.Text;

namespace TinRoll.Shared.Dtos
{
    public class UserDto : BaseDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
    }
}
