using eCommerce.Application.Utilities.Results;
using eCommerce.Domain.DTOs.Token;
using eCommerce.Domain.DTOs.Users;
using eCommerce.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Services
{
    public interface IUserService
    {
        Task<IDataResult<AppUser>> CreateUserAsync(CreateUserDto createUserDto);
        Task<IDataResult<EmailConfirmationTokenDto>> GenerateEmailConfirmationTokenAsync(EmailConfirmationTokenCreateDto emailConfirmationTokenCreateDto);
        Task<IDataResult<EmailConfirmationTokenDto>> EmailConfirmationByTokenAsync(EmailConfirmationTokenDto emailConfirmationTokenDto);
        Task<IDataResult<string>> CreateRoleAsync(string role);
        Task<IDataResult<UserWithRoleDto>> CreateUserRolesAsync(CreateUserRoleDto createUserRoleDto);
        IDataResult<List<AppRole>> GetAllRoles();

    }
}
