using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DAL
{
  
    class BannerConfig : IEntityTypeConfiguration<Banner>
    { 
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasMaxLength(400).IsRequired();
        }
    }
    class ContactConfig : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.FullName).HasMaxLength(400).IsRequired();
            builder.Property(e => e.Phone).HasMaxLength(200);
            builder.Property(e => e.Email).HasMaxLength(100);
            builder.HasOne(s => s.UserReply)
          .WithMany(g => g.UserReplyContact)
          .HasForeignKey(s => s.UserReplyId);
        }
    }
    class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasMaxLength(450).IsRequired();
            builder.HasOne(d => d.CategoryNavigation)
                 .WithMany(p => p.InverseCategoryNavigation)
                 .HasForeignKey(d => d.ParentId);
        }
    }

    class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasMaxLength(450).IsRequired();
           
        }
    }
}
