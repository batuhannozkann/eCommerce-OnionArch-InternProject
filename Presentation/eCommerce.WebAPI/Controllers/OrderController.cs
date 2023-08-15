using eCommerce.Application.Services;
using eCommerce.Domain.DTOs.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddOrderAsync(OrderCreateDto orderCreateDto)
        {
            return Ok(await _orderService.AddAsync(orderCreateDto));
        }
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            return Ok( _orderService.GetAll());
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> RemoveOrder(long id)
        {
            return Ok(await _orderService.Remove(id));
        }
    }
}
