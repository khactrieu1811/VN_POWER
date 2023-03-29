using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DAL
{
    class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasMaxLength(255);
            builder.Property(e => e.CreatedDate).HasDefaultValueSql("GetDate()");
            builder.HasOne(f => f.Category).WithMany(f => f.Posts).HasForeignKey(f => f.CategoryId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(f => f.ApplicationUser).WithMany(f => f.Posts).HasForeignKey(f => f.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }

    class TagConfig : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasMaxLength(255);
           
        }
    }

    class PostTagConfig : IEntityTypeConfiguration<PostTag>
    {
        public void Configure(EntityTypeBuilder<PostTag> builder)
        {
            builder.HasKey(pt => new { pt.PostId, pt.TagId });

            builder.HasOne<Tag>(sc => sc.Tag)
                .WithMany(s => s.PostTags)
                .HasForeignKey(sc => sc.TagId);


            builder.HasOne<Post>(sc => sc.Post)
                .WithMany(s => s.PostTags)
                .HasForeignKey(sc => sc.PostId);

        }
    }
}
