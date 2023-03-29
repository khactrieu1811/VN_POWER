using Entities.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Website.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(ApplicationUser user,int hourDefault, UserManager<ApplicationUser> roleManager);
        string GenerateAccessTokenCookie(IdentityUser user, int hourDefault, UserManager<IdentityUser> roleManager, HttpContext httpContext);
        string GenerateRefreshToken();

        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
