using eCommerce.Application.Services;
using eCommerce.Domain.DTOs.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthenticationService authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> LoginAsync(LoginDto loginDto)
        {
            return Ok(await authenticationService.LoginAsync(loginDto));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateTokenByRefreshToken(CreateTokenByRefreshTokenDto refreshToken)
        {
            return Ok(await authenticationService.CreateTokenByRefreshTokenAsync(refreshToken));
        }

    }
}
