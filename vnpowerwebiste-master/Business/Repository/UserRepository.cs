using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Business.IRepostitory;
using Common;
using Entities.DAL;
using Entities.Entities;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{

    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        private readonly VNPowerContext _context;
        public UserRepository(VNPowerContext context) : base(context)
        {
            _context = context;
        }
        public IQueryable<AdminStaffModel> GetAdminStaffs(string roleId, string status, string search)
        {

            var query = (from a in _context.Users
                         join b in _context.UserRoles on a.Id equals b.UserId
                         join c in _context.Roles on b.RoleId equals c.Id
                         //where !c.Name.Equals("User")
                         select new AdminStaffModel
                         {
                             Id = a.Id,
                             Email = a.Email,
                             FullName = a.FullName,
                             Role = c,
                             UserName = a.UserName,
                             LockoutEnd = a.LockoutEnd,
                             Status = a.LockoutEnabled
                         });
            //var data = query.AsQueryable();
            if (!string.IsNullOrEmpty(roleId))
            {
                query = query.Where(x => x.Role.Id == roleId);
            }
            if (status != null)
            {
                query = query.Where(x => x.Status == ExtensionMethod.ToBool(status));
            }
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.FullName.Contains(search) || x.Email.Contains(search) || x.UserName.Contains(search));
            }
            return query.AsNoTracking();
        }


        public List<IdentityRole> GetAllRole()
        {
            return _context.Roles.ToList();
        }
    }
}
