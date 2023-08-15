using eCommerce.Application.Repositories;
using eCommerce.Application.Services;
using eCommerce.Domain.DTOs.Categories;
using eCommerce.Domain.DTOs.Products;
using eCommerce.Domain.Entities;
using eCommerce.Infrastructure.Token;
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
        private ICategoryService _categoryService;
        private IOptions<ConnectionString> options;
        private IProductService _productService;
        private IOptions<CustomTokenOption> tokenOption;
        private IShippingRepository _shippingRepository;

        public TestController(IShippingRepository shippingRepository,ICategoryService categoryService, IOptions<ConnectionString> options, IOptions<CustomTokenOption> tokenOption, IProductService productService)
        {
            _categoryService = categoryService;
            this.options = options;
            _productService = productService;
            this.tokenOption = tokenOption;
            _shippingRepository=shippingRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductCreateDto product)
        {
            var data = await _productService.AddAsync(product);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = _productService.GetAll();
            return Ok(data);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllForAdmin()
        {
            var data = _productService.GetAll(adminAuth:true);
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddRange(List<ProductCreateDto> products)
        {
            var data = await _productService.AddRangeAsync(products);
            return Ok(data);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllProductWithCategory()
        {
            var data = _productService.GetAllWithCategory();
            return Ok(data);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddCategory(CategoryCreateDto category)
        {
            var data = await _categoryService.AddAsync(category);
            return Ok(data);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCategory()
        {
            var data = _categoryService.GetAll();
            return Ok(data);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetTokenOption()
        {
            
            return Ok(tokenOption.Value);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            var data = await _productService.Remove(id);
            return Ok(data);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllShip()
        {
            var data = _shippingRepository.GetAll().ToList();
            return Ok(data);
        }

    }
    

}
