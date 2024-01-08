using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TharawatGateway.Domain.Entities;

namespace TharawatGateway.Application.IServices
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetCategoriesLists();
        public Task<Category> GetCategoryByIds(int? id);
        public Task<string> AddAsync(Category category);
        public Task<bool> IsNameExist(string name);
        public Task<string> EditAsync(Category category);
        public Task<bool> IsNameExistExcludeSelf(string name, int id);
        public Task<string> DeleteAsync(Category category);
        public Task<bool> IsCategoryIdExist(int categoryId);
    }
}
