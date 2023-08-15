using eCommerce.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasIndex(x=>x.UserName).IsUnique();
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Orders)
                .WithOne(y => y.User);
            builder.HasMany(x => x.Addresses)
                .WithOne(x => x.User);
            builder.HasMany(x => x.LikedProducts)
                .WithOne(x => x.User);
            builder.HasMany(x => x.Shippings)
                .WithOne(x => x.User);
        }
    }
}
