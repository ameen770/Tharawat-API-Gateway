using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TharawatGateway.BasesHandlers;
using TharawatGateway.Domain.Entities;
using TharawatGateway.Domain.GeneralOprations;

namespace TharawatGateway.Application.IServices
{
    public interface IProductService
    {
        public Task<Response<List<Product>>> GetProductsLists();
        public Task<Product> GetProductByIds(int? id);
        public Task<Response<string>> AddAsync(Product product);
        public Task<bool> IsNameExist(string name);
        public Task<string> EditAsync(Product product);
        public Task<bool> IsNameExistExcludeSelf(string name, int id);
        public Task<string> DeleteAsync(Product product);
        public Task<bool> IsProductIdExist(int productId);
    }
}
