using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.DTOs.Order
{
    public class ProductOrderCreateDto
    {
        public long ProductId { get; set; }
        public int Quantity { get; set; }

    }
}
