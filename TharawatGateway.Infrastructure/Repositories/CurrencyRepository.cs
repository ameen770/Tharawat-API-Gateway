using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TharawatGateway.Application.IRepositories;
using TharawatGateway.Domain.Entities;
using TharawatGateway.Infrastructure.Context;
using TharawatGateway.Infrastructure.GeneralOprationsImp;

namespace TharawatGateway.Infrastructure.Repositories
{
    public class CurrencyRepository : BaseInterfaceImp<Currency>, ICurrencyRepository
    {
        #region Fields
        private readonly DbSet<Currency> _currency;
        #endregion

        #region Constructors
        public CurrencyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _currency = dbContext.Set<Currency>();
        }
        #endregion

        #region Handles Functions
        public async Task<List<Currency>> GetCurrenciesListAsync()
        {
            return await _currency.ToListAsync();
        }
        #endregion
    }
}
