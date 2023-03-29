using Business.IRepostitory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Website.Handlers
{
	public class AuthorizationRequirement : IAuthorizationRequirement { }

	public class PermissionHandler : AuthorizationHandler<AuthorizationRequirement>
	{
		private readonly IDataAccessService _dataAccessService;

		public PermissionHandler(IDataAccessService dataAccessService)
		{
			_dataAccessService = dataAccessService;
		}

		protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizationRequirement requirement)
		{
			
			if (context.Resource is RouteEndpoint endpoint)
			{
				endpoint.RoutePattern.RequiredValues.TryGetValue("controller", out var _controller);
				endpoint.RoutePattern.RequiredValues.TryGetValue("action", out var _action);

				endpoint.RoutePattern.RequiredValues.TryGetValue("page", out var _page);
				endpoint.RoutePattern.RequiredValues.TryGetValue("area", out var _area);

				//var isAuthenticated = context.User.Identity.IsAuthenticated;
				var isAuthenticated = context.User.Identity.IsAuthenticated;
				if (isAuthenticated && _controller != null && _action != null
					//&& await _dataAccessService.GetMenuItemsAsync(context.User, _controller.ToString(), _action.ToString())
					)
				{
					context.Succeed(requirement);
				}
				
			}
		}
	}
}
