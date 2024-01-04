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
    public class PurposeRepository : BaseInterfaceImp<Purpose>, IPurposeRepository
    {
        #region Fields
        private readonly DbSet<Purpose> _purpose;
        #endregion

        #region Constructors
        public PurposeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _purpose = dbContext.Set<Purpose>();
        }
        #endregion

        #region Handles Functions
        public async Task<List<Purpose>> GetPurposesListAsync()
        {
            return await _purpose.ToListAsync();
        }
        #endregion
    }
}
