using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.DTOs.Users
{
    public class CreateUserRoleDto
    {
        public List<string> Roles { get; set; }
        public string UserId { get; set; }
    }
}
