using Business.IRepository;
using Entities.Entities;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.IRepostitory
{
    public interface IMenuRepository : IRepository<NavigationMenu>
    {
        List<MenuResponse> GetMenusByCache(string language);

    }
}
