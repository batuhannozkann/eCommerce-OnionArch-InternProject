using eCommerce.Domain.Entities.Common;
using eCommerce.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Entities
{
    public class Order:BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Tax { get; set; }
        public decimal Price { get; set; }
        public int ProductCount { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; }
        public Shipping? Shipping { get; set; }
        public long? ShippingId { get; set; }
        public AppUser User { get; set; }
        public Address Address { get; set; }
    }
}
