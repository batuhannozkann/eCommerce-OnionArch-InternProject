using AutoMapper;
using eCommerce.Application.Services;
using eCommerce.Application.Utilities.Results;
using eCommerce.Domain.DTOs.Token;
using eCommerce.Domain.DTOs.Users;
using eCommerce.Domain.Identity;
using eCommerce.Infrastructure.Utilities.Results;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace eCommerce.Persistence.Services
{
    public class UserService:IUserService
    {
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;
        private IMapper _mapper;

        public UserService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<IDataResult<AppUser>> CreateUserAsync(CreateUserDto createUserDto)
        {
            AppUser user = _mapper.Map<AppUser>(createUserDto);
            var result = await _userManager.CreateAsync(user, createUserDto.Password);
            if (result.Succeeded) { return new SuccessDataResult<AppUser>(user, 200);}
            else{return new ErrorDataResult<AppUser>(result.Errors.Select(x=>x.Description).ToList(), 400);}
        }
        public async Task<IDataResult<EmailConfirmationTokenDto>> GenerateEmailConfirmationTokenAsync(EmailConfirmationTokenCreateDto emailConfirmationTokenCreateDto)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(emailConfirmationTokenCreateDto.Email);
            if (appUser == null) return new ErrorDataResult<EmailConfirmationTokenDto>("User is not found", 400);
            string token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            MailMessage mailMessage = new MailMessage();
            mailMessage.IsBodyHtml = true;
            mailMessage.To.Add(appUser.Email);
            mailMessage.From = new MailAddress("ekutuphanemvc@gmail.com", "Email Validation", System.Text.Encoding.UTF8);
            mailMessage.Subject = "Email Validation";
            mailMessage.Body = $"<a target=\"_blank\" href=\"https://localhost:44385/api/User/EmailConfirmationByToken?token={token}&username={appUser.UserName}\">Emailinizi onaylamak için tıklayınız.</a>";
            SmtpClient smtp = new();
            smtp.Credentials = new NetworkCredential("ekutuphanemvc@gmail.com", "wakqorhijngdxddx");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Send(mailMessage);
            return new SuccessDataResult<EmailConfirmationTokenDto>(token, 200);
            //headerda user id parametresi varsa alınacak 
        }
        public async Task<IDataResult<EmailConfirmationTokenDto>> EmailConfirmationByTokenAsync(EmailConfirmationTokenDto emailConfirmationTokenDto)
        {
            AppUser appUser = await _userManager.FindByNameAsync(emailConfirmationTokenDto.UserName);
            if (appUser == null) return new ErrorDataResult<EmailConfirmationTokenDto>("User has not found",400);
            var result = await _userManager.ConfirmEmailAsync(appUser, emailConfirmationTokenDto.Token);
            if (appUser.EmailConfirmed == true) return new ErrorDataResult<EmailConfirmationTokenDto>("Email has already confirmed", 400);
            if(result.Succeeded)
            {
                return new SuccessDataResult<EmailConfirmationTokenDto>("Email has confirmed", 200);
            }
            else
            {
                return new ErrorDataResult<EmailConfirmationTokenDto>("Email has not confirmed", 400);
            }

        }
        public async Task<IDataResult<string>> CreateRoleAsync(string role)
        {
            var process = await _roleManager.CreateAsync(new AppRole { Name = role });
            if (!process.Succeeded) return new ErrorDataResult<string>("Role has not created", 400);
            return new SuccessDataResult<string>(role, 200); 
        }
        public async Task<IDataResult<UserWithRoleDto>> CreateUserRolesAsync(CreateUserRoleDto createUserRoleDto)
        {
            var user = await _userManager.FindByIdAsync(createUserRoleDto.UserId);
            if (user == null) return new ErrorDataResult<UserWithRoleDto>("User has not found",400);
            List<string> roles = new List<string>();
            foreach(string role in createUserRoleDto.Roles)
            {
                if(await _roleManager.RoleExistsAsync(role)) roles.Add(role);
                else
                {
                    return new ErrorDataResult<UserWithRoleDto>($"{role} role does not exist", 400);
                }
         
            }
            var process = await _userManager.AddToRolesAsync(user,roles);
            if (process.Succeeded) {
                UserWithRoleDto dto = _mapper.Map<UserWithRoleDto>(user);
                dto.Roles=_userManager.GetRolesAsync(user).Result.ToList();
                return new SuccessDataResult<UserWithRoleDto>(dto, 200);
                    
            }
            return new ErrorDataResult<UserWithRoleDto>("Role has not added",400);
        }
        public  IDataResult<List<AppRole>> GetAllRoles()
        {
            var roles = _roleManager.Roles.ToList();
            if (roles == null || roles.Count == 0) return new ErrorDataResult<List<AppRole>>("Role has not found", 400);
            return new SuccessDataResult<List<AppRole>>(roles, 200);
            
            
        }
    }
}
