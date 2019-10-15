using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TinRoll.Data.Entities;
using TinRoll.Data.Repositories.Interfaces;

namespace TinRoll.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        internal readonly TinRollContext context;

        public BaseRepository(TinRollContext context)
        {
            this.context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await context.AddAsync<T>(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> GetAsync(int id)
        {
            return await context.FindAsync<T>(id);
        }

        public Task<IEnumerable<T>> GetAsync()
        {
            return GetAsync(null, null, null);
        }

        public Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter)
        {
            return GetAsync(filter, null, null);
        }

        public Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter,
            string includeProperties)
        {
            return GetAsync(filter, null, includeProperties);
        }

        public async Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null)
        {
            IQueryable<T> query = context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToAsyncEnumerable().ToList();
            }
            else
            {
                return await query.ToAsyncEnumerable().ToList();
            }
        }
    }
}