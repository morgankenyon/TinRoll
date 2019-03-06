using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tinroll.Data.Repositories.Interfaces;

namespace Tinroll.Data.Repositories {
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly TinContext _tin;

        public GenericRepository(TinContext tinContext)
        {
            _tin = tinContext;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _tin.Set<TEntity>().AddAsync(entity);
            await _tin.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _tin.Set<TEntity>()
                .ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _tin.Set<TEntity>()
                .FindAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _tin.Set<TEntity>().Update(entity);
            await _tin.SaveChangesAsync();
        }
    }
}