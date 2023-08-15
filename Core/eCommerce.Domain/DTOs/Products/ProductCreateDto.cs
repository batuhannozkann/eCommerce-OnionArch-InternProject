using eCommerce.Domain.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.DTOs.Products
{
    public class ProductCreateDto 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<long> CategoryIds { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
