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
    public class LikedProductConfiguration : IEntityTypeConfiguration<LikedProduct>
    {
        public void Configure(EntityTypeBuilder<LikedProduct> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.CustomerId });
            builder.HasOne(x => x.Product)
                .WithMany(y => y.LikedProducts)
                .HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Customer)
                .WithMany(y => y.LikedProducts)
                .HasForeignKey(x => x.CustomerId);
        }
    }
}
