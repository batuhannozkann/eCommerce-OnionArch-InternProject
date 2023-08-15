using eCommerce.Application.Utilities.Results;
using eCommerce.Domain.DTOs.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Services
{
    public interface IAuthenticationService
    {
        Task<IDataResult<TokenDto>> LoginAsync(LoginDto loginDto);
        Task<IDataResult<TokenDto>> CreateTokenByRefreshTokenAsync(CreateTokenByRefreshTokenDto refreshTokenDto);
    }
}
