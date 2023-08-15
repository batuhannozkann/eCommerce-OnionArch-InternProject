using eCommerce.Application.Repositories;
using eCommerce.Application.Services;
using eCommerce.Domain.DTOs.Token;
using eCommerce.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Token
{
    public class TokenHandler : ITokenHandler
    {
        private IConfiguration configuration;
        private IOptions<CustomTokenOption> tokenOption;
        private IUserRefreshTokenRepository userRefreshTokenRepository;
        private UserManager<AppUser> _userManager;

        public TokenHandler(IConfiguration configuration, IOptions<CustomTokenOption> tokenOption, IUserRefreshTokenRepository userRefreshTokenRepository, UserManager<AppUser> userManager)
        {
            this.configuration = configuration;
            this.tokenOption = tokenOption;
            this.userRefreshTokenRepository = userRefreshTokenRepository;
            _userManager = userManager;
        }

        private string CreateRefreshToken()

        {
            var numberByte = new Byte[32];

            using var rnd = RandomNumberGenerator.Create();

            rnd.GetBytes(numberByte);

            return Convert.ToBase64String(numberByte);
        }
        private async Task<IEnumerable<Claim>> GetClaims(AppUser appUser,List<string> audiences)
        {
            var userRoles = await _userManager.GetRolesAsync(appUser);
            var userList = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.NameId,appUser.Id),
                new Claim(JwtRegisteredClaimNames.Email,appUser.Email),
                new Claim(JwtRegisteredClaimNames.Name,appUser.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            userList.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));
            userList.AddRange(userRoles.Select(x => new Claim(ClaimTypes.Role, x)));
            return userList;
        }

        public TokenDto CreateToken(AppUser userApp)
        {

            SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(tokenOption.Value.SecurityKey));
            SigningCredentials signingCredentials = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken securityToken = new(
                claims: GetClaims(userApp, tokenOption.Value.Audience).Result,
                issuer: tokenOption.Value.Issuer,
                expires: DateTime.UtcNow.AddMinutes(tokenOption.Value.AccessTokenExpiration),
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials
                ) ;
            JwtSecurityTokenHandler tokenHandler = new();
            TokenDto token = new TokenDto() {
            AccessTokenExpiration = DateTime.UtcNow.AddMinutes(tokenOption.Value.AccessTokenExpiration),
            AccessToken = tokenHandler.WriteToken(securityToken),
            RefreshToken = CreateRefreshToken(),
            RefreshTokenExpiration = DateTime.UtcNow.AddMinutes(tokenOption.Value.RefreshTokenExpiration) };
            return token;
        }
        
    }
}
