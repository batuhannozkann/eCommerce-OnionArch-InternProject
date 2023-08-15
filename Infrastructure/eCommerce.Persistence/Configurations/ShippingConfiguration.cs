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
    public class ShippingConfiguration : IEntityTypeConfiguration<Shipping>
    {
        public void Configure(EntityTypeBuilder<Shipping> builder)
        {
            builder.HasOne(x => x.ShippingCompany)
                .WithMany(x => x.Shippings);
            builder.HasOne(x => x.User)
                .WithMany(x => x.Shippings);
            builder.HasOne(x => x.Order)
                .WithOne(x => x.Shipping)
                .HasForeignKey<Order>(x=>x.ShippingId);
            builder.HasOne(x => x.Address)
                .WithMany(x => x.Shippings);
                
       
        }
    }
}
