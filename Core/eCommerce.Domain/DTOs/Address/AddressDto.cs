using eCommerce.Domain.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.DTOs.Address
{
    public class AddressDto
    {
        public long Id { get; set; }
        public string FullAddress { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public UserDto User { get; set; }
    }
}
