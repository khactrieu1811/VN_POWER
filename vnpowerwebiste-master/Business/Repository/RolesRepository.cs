using Business.IRepostitory;
using Entities.DAL;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Repository
{
    public class RolesRepository : Repository<ApplicationRole>, IRolesRepository
    {
        public RolesRepository(VNPowerContext context) : base(context)
        {

        }
    }
}
