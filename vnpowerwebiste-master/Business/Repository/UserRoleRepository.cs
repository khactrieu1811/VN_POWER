using Business.IRepostitory;
using Entities.DAL;
using Entities.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Repository
{
    public class UserRoleRepository : Repository<IdentityUserRole<string>>, IUserRoleRepository
    {
        public UserRoleRepository(VNPowerContext context) : base(context)
        {

        }

    }
}
