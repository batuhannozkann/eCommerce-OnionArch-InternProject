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
            var data = _productService.AddAsync(product);
            await productRepository.SaveAsync();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Products = productRepository.GetAllAsNoTrackingWithIdentityResolution().ToList();
            Console.WriteLine(options.Value.PostgreSql);
            return Ok(new {Products,options.Value.PostgreSql });
        }

    }
    

}
