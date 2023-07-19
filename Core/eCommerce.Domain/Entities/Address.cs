using eCommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Entities
{
    public class Address:BaseEntity
    {
        public string FullAddress { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public Customer Customer { get; set; }
    }
}
