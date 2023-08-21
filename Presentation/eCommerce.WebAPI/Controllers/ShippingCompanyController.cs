using eCommerce.Application.Services;
using eCommerce.Domain.DTOs.ShippingCompanies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingCompanyController : ControllerBase
    {
        private IShippingCompanyService _shippingCompanyService;
        public ShippingCompanyController(IShippingCompanyService shippingCompanyService)
        {
            _shippingCompanyService = shippingCompanyService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddCompany(ShippingCompanyCreateDto shippingCompanyCreateDto)
        {
            return Ok(await _shippingCompanyService.AddAsync(shippingCompanyCreateDto));
        }
        [HttpGet("[action]")]
        public  IActionResult GetAll()
        {
            return Ok(_shippingCompanyService.GetAll());
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCompany(long id)
        {
            return Ok(await _shippingCompanyService.Remove(id));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCompany(ShippingCompanyDto shippingCompanyDto)
        {
            return Ok(await _shippingCompanyService.Update(shippingCompanyDto));
        }
    }
}
