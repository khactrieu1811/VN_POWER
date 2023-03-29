using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities.DAL
{
    public class VNPowerContext : IdentityDbContext<ApplicationUser>
    {

        #region AspNetIdentity
        // public DbSet<ApplicationUser> ApplicationUsers { get; set; } //2
        // public DbSet<ApplicationRole> ApplicationRoles { get; set; } //2
        public DbSet<RoleMenuPermission> RoleMenuPermission { get; set; }

        public DbSet<NavigationMenu> NavigationMenu { get; set; }


        #endregion

        #region Common
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Service> Services { get; set; }
        #endregion
        #region Post
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<TrackingAgreeCondition> TrackingAgreeConditions { get; set; }

        #endregion

        #region Scholarship
        public DbSet<Scholarship> Scholarships { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<ScholarshipTag> ScholarshipTags { get; set; }
        public DbSet<ScholarshipType> ScholarshipTypes { get; set; }
        public DbSet<Settings> Settings { get; set; }
        #endregion
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryProduct> CategoryProducts {get; set;}
        public VNPowerContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);   
            
            #region Permission
            modelBuilder.ApplyConfiguration(new PermissionConfig());
            modelBuilder.ApplyConfiguration(new AspNetUserConfig());
         //   modelBuilder.ApplyConfiguration(new AspNetUserRoleConfig());
            #endregion
                   
            #region Post
            modelBuilder.ApplyConfiguration(new PostConfig());
            modelBuilder.ApplyConfiguration(new PostTagConfig());
            modelBuilder.ApplyConfiguration(new TagConfig());
            #endregion

            modelBuilder.ApplyConfiguration(new NonFunctionConfig());
            modelBuilder.ApplyConfiguration(new EmailConfig());
            modelBuilder.ApplyConfiguration(new PartnerConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new ContactConfig());
            modelBuilder.ApplyConfiguration(new ServiceConfig());
            modelBuilder.ApplyConfiguration(new ScholarshipConfig());
            modelBuilder.ApplyConfiguration(new ScholarshipTagConfig());
            modelBuilder.ApplyConfiguration(new ScholarshipTypeConfig());
            modelBuilder.ApplyConfiguration(new RegionConfig());
            modelBuilder.ApplyConfiguration(new SettingConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new CategoryProductConfig());
        }
    }
}
