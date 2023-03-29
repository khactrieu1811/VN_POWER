using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Website.Helpers;

namespace Website.Api
{

    public class ControllerBaseApi : ControllerBase
    {
        protected IHttpContextAccessor _httpContextAccessor;
        private string _urlServerImage = string.Empty;
        public ControllerBaseApi(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
     
        protected string GetUrlServerImage()
        {
            _urlServerImage = SettingsConfigHelper.UrlServerImage();
            if (string.IsNullOrEmpty(_urlServerImage))
            {
                _urlServerImage = string.Format("{0}://{1}", _httpContextAccessor.HttpContext.Request.Scheme, _httpContextAccessor.HttpContext.Request.Host.Value);

            }

            return _urlServerImage;
        }
    }
}
