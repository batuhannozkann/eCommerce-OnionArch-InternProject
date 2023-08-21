using eCommerce.Application.Services;
using eCommerce.Domain.DTOs.Token;
using eCommerce.Domain.DTOs.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async  Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            return Ok(await _userService.CreateUserAsync(createUserDto));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> GenerateEmailConfirmationToken(EmailConfirmationTokenCreateDto emailConfirmationTokenCreateDto)
        {
            return Ok(await _userService.GenerateEmailConfirmationTokenAsync(emailConfirmationTokenCreateDto));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> EmailConfirmationByToken([FromQuery]string token,string username)
        {
            return Ok(await _userService.EmailConfirmationByTokenAsync(new EmailConfirmationTokenDto { Token = token, UserName = username }));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRoleAsync(string role)
        {
            return Ok(await _userService.CreateRoleAsync(role));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUserRolesAsync(CreateUserRoleDto createUserRoleDto)
        {
            return Ok(await _userService.CreateUserRolesAsync(createUserRoleDto));
        }
        [HttpGet("[action]")]
        public  IActionResult GetAllRoles()
        {
            return Ok( _userService.GetAllRoles());
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveUser(string userId) 
        {
            return Ok(await _userService.RemoveUser(userId));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddLikedProduct(AddLikedProductDto addLikedProductDto)
        {
            return Ok(await _userService.AddLikedProductAsync(addLikedProductDto));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetLikedProducts(string userId)
        {
            return Ok(await _userService.GetUserLikedProductsAsync(userId));
        }
    }
}
