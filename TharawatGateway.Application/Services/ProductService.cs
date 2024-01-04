using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TharawatGateway.Application.IRepositories;
using TharawatGateway.Application.IServices;
using TharawatGateway.Domain.Entities;

namespace TharawatGateway.Application.Services
{
    public class ProductService : IProductService
    {
        #region Fields
        private readonly IProductRepository _productRepository;
        #endregion

        #region Constractors
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region Handles Functions
        public async Task<string> AddAsync(Product product)
        {
            await _productRepository.AddAsync(product);
            return "Success";
        }

        public async Task<string> DeleteAsync(Product product)
        {
            // var trans = _productRepository.BeginTransaction();
            try
            {
                await _productRepository.DeleteAsync(product);
                //await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                // await trans.RollbackAsync();
                Log.Error(ex.Message);
                return "Falied";
            }
        }

        public async Task<string> EditAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
            return "Success";
        }

        public async Task<Product> GetProductByIds(int? id)
        {
            var product = await _productRepository.GetTableNoTracking()
                                                  .Where(d => d.Id.Equals(id))
                                                  .FirstOrDefaultAsync();
            return product;
        }

        public async Task<List<Product>> GetProductsLists()
        {
            var product = await _productRepository.GetProductsListAsync();
            return product;
        }

        public async Task<bool> IsNameExist(string name)
        {
            //Check if the name is Exist Or not
            var product = _productRepository.GetTableNoTracking().Where(x => x.Name.Equals(name)).FirstOrDefault();
            if (product == null) return false;
            return true;
        }

        public async Task<bool> IsNameExistExcludeSelf(string name, int id)
        {
            //Check if the name is Exist Or not
            var product = await _productRepository.GetTableNoTracking().Where(x => x.Name.Equals(name) & !x.Id.Equals(id)).FirstOrDefaultAsync();
            if (product == null) return false;
            return true;
        }

        public async Task<bool> IsProductIdExist(int productId)
        {
            return await _productRepository.GetTableNoTracking().AnyAsync(x => x.Id.Equals(productId));
        }
        #endregion
    }
}
