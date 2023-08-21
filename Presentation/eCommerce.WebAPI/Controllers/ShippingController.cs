using eCommerce.Application.Services;
using eCommerce.Domain.DTOs.Shippings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private IShippingService _shippingService;
        public ShippingController(IShippingService shippingService)
        {
            _shippingService = shippingService;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddShipping(ShippingCreateDto shippingCreateDto)
        {
            return Ok(await _shippingService.AddAsync(shippingCreateDto));
        }
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            return Ok(_shippingService.GetAll());
        }
        [HttpPut]
        public async Task<IActionResult> UpdateShipping(ShippingUpdateDto shippingUpdateDto)
        {
            return Ok(await _shippingService.Update(shippingUpdateDto));
        }
        [HttpGet("[action]")]
        public IActionResult GetShippingByTrackingNumber(string trackingNumber)
        {
            return Ok(_shippingService.GetShippingByTrackingNumber(trackingNumber));
        }
        [HttpDelete]

        public async Task<IActionResult> RemoveShipping(long id)
        {
            return Ok(await _shippingService.RemoveAsync(id));
        }
    }
}
