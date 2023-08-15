using eCommerce.Domain.Entities;
using eCommerce.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.DTOs.Order
{
    public class OrderCreateDto
    {
        public DateTime OrderDate { get; set; }
        public ICollection<ProductOrderCreateDto> Products { get; set; }
        public string UserId { get; set; }
        public int AddressId { get; set; }
    }
}
