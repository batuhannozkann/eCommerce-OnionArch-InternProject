﻿using eCommerce.Domain.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.DTOs.Shippings
{
    public class ShippingProductDto
    {
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
    }
}
