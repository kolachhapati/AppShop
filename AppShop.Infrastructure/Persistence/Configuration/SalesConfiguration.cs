using AppShop.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppShop.Infrastructure.Persistence.Configuration
{
    public class SalesConfiguration : IEntityTypeConfiguration<SalesEntity>
    {
        public void Configure(EntityTypeBuilder<SalesEntity> builder)
        {
            builder.HasIndex(prop => prop.OrderGroup).IsUnique();
            builder.Property(prop => prop.OrderGroup).IsRequired();
            builder.Property(prop => prop.Total).HasColumnType<decimal>($"decimal({18},{2})");
            builder.HasKey(key => key.SalesId);
        }
    }
}
