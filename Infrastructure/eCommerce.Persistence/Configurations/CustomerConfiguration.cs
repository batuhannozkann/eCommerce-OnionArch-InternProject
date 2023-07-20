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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Orders)
                .WithOne(y => y.Customer);
            builder.HasMany(x => x.Addresses)
                .WithOne(x => x.Customer);
            builder.HasMany(x => x.LikedProducts)
                .WithOne(x => x.Customer);
        }
    }
}
