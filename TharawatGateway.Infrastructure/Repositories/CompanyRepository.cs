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
    public class CompanyRepository : BaseInterfaceImp<Company>, ICompanyRepository
    {
        #region Fields
        private readonly DbSet<Company> _company;
        #endregion

        #region Constructors
        public CompanyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _company = dbContext.Set<Company>();
        }
        #endregion

        #region Handles Functions
        public async Task<List<Company>> GetCompaniesListAsync()
        {
            return await _company.ToListAsync();
        }
        #endregion
    }
}
