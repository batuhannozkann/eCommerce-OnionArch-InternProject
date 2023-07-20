using eCommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Entities
{
    public class Product:BaseEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public ICollection<LikedProduct> LikedProducts { get; set; }
        public  ICollection<ProductOrder> ProductOrders { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }


    }
}
