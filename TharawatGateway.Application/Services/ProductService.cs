using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TharawatGateway.Application.IServices;
using TharawatGateway.Domain.Entities;
using TharawatGateway.Domain.GeneralRepository;
using TharawatGateway.ResponseLib.BasesHandlers;

namespace TharawatGateway.Application.Services
{
    public class ProductService : IProductService
    {
        #region Fields
        //private readonly IProductRepository _productRepository;
        private readonly IRepository<Product> _productRepo;
        public ResponseHandler responseHandler = new ResponseHandler();

        #endregion

        #region Constractors
        public ProductService(IRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }
        #endregion


        #region Handles Functions
        public async Task<Response<string>> AddAsync(Product product)
         {
             // await _productRepository.AddAsync(product);
             await _productRepo.AddAsync(product);
             return responseHandler.Created("");
         }

         public async Task<string> DeleteAsync(Product product)
         {
             // var trans = _productRepository.BeginTransaction();
             try
             {
                 await _productRepo.DeleteAsync(product);
                 // await _productRepository.DeleteAsync(product);
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
             await _productRepo.UpdateAsync(product);
             //await _productRepository.UpdateAsync(product);
             return "Success";
         }

        public async Task<Product> GetProductByIds(int? id)
         {
             var product = await _productRepo.GetTableNoTracking()
                                                   .Where(d => d.Id.Equals(id))
                                                   .FirstOrDefaultAsync();
            /* var product = await _productRepository.GetTableNoTracking()
                                                   .Where(d => d.Id.Equals(id))
                                                   .FirstOrDefaultAsync();*/
             return product;
         }

         public async Task<Response<List<Product>>> GetProductsLists()
         {
             var product = await _productRepo.GetListAsync();
             //var product = await _productRepository.GetProductsListAsync();
             return responseHandler.Success(product);
         }

        public Task<bool> IsEntitytIdExist(int productID)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsNameExist(string name)
         {
             //Check if the name is Exist Or not
             var product = _productRepo.GetTableNoTracking().Where(x => x.Name.Equals(name)).FirstOrDefault();
             //var product = _productRepository.GetTableNoTracking().Where(x => x.Name.Equals(name)).FirstOrDefault();
             if (product == null) return false;
             return true;
         }

         public async Task<bool> IsNameExistExcludeSelf(string name, int id)
         {
             //Check if the name is Exist Or not
             var product = await _productRepo.GetTableNoTracking().Where(x => x.Name.Equals(name) & !x.Id.Equals(id)).FirstOrDefaultAsync();
             //var product = await _productRepository.GetTableNoTracking().Where(x => x.Name.Equals(name) & !x.Id.Equals(id)).FirstOrDefaultAsync();
             if (product == null) return false;
             return true;
         }

         public async Task<bool> IsProductIdExist(int productId)
         {
             return await _productRepo.GetTableNoTracking().AnyAsync(x => x.Id.Equals(productId));
             //return await _productRepository.GetTableNoTracking().AnyAsync(x => x.Id.Equals(productId));
         }
        #endregion
    }
}
