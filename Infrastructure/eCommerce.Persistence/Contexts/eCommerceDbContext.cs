using eCommerce.Domain.Entities;
using eCommerce.Domain.Entities.Common;
using eCommerce.Domain.Identity;
using eCommerce.Persistence.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Contexts
{
    public class eCommerceDbContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public eCommerceDbContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<UserRefreshToken> UserRefreshToken { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<ShippingCompany> ShippingCompanies { get; set; }
        public DbSet<MoneyUnit> MoneyUnits { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AddressConfiguration).Assembly);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var item in datas)
            {
                if (item.State == EntityState.Added)
                {
                    item.Entity.CreatedDate = DateTime.UtcNow;
                }
                if (item.State == EntityState.Modified)
                {
                    item.Entity.UpdatedDate = DateTime.UtcNow;
                }
                if (item.State==EntityState.Deleted)
                {
                    item.Entity.IsDeleted = true;
                    item.Entity.DeletedTime = DateTime.UtcNow;
                }

            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
