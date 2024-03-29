﻿using eCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Configurations
{
    public class ProductOrderConfiguration : IEntityTypeConfiguration<ProductOrder>
    {
        public void Configure(EntityTypeBuilder<ProductOrder> builder)
        {
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.HasKey(x => new { x.OrderId, x.ProductId,x.Id });
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(y => y.Product)
                .WithMany(x => x.ProductOrders)
                .HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Order)
                .WithMany(y => y.ProductOrders)
                .HasForeignKey(x => x.OrderId);
        }
    }
}
