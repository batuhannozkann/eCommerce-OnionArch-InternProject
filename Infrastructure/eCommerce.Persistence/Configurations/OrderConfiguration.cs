using eCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Shipping)
                .WithOne(x => x.Order).HasForeignKey<Shipping>(x => x.OrderId);
            builder.HasIndex(x => x.ShippingId).IsUnique();
        }
    }
}
