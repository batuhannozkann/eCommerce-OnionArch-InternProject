using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Constants
{
    public static class ShippingState
    {
        public static readonly string Received = "RECEIVED";
        public static readonly string Preparing = "PREPARING";
        public static readonly string OnDelivery = "ONDELIVERY";
        public static readonly string Delivered = "DELIVERED";
    }
}
