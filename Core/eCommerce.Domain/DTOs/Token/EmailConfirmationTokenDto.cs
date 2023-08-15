using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.DTOs.Token
{
    public class EmailConfirmationTokenDto
    {
        public string Token { get; set; }
        public string UserName { get; set; }
    }
}
