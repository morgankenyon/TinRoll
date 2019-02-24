using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace tinroll.data
{
    public class TinContext : DbContext
    {
        public TinContext(DbContextOptions<TinContext> options)
            : base(options)
        { }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<User> Users {get;set;}
    }

    public class Question 
    {
        public int QuestionId {get;set;}
        public string QuestionText {get;set;}
        public List<Answer> Answers {get;set;}
    }

    public class Answer
    {
        public int AnswerId {get;set;}
        public string AnswerText {get;set;}

    }

    public class User
    {
        public int UserId {get;set;}
        public string UserName {get;set;}
        
    }
}