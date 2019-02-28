using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tinroll.Data.Entities {

    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AnswerId {get;set;}
        public string AnswerText {get;set;}
        public Question Question {get;set;}
        public User User {get;set;}
    }
}