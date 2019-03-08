// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.EntityFrameworkCore;
// using Tinroll.Data.Repositories.Interfaces;

// namespace Tinroll.Data.Repositories {
//     public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
//     {
//         protected readonly TinContext _dbContext;

//         public GenericRepository(TinContext dbContext)
//         {
//             _dbContext = dbContext;
//         }

//         public abstract Task CreateAsync(TEntity entity);

//         public async Task<IEnumerable<TEntity>> GetAllAsync()
//         {
//             return await _dbContext.Set<TEntity>()
//                 .ToListAsync();
//         }

//         public async Task<TEntity> GetByIdAsync(Guid id)
//         {
//             return await _dbContext.Set<TEntity>()
//                 .FindAsync(id);
//         }

//         public async Task UpdateAsync(TEntity entity)
//         {
//             _dbContext.Set<TEntity>().Update(entity);
//             await _dbContext.SaveChangesAsync();
//         }
//     }
// }