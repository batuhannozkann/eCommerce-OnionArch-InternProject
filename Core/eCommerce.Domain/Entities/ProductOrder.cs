using eCommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Entities
{
    public class ProductOrder:BaseEntity
    {
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; }
    }
}
