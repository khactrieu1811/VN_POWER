using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.DAL
{
    public class AccountInitialize : IAccountInitialize
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountInitialize(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedData()
        {
            var adminRole = new IdentityRole("Admin");
            var userRole = new IdentityRole("User");
            var operatorRole = new IdentityRole("Operator");
            if (!_roleManager.Roles.Any())
            {
                var roles = new List<IdentityRole>() { adminRole, userRole };
                foreach (var role in roles)
                {
                    _roleManager.CreateAsync(role).GetAwaiter().GetResult();
                }
            }
            var master = new ApplicationUser()
            {
                UserName = "master",
                Email = "admin@gmail.com",
                FullName = "Thìn nguyễn",
                EmailConfirmed = true
            };
            if (!_userManager.Users.Any(x=>x.UserName == master.UserName))
            {
                _userManager.CreateAsync(master, "VnPower1@3").GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(master, adminRole.Name).GetAwaiter().GetResult();
            }

            if (_userManager.Users.Any()) return;


            
            var staffUser = new ApplicationUser()
            {
                UserName = "staff1",
                Email = "staff1@gmail.com",
                FullName = "staff nguyễn",
                EmailConfirmed = true
            };
          
            _userManager.CreateAsync(staffUser, "Admin1@34").GetAwaiter().GetResult();
       
            _userManager.AddToRoleAsync(staffUser, userRole.Name).GetAwaiter().GetResult();
          

        }
        public void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<VNPowerContext>();
                context.Database.EnsureCreated();

                var _userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var _roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!_roleManager.RoleExistsAsync("Admin").Result)
                {
                    var role = _roleManager.CreateAsync(new IdentityRole { Name = "Admin" }).Result;
                }
                if (!_roleManager.RoleExistsAsync("User").Result)
                {
                    var role = _roleManager.CreateAsync(new IdentityRole { Name = "User" }).Result;
                }

            
                var permissions = GetPermissions();
                var permissionMenus = GetPermissions();
                foreach (var item in permissionMenus)
                {
                    if (!context.NavigationMenu.Any(n => n.Name == item.Name))
                    {

                        context.NavigationMenu.Add(item);

                    }
                }
                context.SaveChanges();
               
                var _adminRole = _roleManager.Roles.Where(x => x.Name == "Admin").FirstOrDefault();
                foreach (var menurole in permissions)
                {
                    if (!context.RoleMenuPermission.Any(x => x.RoleId == _adminRole.Id && x.NavigationMenuId == menurole.Id))
                    {
                        context.RoleMenuPermission.Add(new RoleMenuPermission() { RoleId = _adminRole.Id, NavigationMenuId = menurole.Id });
                    }

                }

                var _userRole = _roleManager.Roles.Where(x => x.Name == "User").FirstOrDefault();
                foreach (var menurole in permissions.Where(x=>x.Id != new Guid("B30D583A-F7A6-43C3-B54A-0AD2A4952E55")))
                {
                    if (!context.RoleMenuPermission.Any(x => x.RoleId == _userRole.Id && x.NavigationMenuId == menurole.Id))
                    {
                        context.RoleMenuPermission.Add(new RoleMenuPermission() { RoleId = _userRole.Id, NavigationMenuId = menurole.Id });
                    }

                }

                context.SaveChanges();
            }
        }
        private static List<NavigationMenu> GetPermissions()
        {
            return new List<NavigationMenu>()
            {
                new NavigationMenu()
                {
                    Id = new Guid("51DD7D4C-81F6-41B1-A7C0-50D0A18A8EEE"),
                    Name = "Dashboard",
                    Area= "Admins",
                    ControllerName = "Home",
                    ActionName = "Index",
                    ParentMenuId = null,
                    DisplayOrder = 1,
                    Visible = false,
                    IsMenu = true,
                    Image = "fe fe-home",
                    IsAdmin = true
                },
                new NavigationMenu()
                {
                    Id = new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0"),
                    Name = "Danh sách bài viết",
                    Area= "Admins",
                    ControllerName = "Posts",
                    ActionName = "Index",
                    ParentMenuId = null,
                    DisplayOrder = 2,
                    Visible = false,
                    IsMenu = true,
                    Image = "fe fe-document",
                    IsAdmin = true
                },
                   new NavigationMenu()
                {
                    Id = new Guid("2BBA4789-A979-494E-A3CF-C5EE26F23869"),
                    Name = "Quản lý danh mục",
                    Area= "Admins",
                    ControllerName = "Common",
                    ActionName = "GetAll",
                    ParentMenuId = null,
                    DisplayOrder = 7,
                    Visible = false,
                    IsMenu = true,
                    Image = "fe fe-layout",
                    IsAdmin = true
                },
                new NavigationMenu()
                {
                    Id = new Guid("7cd0d373-c57d-4c70-aa8c-22791983fe1c"),
                    Name = "Quản Lý Banner",
                    Area= "Admins",
                    ControllerName = "Banners",
                    ActionName = "Index",
                    ParentMenuId = Guid.Parse("2BBA4789-A979-494E-A3CF-C5EE26F23869"),
                    DisplayOrder = 1,
                    Visible = false,
                    IsMenu = true,
                    Image = "",
                    IsAdmin = true
                },
                 new NavigationMenu()
                {
                    Id = new Guid("F845EE78-4CCA-47C6-9F66-FB6927FAD301"),
                    Name = "Quản lý dịch vụ",
                    Area= "Admins",
                    ControllerName = "Services",
                    ActionName = "Index",
                    ParentMenuId =  Guid.Parse("2BBA4789-A979-494E-A3CF-C5EE26F23869"),
                    DisplayOrder = 2,
                    Visible = false,
                    IsMenu = true,
                    Image = "",
                    IsAdmin = true
                },
                  new NavigationMenu()
                {
                    Id = new Guid("32729E44-67E9-4AD5-B68E-A3101A9DCA69"),
                    Name = "Quản lý Partner",
                    Area= "Admins",
                    ControllerName = "Partners",
                    ActionName = "Index",
                    ParentMenuId =  Guid.Parse("2BBA4789-A979-494E-A3CF-C5EE26F23869"),
                    DisplayOrder = 3,
                    Visible = false,
                    IsMenu = true,
                    Image = "",
                     IsAdmin = true
                },
                  new NavigationMenu()
                {
                    Id = new Guid("EE5F25F7-3383-47A9-8C52-94B26B9C84DD"),
                    Name = "Quản lý Menu",
                    Area= "Admins",
                    ControllerName = "Menus",
                    ActionName = "Index",
                    ParentMenuId =  Guid.Parse("2BBA4789-A979-494E-A3CF-C5EE26F23869"),
                    DisplayOrder = 3,
                    Visible = false,
                    IsMenu = true,
                    Image = "",
                    IsAdmin = true
                },
                 new NavigationMenu()
                {
                    Id = new Guid("27DF364F-C94F-4708-B9A7-4DCDFBF605F0"),
                    Name = "Cài đặt",
                    Area= "Admins",
                    ControllerName = "Settings",
                    ActionName = "Index",
                    ParentMenuId =  Guid.Parse("2BBA4789-A979-494E-A3CF-C5EE26F23869"),
                    DisplayOrder = 5,
                    Visible = false,
                    IsMenu = true,
                    Image = "",
                    IsAdmin = true
                },
                new NavigationMenu()
                {
                    Id = new Guid("B30D583A-F7A6-43C3-B54A-0AD2A4952E55"),
                    Name = "Quản trị",
                    Area= "Admins",
                    ControllerName = "Accounts",
                    ActionName = "getAdminStaff",
                    ParentMenuId = null,
                    DisplayOrder = 8,
                    Visible = false,
                    IsMenu = true,
                    Image = "fe fe-user",
                    IsAdmin = true
                },
                 new NavigationMenu()
                {
                    Id = new Guid("B30D583A-F7A6-43C3-B54A-0AD2A4953E64"),
                    Name = "Quản lý sản phẩm",
                    Area= "Admins",
                    ControllerName = "Products",
                    ActionName = "Index",
                    ParentMenuId = null,
                    DisplayOrder = 6,
                    Visible = false,
                    IsMenu = true,
                    Image = "fe fe-layout",
                    IsAdmin = true
                },
                  new NavigationMenu()
                {
                    Id = new Guid("0238D9D2-F6B1-458C-B960-9E53B1CAD09B"),
                    Name = "Quản lý chuyên mục",
                    Area= "Admins",
                    ControllerName = "Categories",
                    ActionName = "Index",
                    ParentMenuId = null,
                    DisplayOrder = 8,
                    Visible = false,
                    IsMenu = true,
                    Image = "fe fe-user",
                    IsAdmin=true
                  },
                 new NavigationMenu()
                {
                    Id = new Guid("A9219310-03AE-4BD9-BBB5-EDCE119B7D2A"),
                    Name = "Chuyên Mục Sản Phẩm",
                    Area= "Admins",
                    ControllerName = "CategoryProducts",
                    ActionName = "Index",
                    DisplayOrder = 6,
                    Visible = false,
                    IsMenu = true,
                    Image = "fe fe-layout",
                    IsAdmin = true
                }

            };
        }
    }
    public interface IAccountInitialize
    {
        Task SeedData();
        void Initialize(IApplicationBuilder app);
    }
}
