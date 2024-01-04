using Microsoft.AspNetCore.Mvc;
using TharawatGateway.Application.IServices;
using TharawatGateway.Domain.Entities;
using TharawatGateway.WebAPI.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TharawatGateway.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVM>>> GetProductsList()
        {
            var products = await _productService.GetProductsLists();
            return Ok(products);
        }

        // GET: api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVM>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIds(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult<ProductVM>> CreateProduct(ProductVM productVM)
        {
            var product = new Product
            {
                // Map properties from ProductVM to Product
                Name = productVM.Name,
                Price = productVM.Price,
                // ... map other properties
            };
            //ProductVM createdProductVM = product;

            var createdProduct = await _productService.AddAsync(product);
            

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        // PUT: api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductVM productVM)
        {
            if (id != productVM.Id)
            {
                return BadRequest();
            }

            var product = new Product
            {
                // Map properties from ProductVM to Product
                Id = productVM.Id,
                Name = productVM.Name,
                Price = productVM.Price,
                // ... map other properties
            };

            var updatedProduct = await _productService.EditAsync(product);
            if (updatedProduct == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = new Product { Id = id };
            var result = await _productService.DeleteAsync(product);

            if (result == "Success")
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
