using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Website.Helpers
{
    public static class BotUtils
    {
        public static bool UserIsBot(IHttpContextAccessor accessor)
        {
            if (accessor.HttpContext.Request.Headers["User-Agent"].ToString() != null)
            {
                var userAgent = accessor.HttpContext.Request.Headers["User-Agent"].ToString();
                var botKeywords = new List<string> { "bot", "spider", "google", "yahoo", "search", "crawl", "slurp", "msn", "teoma", "ask.com", "bing", "accoona" };
                return botKeywords.Any(userAgent.Contains);
            }
            return true;
        }
    }
}
