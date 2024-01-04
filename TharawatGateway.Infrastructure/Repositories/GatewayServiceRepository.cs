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
    public class GatewayServiceRepository : BaseInterfaceImp<GatewayService>, IGatewayServiceRepository
    {
        #region Fields
        private readonly DbSet<GatewayService> _gatewayService;
        #endregion

        #region Constructors
        public GatewayServiceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _gatewayService = dbContext.Set<GatewayService>();
        }
        #endregion

        #region Handles Functions
        public async Task<List<GatewayService>> GetGatewayServicesListAsync()
        {
            return await _gatewayService.ToListAsync();
        }
        #endregion
    }
}
