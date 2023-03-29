using Business.IRepostitory;
using Entities.DAL;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Repository
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(VNPowerContext context) : base(context)
        {

        }

    }
}
