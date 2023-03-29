using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DAL
{
    class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasMaxLength(255);
            builder.Property(e => e.CreatedDate).HasDefaultValueSql("GetDate()");
            builder.Property(e => e.Price).HasColumnType("decimal(18,0)");
            builder.Property(e => e.PromotionPrice).HasColumnType("decimal(18,0)");
            builder.HasOne(f => f.CategoryProduct).WithMany(f => f.Products).HasForeignKey(f => f.CategoryId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(f => f.ApplicationUser).WithMany(f => f.Products).HasForeignKey(f => f.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
