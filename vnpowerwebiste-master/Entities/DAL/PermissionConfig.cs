
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Entities;

namespace Entities.DAL
{

    class PermissionConfig : IEntityTypeConfiguration<RoleMenuPermission>
    {

        public void Configure(EntityTypeBuilder<RoleMenuPermission> builder)
        {

            builder.HasKey(c => new { c.RoleId, c.NavigationMenuId });
        }
    }
    class AspNetUserConfig : IEntityTypeConfiguration<ApplicationUser>
    {

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(e => e.FullName).HasMaxLength(400).IsRequired();
            builder.Property(e => e.Sex).HasMaxLength(50);
        }
    }
  
}
