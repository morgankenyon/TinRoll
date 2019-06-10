using System.Collections.Generic;

namespace TinRoll.Data.Entities
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public List<Question> Questions { get; set; }
    }
}
