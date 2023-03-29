using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DAL
{
    class CategoryProductConfig : IEntityTypeConfiguration<CategoryProduct>
    {
        public void Configure(EntityTypeBuilder<CategoryProduct> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasMaxLength(255).IsRequired();
            builder.HasOne(d => d.CategoryProductNavigation)
                 .WithMany(p => p.InverseCategoryProductNavigation)
                 .HasForeignKey(d => d.ParentId);
        }
    }

}
