using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TharawatGateway.Domain.GeneralOprations
{
    public interface BaseInterface<T> where T : class
    {
        Task<T> GetByIdAsync(int? id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        IQueryable<T> GetTableNoTracking();
        // IDbContextTransaction BeginTransaction();
    }
}
