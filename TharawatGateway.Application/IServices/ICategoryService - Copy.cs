using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TharawatGateway.Domain.Entities;


namespace TharawatGateway.Application.IServices
{
    public interface ICityService
    {
        public Task<List<City>> GetCitiesLists();
        public Task<City> GetCityByIds(int? id);
        public Task<string> AddAsync(City category);
        public Task<bool> IsNameExist(string name);
        public Task<string> EditAsync(City category);
        public Task<bool> IsNameExistExcludeSelf(string name, int id);
        public Task<string> DeleteAsync(City category);
        public Task<bool> ICityIdExist(int categoryId);
    }
}
