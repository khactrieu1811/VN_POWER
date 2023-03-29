using Business.IRepository;
using Entities.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.IRepostitory
{
    public interface IUserRoleRepository : IRepository<IdentityUserRole<string>>
    {
    }
}
