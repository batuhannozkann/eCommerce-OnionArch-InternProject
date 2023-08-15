using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Entities.Common
{
    public class ShippingProduct:BaseEntity
    {
        public long ShippingId { get; set; }
        public Shipping Shipping { get; set; }
        public long ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public Product Product { get; set; }

    }
}
