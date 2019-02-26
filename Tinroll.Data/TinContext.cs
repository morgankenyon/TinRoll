using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Tinroll.Data.Entities;

namespace Tinroll.Data
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



}