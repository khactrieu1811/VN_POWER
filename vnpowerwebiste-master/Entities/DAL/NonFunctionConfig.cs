using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DAL
{
    class NonFunctionConfig : IEntityTypeConfiguration<TrackingAgreeCondition>
    {
        public void Configure(EntityTypeBuilder<TrackingAgreeCondition> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasMaxLength(255);
            builder.Property(e => e.UserId).IsRequired().HasMaxLength(450);
            builder.Property(e => e.HISCode).HasMaxLength(100);
        }
    }

    class EmailConfig : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.EmailTo).HasMaxLength(255);
            builder.Property(e => e.Subject).HasMaxLength(255);
            builder.Property(e => e.NameTo).HasMaxLength(255);
        }
    }

    class PartnerConfig : IEntityTypeConfiguration<Partner>
    {
        public void Configure(EntityTypeBuilder<Partner> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasMaxLength(255);
            builder.Property(e => e.Logo).IsRequired();
        }
    }
}
