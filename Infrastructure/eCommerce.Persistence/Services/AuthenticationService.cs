using eCommerce.Application.Repositories;
using eCommerce.Application.Services;
using eCommerce.Application.UnitOfWork;
using eCommerce.Application.Utilities.Results;
using eCommerce.Domain.DTOs.Token;
using eCommerce.Domain.Identity;
using eCommerce.Infrastructure.Utilities.Results;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Services
{
    public class AuthenticationService:IAuthenticationService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly ITokenHandler tokenHandler;
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserRefreshTokenRepository userRefreshTokenRepository;

        public AuthenticationService(UserManager<AppUser> userManager, ITokenHandler tokenHandler, IUnitOfWork unitOfWork, IUserRefreshTokenRepository userRefreshTokenRepository)
        {
            this.userManager = userManager;
            this.tokenHandler = tokenHandler;
            this.unitOfWork = unitOfWork;
            this.userRefreshTokenRepository = userRefreshTokenRepository;
        }

        public async Task<IDataResult<TokenDto>> LoginAsync(LoginDto loginDto)
        {
            if(loginDto==null) throw new ArgumentNullException(nameof(loginDto));
            var user = await userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return new ErrorDataResult<TokenDto>("Email or password is wrong", 400);
            if (await userManager.CheckPasswordAsync(user, loginDto.Password)==false)
            {
                return new ErrorDataResult<TokenDto>("Password is wrong", 400);
            }
            TokenDto token = tokenHandler.CreateToken(user);
            UserRefreshToken? refreshToken = await userRefreshTokenRepository.GetSingleAsync(x => x.UserId == user.Id);
            if(refreshToken == null)
            {
                await userRefreshTokenRepository.AddAsync(new UserRefreshToken
                {
                    UserId = user.Id,
                    Code = token.RefreshToken,
                    Expiration = token.RefreshTokenExpiration
                }
                );
            }
            else
            {
                refreshToken.Expiration = token.RefreshTokenExpiration;
                refreshToken.Code = token.RefreshToken;
            }
            unitOfWork.Commit();
            return new SuccessDataResult<TokenDto>(token, 200);

            
        }
        public async Task<IDataResult<TokenDto>> CreateTokenByRefreshTokenAsync(CreateTokenByRefreshTokenDto refreshTokenDto)
        {
            UserRefreshToken userRefreshToken = await userRefreshTokenRepository.GetSingleAsync(x => x.Code == refreshTokenDto.RefreshToken);
            if (userRefreshToken == null) return new ErrorDataResult<TokenDto>("User refresh token is not found", 400);
            AppUser appUser = await userManager.FindByIdAsync(userRefreshToken.UserId);
            if (appUser == null) return new ErrorDataResult<TokenDto>("User is not found", 400);
            TokenDto token = tokenHandler.CreateToken(appUser);
            userRefreshToken.Code = token.RefreshToken;
            userRefreshToken.Expiration = token.RefreshTokenExpiration;
            unitOfWork.Commit();
            return new SuccessDataResult<TokenDto>(token, 200);

        }
    }
}
