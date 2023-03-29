using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Website.Models;
using System.Diagnostics;

namespace Website.Controllers
{
    public class MessengerController : Controller
    {
        private readonly ILogger<MessengerController> _logger;

        public MessengerController(ILogger<MessengerController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogDebug("Hello, this is the index!");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
