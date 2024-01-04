using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TharawatGateway.Domain.Entities;
using TharawatGateway.Domain.GeneralOprations;

namespace TharawatGateway.Application.IRepositories
{
    public interface IHobbyRepository : BaseInterface<Hobby>
    {
        public Task<List<Hobby>> GetHobbiesListAsync();
    }
}
