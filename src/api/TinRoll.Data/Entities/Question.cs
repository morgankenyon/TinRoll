using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TinRoll.Data.Entities
{
    public class Question : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        //public QuestionPost LatestQuestionPost { get; set; }
        //public int LatestQuestionPostId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<QuestionTag> QuestionTags { get; set; }
        public ICollection<QuestionPost> QuestionPosts { get; set; }
    }
}
