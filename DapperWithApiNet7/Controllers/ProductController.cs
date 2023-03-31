using DapperWithApiNet7.Abstraction.Services;
using DapperWithApiNet7.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DapperWithApiNet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProductAsync(Product model)
        {
            await _productService.AddAsyncProduct(model);
            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdProductAsync(int id)
        {
            var product = await _productService.GetByIdProduct(id);
            return Ok(product);
        }

        [HttpGet]
        [Route("remove/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            await _productService.RemoveAsyncProduct(id);
            return Ok();
        }
    }
}
