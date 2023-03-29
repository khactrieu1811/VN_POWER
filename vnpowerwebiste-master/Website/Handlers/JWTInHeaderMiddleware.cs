using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using Business.IRepostitory;
using Common;
using Website.Helpers;
using Website.Models;
using Website.Services;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Website.Handlers
{
    public class JWTInHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly List<Permission> _allowpermissions;
        private readonly AppSettings _appSettings;
        public JWTInHeaderMiddleware(RequestDelegate next, IOptions<List<Permission>> defaultPermission
          , IOptions<AppSettings> appSettings
          )
        {
            _next = next;
            _allowpermissions = defaultPermission.Value;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IDataAccessService dataAccessService)
        {
           
            var endpointFeature = context.Features[typeof(IEndpointFeature)] as IEndpointFeature;
            var endpoint = endpointFeature?.Endpoint;
            if (endpoint != null)
            {
                var routePattern = (endpoint as RouteEndpoint)?.RoutePattern;
                // ?.RawText;
                routePattern.RequiredValues.TryGetValue("controller", out var _controller);
                routePattern.RequiredValues.TryGetValue("action", out var _action);

                routePattern.RequiredValues.TryGetValue("page", out var _page);
                routePattern.RequiredValues.TryGetValue("area", out var _area);
                var name = "x-headertoken";
                var cookie = context.Request.Cookies[name];
                //var allow = _allowpermissions.Any(x => (x.Controller.Equals(_controller) && x.FullControl && x.Area.Equals(_area??""))
                //|| (!x.FullControl && x.Allow.Contains(_action)));
                //if (allow)
                //{
                //    await _next.Invoke(context);
                //    return;
                //}
                if (cookie != null)
                    if (!context.Request.Headers.ContainsKey("Authorization"))
                        context.Request.Headers.Append("Authorization", "Bearer " + cookie);

                //var user = (ClaimsIdentity)context.User.Identity;
                //var claimsPrincipal = JwtHelper.GetPrincipalFromExpiredToken(cookie, _appSettings);
                //if (_controller != null && _action != null &&
                //    await dataAccessService.GetMenuItemsAsync(claimsPrincipal, _controller.ToString(), _action.ToString()))
                //{
                //    await _next.Invoke(context);
                //}
                await _next.Invoke(context);
            }
         
        }
    }
}
