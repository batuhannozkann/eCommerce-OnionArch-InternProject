using eCommerce.Domain.Constants;
using eCommerce.Domain.Entities.Common;
using eCommerce.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Entities
{
    public class Shipping:BaseEntity
    {
        public string State { get; set; } = ShippingState.Received;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime ShippingDate { get; set; }
        public string TrackingNumber { get; set; }
        public string Sender { get; set; }
        public string Destination { get; set; }
        public string? Recipient { get; set; }
        public ShippingCompany ShippingCompany { get; set; }
        public ICollection<ShippingProduct> ShippingProducts { get; set; }
        public Address Address { get; set; }
        public AppUser User { get; set; }
        public Order Order { get; set; }
        public long OrderId { get; set; }
    }
}
