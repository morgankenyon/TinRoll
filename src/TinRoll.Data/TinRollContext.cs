using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TinRoll.Data.Entities;

namespace TinRoll.Data
{
    public class TinRollContext : DbContext
    {
        public TinRollContext(DbContextOptions<TinRollContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<Question> Questions { get; set; }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var added = ChangeTracker.Entries<BaseEntity>().Where(E => E.State == EntityState.Added).ToList();

            added.ForEach(a =>
            {
                a.Property(p => p.CreatedDate).CurrentValue = DateTime.UtcNow;
                a.Property(p => p.CreatedDate).IsModified = true;
                a.Property(p => p.UpdatedDate).CurrentValue = DateTime.UtcNow;
                a.Property(p => p.UpdatedDate).IsModified = true;
            });

            var updated = ChangeTracker.Entries<BaseEntity>().Where(E => E.State == EntityState.Modified).ToList();

            updated.ForEach(u =>
            {
                u.Property(p => p.UpdatedDate).CurrentValue = DateTime.UtcNow;
                u.Property(p => p.UpdatedDate).IsModified = true;
            });

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
