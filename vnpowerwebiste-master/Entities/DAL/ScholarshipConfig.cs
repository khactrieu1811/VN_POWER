using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DAL
{
    class ScholarshipConfig : IEntityTypeConfiguration<Scholarship>
    {
        public void Configure(EntityTypeBuilder<Scholarship> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasMaxLength(255);
            builder.Property(e => e.CreatedDate).HasDefaultValueSql("GetDate()");
            builder.HasOne(f => f.ScholarshipType).WithMany(f => f.Scholarships).HasForeignKey(f => f.ScholarshipTypeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(f => f.Region).WithMany(f => f.Scholarships).HasForeignKey(f => f.RegionId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(f => f.ApplicationUser).WithMany(f => f.Scholarships).HasForeignKey(f => f.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }

    class ScholarshipTagConfig : IEntityTypeConfiguration<ScholarshipTag>
    {
        public void Configure(EntityTypeBuilder<ScholarshipTag> builder)
        {
            builder.HasKey(pt => new { pt.ScholarshipId, pt.TagId });

            builder.HasOne<Tag>(sc => sc.Tag)
                .WithMany(s => s.ScholarshipTags)
                .HasForeignKey(sc => sc.TagId);


            builder.HasOne<Scholarship>(sc => sc.Scholarship)
                .WithMany(s => s.ScholarshipTags)
                .HasForeignKey(sc => sc.ScholarshipId);

        }
    }

    class ScholarshipTypeConfig : IEntityTypeConfiguration<ScholarshipType>
    {
        public void Configure(EntityTypeBuilder<ScholarshipType> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasMaxLength(255);

        }
    }

    class RegionConfig : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasMaxLength(255);

        }
    }

    class SettingConfig : IEntityTypeConfiguration<Settings>
    {
        public void Configure(EntityTypeBuilder<Settings> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

        }
    }
}
