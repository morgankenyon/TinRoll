using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TinRoll.Data.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<T> CreateAsync(T user);

        Task<T> GetAsync(int id);

        Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null);
    }
}
