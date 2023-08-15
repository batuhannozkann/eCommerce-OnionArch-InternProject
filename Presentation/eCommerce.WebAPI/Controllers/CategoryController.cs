using eCommerce.Application.Services;
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
    }
}
