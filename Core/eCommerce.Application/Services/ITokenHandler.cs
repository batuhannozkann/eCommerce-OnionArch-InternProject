using eCommerce.Domain.DTOs.Token;
using eCommerce.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Services
{
    public interface ITokenHandler
    {
        TokenDto CreateToken(AppUser userApp);
    }
}
