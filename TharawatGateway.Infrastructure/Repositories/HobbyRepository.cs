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
    public class HobbyRepository : BaseInterfaceImp<Hobby>, IHobbyRepository
    {
        #region Fields
        private readonly DbSet<Hobby> _hobby;
        #endregion

        #region Constructors
        public HobbyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _hobby = dbContext.Set<Hobby>();
        }
        #endregion

        #region Handles Functions
        public async Task<List<Hobby>> GetHobbiesListAsync()
        {
            return await _hobby.ToListAsync();
        }
        #endregion
    }
}
