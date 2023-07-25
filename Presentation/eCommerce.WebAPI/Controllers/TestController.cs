using eCommerce.Application.Repositories;
using eCommerce.Application.Services;
using eCommerce.Domain.DTOs.Products;
using eCommerce.Domain.Entities;
using eCommerce.Persistence.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace eCommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IProductRepository productRepository;
        private IOptions<ConnectionString> options;
        private IProductService _productService;

        public TestController(IProductRepository productRepository, IOptions<ConnectionString> options, IProductService productService)
        {
            this.productRepository = productRepository;
            this.options = options;
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductCreateDto product)
        {
            var data = await _productService.AddAsync(product);
            await productRepository.SaveAsync();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = _productService.GetAll();
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddRange(List<ProductCreateDto> products)
        {
            var data = await _productService.AddRangeAsync(products);
            return Ok(data);
        }

    }
    

}
