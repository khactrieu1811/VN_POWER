using Microsoft.AspNetCore.Mvc;
using Business.IRepostitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Website.ViewComponents
{
    public class TopMenuViewComponent : ViewComponent
    {
        private readonly IDataAccessService _dataAccessService;
        public TopMenuViewComponent(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
           var userId = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Name)?.Value;
            var Menus = await _dataAccessService.GetPermissionsByRoleIdAsync(userId);
            return View();
        }
    }
}
