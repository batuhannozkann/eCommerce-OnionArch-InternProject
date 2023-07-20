using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Entities
{
    public class LikedProduct
    {
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
