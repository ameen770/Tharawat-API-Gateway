using Microsoft.EntityFrameworkCore;
using TharawatGateway.Application.IRepositories;
using TharawatGateway.Domain.Entities;
using TharawatGateway.Infrastructure.Context;
using TharawatGateway.Infrastructure.GeneralOprationsImp;

namespace TharawatGateway.Infrastructure.Repositories
{
    public class GatewayProviderRepository : BaseInterfaceImp<GatewayProvider>, IGatewayProviderRepository
    {
        #region Fields
        private readonly DbSet<GatewayProvider> _gatewayProvider;
        #endregion

        #region Constructors
        public GatewayProviderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _gatewayProvider = dbContext.Set<GatewayProvider>();
        }
        #endregion

        #region Handles Functions
        public async Task<List<GatewayProvider>> GetGatewayProvidersListAsync()
        {
            return await _gatewayProvider.ToListAsync();
        }
        #endregion
    }
}
