using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tinroll.Data.Entity;

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

        // public override int SaveChanges()
        // {
        //     var AddedEntities = ChangeTracker.Entries<Entity>().Where(E => E.State == EntityState.Added).ToList();

        //     AddedEntities.ForEach(E => 
        //     {
        //         E.CreatedDate = DateTime.Now;
        //     });

        //     var ModifiedEntities = ChangeTracker.Entries<Entity>().Where(E => E.State == EntityState.Modified).ToList();

        //     ModifiedEntities.ForEach(E => 
        //     {
        //         E.ModifiedDate = DateTime.Now;
        //     });

        //     return base.SaveChanges();
        // }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            var AddedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Added).ToList();

            AddedEntities.ForEach(E =>
            {
                E.Property("CreatedDate").CurrentValue = DateTime.UtcNow;
                E.Property("ModifiedDate").CurrentValue = DateTime.UtcNow;
            });

            var EditedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified).ToList();

            EditedEntities.ForEach(E =>
            {
                E.Property("ModifiedDate").CurrentValue = DateTime.UtcNow;
            });

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}