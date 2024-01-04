using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TharawatGateway.Application.IRepositories;
using TharawatGateway.Domain.Entities;
using TharawatGateway.Domain.GeneralOprations;
using TharawatGateway.Infrastructure.Context;
using TharawatGateway.Infrastructure.GeneralOprationsImp;

namespace TharawatGateway.Infrastructure.Repositories
{
    public class CategoryRepository : BaseInterfaceImp<Category>, ICategoryRepository
    {
        #region Fields
        private readonly DbSet<Category> _category;
        #endregion

        #region Constructors
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _category = dbContext.Set<Category>();
        }
        #endregion

        #region Handles Functions
        public async Task<List<Category>> GetCategoriesListAsync()
        {
            return await _category.ToListAsync();
        }
        #endregion
    }
}
