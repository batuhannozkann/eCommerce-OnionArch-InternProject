using eCommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Entities
{
    public class Category:BaseEntity
    {
        public int CategoryName { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
