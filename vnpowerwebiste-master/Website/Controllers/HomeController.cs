using LazZiya.ExpressLocalization;
using LazZiya.TagHelpers.Alerts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog.Fluent;
using Website.Models;
using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Business.IRepostitory;
using System.Threading.Tasks;
using System.Globalization;

namespace Website.Controllers
{
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISharedCultureLocalizer _loc;
        public HomeController(ILogger<HomeController> logger, ISharedCultureLocalizer loc)
        {
            _logger = logger;
            _loc = loc;
        }

        public async Task<IActionResult> Index()
        {
         
           
            ViewBag.AllowViewTotal = true;
            return View();
        }

        public IActionResult Privacy()
        {
            // This is a sample to show how to localize 
            // custom messages from the backend.
            // The texts must be defined in ViewsLocalizationResource.xx.resx
            var msg = _loc.GetLocalizedString("Privacy Policy");

            // Use AlertTagHelper to show messages
            // Available options : .Success .Warning .Danger .Info .Dark .Light .Primary .Secondary
            // For more details visit: http://demo.ziyad.info/alert
            TempData.Warning(msg);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        public IActionResult Error404()
        {
            return View();
        }
        public IActionResult OnGetSetCultureCookie(string cltr, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cltr)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );

            return LocalRedirect(returnUrl);
        }
    }
}
