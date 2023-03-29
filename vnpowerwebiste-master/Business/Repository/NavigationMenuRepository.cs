using Business.IRepostitory;
using Entities.DAL;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Repository
{
    public class NavigationMenuRepository : Repository<NavigationMenu>, INavigationMenuRepository
    {
        public NavigationMenuRepository(VNPowerContext context) : base(context)
        {

        }
    }
}
