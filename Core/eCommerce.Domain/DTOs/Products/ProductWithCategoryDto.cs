using eCommerce.Domain.DTOs.Categories;
using eCommerce.Domain.DTOs.Common;
using eCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.DTOs.Products
{
    public class ProductWithCategoryDto:ProductDto
    {
        public List<CategoryDto> Categories { get; set; }
    }
}
