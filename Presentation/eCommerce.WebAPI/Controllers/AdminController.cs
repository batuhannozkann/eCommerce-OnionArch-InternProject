using eCommerce.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    
    public class AdminController : ControllerBase
    {
        private IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
            
        }
        [HttpGet("[action]")]
        public IActionResult GetAllProduct()
        {
            return Ok(_adminService.GetAllProduct());
        }
        [HttpGet("[action]")]
        public IActionResult GetAllCategory()
        {
            return Ok(HttpContext.Request.Headers);
        }
        [HttpGet("[action]")]
        public IActionResult GetAllOrder()
        {
            return Ok(_adminService.GetAllOrder());
        }
        [HttpGet("[action]")]
        public IActionResult GetAllAddress()
        {
            return Ok(_adminService.GetAllAddress());
        }
        [HttpGet("[action]")]
        public IActionResult GetAllUser()
        {
            return Ok(_adminService.GetAllUser());
        }
        [HttpGet("[action]")]
        public IActionResult GetAllShipping()
        {
            return Ok(_adminService.GetAllShipping());
        }
        [HttpGet("[action]")]
        public IActionResult GetAllShippingCompany()
        {
            return Ok(_adminService.GetAllShippingCompany());
        }
        [HttpGet("[action]")]
        public IActionResult GetDolar()
        {
            return Ok(_adminService.GetTcmb());
        }

    }
}
