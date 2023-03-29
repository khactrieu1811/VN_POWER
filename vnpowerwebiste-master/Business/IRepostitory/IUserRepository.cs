using Microsoft.AspNetCore.Identity;
using Business.IRepository;
using Entities.Entities;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IRepostitory
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        IQueryable<AdminStaffModel> GetAdminStaffs(string roleId, string status, string search);
        List<IdentityRole> GetAllRole();
    }
}
