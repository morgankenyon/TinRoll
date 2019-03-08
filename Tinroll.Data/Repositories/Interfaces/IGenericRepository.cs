// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace Tinroll.Data.Repositories.Interfaces {
//     public interface IGenericRepository<TEntity> where TEntity : class
//     {
//         Task<IEnumerable<TEntity>> GetAllAsync();
    
//         Task<TEntity> GetByIdAsync(Guid id);
    
//         Task CreateAsync(TEntity entity);
    
//         Task UpdateAsync(TEntity entity);
//     }
// }