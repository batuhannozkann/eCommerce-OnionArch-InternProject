using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.DTOs.Order
{
    public class OnlyOrderDto
    {
        public long Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Tax { get; set; }
        public decimal Price { get; set; }
        public int ProductCount { get; set; }
        public ICollection<ProductOrderDto> Products { get; set; }
    }
}
