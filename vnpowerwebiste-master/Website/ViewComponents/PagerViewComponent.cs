using Microsoft.AspNetCore.Mvc;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWebsite.ViewComponents
{
    [Area("Admins")]
    [ViewComponent(Name = "PagerView")] //Solution
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View(result));
        }
    }
}
