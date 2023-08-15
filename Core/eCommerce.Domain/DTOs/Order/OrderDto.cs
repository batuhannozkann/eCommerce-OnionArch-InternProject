using eCommerce.Domain.DTOs.Address;
using eCommerce.Domain.DTOs.Products;
using eCommerce.Domain.DTOs.Users;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.DTOs.Order
{
    public class OrderDto
    {
        public long Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Tax { get; set; }
        public decimal Price { get; set; }
        public int ProductCount { get; set; }
        public ICollection<ProductOrderDto> Products { get; set; }
        public UserDto User { get; set; }
        public AddressNoUserDto Address { get; set; }
    }
}
