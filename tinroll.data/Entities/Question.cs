using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tinroll.Data.Entities {
    public class Question 
    {
        public int QuestionId {get;set;}
        public string QuestionText {get;set;}
        public User User {get;set;}
    }
}