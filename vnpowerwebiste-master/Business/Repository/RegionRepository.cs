using Business.IRepostitory;
using Entities.DAL;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Repository
{
    public class RegionRepository : Repository<Region>, IRegionRepository
    {
        public RegionRepository(VNPowerContext context) : base(context)
        {

        }
    }
}
