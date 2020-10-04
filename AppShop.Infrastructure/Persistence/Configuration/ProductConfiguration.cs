using AppShop.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppShop.Infrastructure.Persistence.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.Property(p => p.Price).HasColumnType<decimal>($"decimal({18},{2})");
            builder.HasKey(p => p.ProductId);
            builder.HasOne(p => p.ProductCategory).WithMany().HasForeignKey("ProductCategoryId");
        }
    }
}
