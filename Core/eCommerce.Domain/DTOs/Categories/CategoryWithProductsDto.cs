using eCommerce.Domain.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.DTOs.Categories
{
    public class CategoryWithProductsDto:CategoryDto
    {
        public List<ProductDto> Products { get; set; }
    }
}
