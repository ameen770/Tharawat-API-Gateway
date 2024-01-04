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
    public class GovernorateRepository : BaseInterfaceImp<Governorate>, IGovernorateRepository
    {
        #region Fields
        private readonly DbSet<Governorate> _governorate;
        #endregion

        #region Constructors
        public GovernorateRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _governorate = dbContext.Set<Governorate>();
        }
        #endregion

        #region Handles Functions
        public async Task<List<Governorate>> GetGovernoratesListAsync()
        {
            return await _governorate.ToListAsync();
        }
        #endregion
    }
}
