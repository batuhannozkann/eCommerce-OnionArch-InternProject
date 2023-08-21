using eCommerce.Application.Services;
using eCommerce.Domain.DTOs.Categories;
using eCommerce.Domain.DTOs.Products;
using eCommerce.Persistence.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Add(ProductCreateDto product)
        {
            var data = await productService.AddAsync(product);
            return Ok(data);
        }
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var data = productService.GetAll();
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddRange(List<ProductCreateDto> products)
        {
            var data = await productService.AddRangeAsync(products);
            return Ok(data);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllWithCategory()
        {
            var data = productService.GetAllWithCategory();
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(RemoveProductDto removeProductDto)
        {
            var data = await productService.Remove(removeProductDto.Id);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(ProductUpdateDto productDto)
        {
            var data =  await productService.Update(productDto);
            return Ok(data);
        }
    }
}
