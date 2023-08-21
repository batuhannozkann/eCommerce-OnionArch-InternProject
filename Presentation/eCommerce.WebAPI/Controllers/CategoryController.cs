using eCommerce.Application.Services;
using eCommerce.Domain.DTOs.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService= categoryService;
        }
        [HttpGet("[action]")]
        public IActionResult GetAllWithProducts()
        {
            return Ok(_categoryService.GetAllWithProduct());
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryCreateDto category)
        {
            var data = await _categoryService.AddAsync(category);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var data = _categoryService.GetAll();
            return Ok(data);
        }
        [HttpDelete]
        public IActionResult DeleteCategory(long id)
        {
            return Ok(_categoryService.Remove(id));
        }
        [HttpPut]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            return Ok(await _categoryService.Update(categoryDto));
        }
    }
}
