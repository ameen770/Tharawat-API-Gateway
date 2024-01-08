using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TharawatGateway.Domain.Entities;

namespace TharawatGateway.Domain.GeneralRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetListAsync();
        Task<T> GetByIdAsync(int? id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        IQueryable<T> GetTableNoTracking();
        // IDbContextTransaction BeginTransaction();
    }
}
