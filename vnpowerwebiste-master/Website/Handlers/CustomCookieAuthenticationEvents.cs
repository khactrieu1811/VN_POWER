//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Http.Features;
//using Microsoft.AspNetCore.Routing;
//using Business.IRepostitory;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Website.Handlers
//{
//    public class CustomCookieAuthenticationEvents : CookieAuthenticationEvents
//    {
//        private readonly IDataAccessService _dataAccessService;

//        public CustomCookieAuthenticationEvents(IDataAccessService dataAccessService)
//        {
//            _dataAccessService = dataAccessService;
//        }

//        public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
//        {
//            var userPrincipal = context.Principal;

//            // Look for the LastChanged claim.
//            var lastChanged = (from c in userPrincipal.Claims
//                               where c.Type == "LastChanged"
//                               select c.Value).FirstOrDefault();
//            var check =  await _dataAccessService.GetMenuItemsAsync(context.User, _controller.ToString(), _action.ToString()
//            if (string.IsNullOrEmpty(lastChanged) ||
//                !_userRepository.ValidateLastChanged(lastChanged))
//            {
//                context.RejectPrincipal();

//                await context.HttpContext.SignOutAsync(
//                    CookieAuthenticationDefaults.AuthenticationScheme);
//            }
//            var endpointFeature = context.Features[typeof(IEndpointFeature)] as IEndpointFeature;
//            var endpoint = endpointFeature?.Endpoint;
//            if (endpoint != null)
//            {
//                var routePattern = (endpoint as RouteEndpoint)?.RoutePattern;
//                // ?.RawText;
//                var aa = routePattern;
//                routePattern.RequiredValues.TryGetValue("controller", out var _controller);
//                routePattern.RequiredValues.TryGetValue("action", out var _action);

//                routePattern.RequiredValues.TryGetValue("page", out var _page);
//                routePattern.RequiredValues.TryGetValue("area", out var _area);
//                var name = "x-headertoken";
//                var cookie = context.Request.Cookies[name];
//                var allow = _allowpermissions.Any(x => (x.Controller.Equals(_controller) && x.FullControl && x.Area.Equals(_area ?? ""))
//                || (!x.FullControl && x.Allow.Contains(_action)));
//                if (allow)
//                {
//                    await _next.Invoke(context);
//                    return;
//                }
//                if (cookie != null)
//                    if (!context.Request.Headers.ContainsKey("Authorization"))
//                        context.Request.Headers.Append("Authorization", "Bearer " + cookie);
//                var claimsPrincipal = tokenService.GetPrincipalFromExpiredToken(cookie);
//                if (_controller != null && _action != null &&
//                    await dataAccessService.GetMenuItemsAsync(claimsPrincipal, _controller.ToString(), _action.ToString()))
//                {
//                    await _next.Invoke(context);
//                }

//            }
//        }
//    }
//}
