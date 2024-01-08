using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TharawatGateway.Domain.Entities;
using TharawatGateway.Domain.GeneralRepository;
using TharawatGateway.Infrastructure.Context;

namespace TharawatGateway.Infrastructure.GeneralRepositoryImp
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Vars / Props

        protected readonly ApplicationDbContext _dbContext;

        #endregion

        #region Constructor(s)
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion


        #region Methods

        #endregion

        #region Actions
        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<T> GetByIdAsync(int? id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<List<T>> GetListAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public IQueryable<T> GetTableNoTracking()
        {
            return _dbContext.Set<T>().AsNoTracking().AsQueryable();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}
