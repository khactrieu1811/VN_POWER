using Business.IRepostitory;
using Entities.DAL;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Repository
{
    public class RoleMenuPermissionRepository : Repository<RoleMenuPermission>, IRoleMenuPermissionRepository
    {
        public RoleMenuPermissionRepository(VNPowerContext context) : base(context)
        {

        }
    }
}
