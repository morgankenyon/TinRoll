using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tinroll.Data.Entities {

    public class Answer
    {
        public int AnswerId {get;set;}
        public string AnswerText {get;set;}
        public Question Question {get;set;}
        public User User {get;set;}
    }
}