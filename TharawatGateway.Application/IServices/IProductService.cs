using TharawatGateway.Domain.Entities;

namespace TharawatGateway.Application.IServices
{
    public interface IProductService
    {
        public Task<List<Product>> GetProductsLists();
        public Task<Product> GetProductByIds(int? id);
        public Task<string> AddAsync(Product product);
        public Task<bool> IsNameExist(string name);
        public Task<string> EditAsync(Product product);
        public Task<bool> IsNameExistExcludeSelf(string name, int id);
        public Task<string> DeleteAsync(Product product);
        public Task<bool> IsProductIdExist(int productId);

        /* Task<List<Product>> GetEntitiesLists();
         Task<Product> GetEntitytByIds(int? id);
         Task<string> AddAsync(Product product);
         Task<bool> IsNameExist(string name);
         Task<string> EditAsync(Product product);
         Task<bool> IsNameExistExcludeSelf(string name, int id);
         Task<string> DeleteAsync(Product product);
         Task<bool> IsEntitytIdExist(int productID);
 */
    }
}

