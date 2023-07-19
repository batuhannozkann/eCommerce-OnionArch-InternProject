using eCommerce.Domain.Entities.Common;
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
        public int ProductCount { get; set; }
        public ICollection<Product> Products { get; set; }
        public Customer Customer { get; set; }
        public Address Address { get; set; }
    }
}
