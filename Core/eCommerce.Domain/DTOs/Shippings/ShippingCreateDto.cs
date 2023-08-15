using eCommerce.Domain.DTOs.Address;
using eCommerce.Domain.DTOs.Order;
using eCommerce.Domain.DTOs.Users;
using eCommerce.Domain.Entities.Common;
using eCommerce.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.DTOs.Shippings
{
    public class ShippingCreateDto
    {
        public string? Description { get; set; }
        public long ShippingCompanyId { get; set; }
        public long OrderId { get; set; }
    }
}
