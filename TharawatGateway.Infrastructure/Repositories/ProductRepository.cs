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
    public class ProductRepository : BaseInterfaceImp<Product>, IProductRepository
    {
        #region Fields
        private readonly DbSet<Product> _product;
        #endregion

        #region Constructors
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _product = dbContext.Set<Product>();
        }
        #endregion

        #region Handles Functions
        public async Task<List<Product>> GetProductsListAsync()
        {
            return await _product.ToListAsync();
        }
        #endregion
    }
}
