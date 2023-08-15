using eCommerce.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Configurations
{
    public class ShippingProductConfiguration : IEntityTypeConfiguration<ShippingProduct>
    {
        public void Configure(EntityTypeBuilder<ShippingProduct> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.ShippingId,x.Id });
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Product)
                .WithMany(x => x.ShippingProducts)
                .HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Shipping)
                .WithMany(x => x.ShippingProducts)
                .HasForeignKey(x => x.ShippingId);
        }
    }
}
