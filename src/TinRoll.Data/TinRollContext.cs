using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TinRoll.Data.Entities;

namespace TinRoll.Data
{
    public class TinRollContext : DbContext
    {
        public TinRollContext(DbContextOptions<TinRollContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
    }
}
