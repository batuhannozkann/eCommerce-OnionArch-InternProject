using eCommerce.Domain.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.DTOs.Categories
{
    public class CategoryDto:BaseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
