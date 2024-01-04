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
    public class InvoiceRepository : BaseInterfaceImp<Invoice>, IInvoiceRepository
    {
        #region Fields
        private readonly DbSet<Invoice> _invoice;
        #endregion

        #region Constructors
        public InvoiceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _invoice = dbContext.Set<Invoice>();
        }
        #endregion

        #region Handles Functions
        public async Task<List<Invoice>> GetInvoicesListAsync()
        {
            return await _invoice.ToListAsync();
        }
        #endregion
    }
}
