using AppShop.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppShop.Infrastructure.Persistence.Configuration
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategoryEntity>
    {

        public void Configure(EntityTypeBuilder<ProductCategoryEntity> builder)
        {
            builder.HasKey(prop => prop.ProductCategoryId);
        }
    }
}
