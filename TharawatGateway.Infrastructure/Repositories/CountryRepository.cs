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
    public class CountryRepository : BaseInterfaceImp<Country>, ICountryRepository
    {
        #region Fields
        private readonly DbSet<Country> _country;
        #endregion

        #region Constructors
        public CountryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _country = dbContext.Set<Country>();
        }
        #endregion

        #region Handles Functions
        public async Task<List<Country>> GetCountriesListAsync()
        {
            return await _country.ToListAsync();
        }
        #endregion
    }
}
