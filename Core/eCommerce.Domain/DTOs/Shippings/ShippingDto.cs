using eCommerce.Domain.Entities.Common;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Domain.DTOs.Address;
using eCommerce.Domain.DTOs.Order;
using eCommerce.Domain.DTOs.Users;
using eCommerce.Domain.DTOs.ShippingCompanies;

namespace eCommerce.Domain.DTOs.Shippings
{
    public class ShippingDto
    {
        public long Id { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime ShippingDate { get; set; }
        public string TrackingNumber { get; set; }
        public string Sender { get; set; }
        public string Destination { get; set; }
        public string Recipient { get; set; }
        public ShippingCompanyDto ShippingCompany { get; set; }
        public ICollection<ShippingProductDto> ShippingProducts { get; set; }
        public AddressNoUserDto Address { get; set; }
        public UserDto User { get; set; }
        public OnlyOrderDto Order { get; set; }
    }
}
