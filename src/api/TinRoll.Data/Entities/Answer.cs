using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TinRoll.Data.Entities
{
    public class Answer : BaseEntity
    {
        public int Id { get; set; }
        //public AnswerPost LatestAnswerPost { get; set; }
        //public int LatestAnswerPostId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public ICollection<AnswerPost> AnswerPosts { get; set; }
    }
}
