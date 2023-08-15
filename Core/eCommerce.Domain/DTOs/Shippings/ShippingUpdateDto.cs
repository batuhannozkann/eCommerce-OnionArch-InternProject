using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.DTOs.Shippings
{
    public class ShippingUpdateDto
    {
        public long Id { get; set; }
        public string? Description { get; set; }
        public string? State { get; set; }
        public string? Recipient { get; set; }
    }
}
