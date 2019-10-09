using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TinRoll.Data.Entities
{
    public class Tag : BaseEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TagText { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<QuestionTag> QuestionTags { get; set; }
    }
}
