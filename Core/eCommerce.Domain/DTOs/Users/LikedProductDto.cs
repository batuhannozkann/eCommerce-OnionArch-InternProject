using eCommerce.Domain.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.DTOs.Users
{
    public class LikedProductDto
    {
        public UserDto User { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
