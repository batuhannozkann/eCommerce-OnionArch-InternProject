using eCommerce.Application.Services;
using eCommerce.Domain.DTOs.Address;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }
        [HttpPost]

        public async Task<IActionResult> AddAddressAsync(AddressCreateDto addressCreateDto)
        {
            return Ok(await _addressService.AddAsync(addressCreateDto));
        }
        [HttpGet]
        //api design best practices
        public IActionResult GetAll()
        {
            return Ok(_addressService.GetAll());
        }
        [HttpPut]
        public async Task<IActionResult> Update(AddressUpdateDto addressUpdateDto)
        {
            return Ok(await _addressService.Update(addressUpdateDto));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(await _addressService.Remove(id));
        }
    }
}
