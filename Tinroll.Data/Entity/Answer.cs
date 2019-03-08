using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tinroll.Data.Entity {

    public class Answer : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AnswerId {get;set;}
        public string AnswerText {get;set;}
        public Question Question {get;set;}
        public Guid QuestionId {get;set;}
        public User User {get;set;}
        public Guid UserId {get;set;}
    }
}