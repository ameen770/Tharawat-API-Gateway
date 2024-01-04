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
    public class CityRepository : BaseInterfaceImp<City>, ICityRepository
    {
        #region Fields
        private readonly DbSet<City> _city;
        #endregion

        #region Constructors
        public CityRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _city = dbContext.Set<City>();
        }
        #endregion

        #region Handles Functions
        public async Task<List<City>> GetCitiesListAsync()
        {
            return await _city.ToListAsync();
        }
        #endregion
    }
}
