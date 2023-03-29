using Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Entities.Entities;

namespace Website.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private int hours = 720;
        private readonly AppSettings _appSettings;
        public TokenService(IConfiguration configuration, IOptions<AppSettings> appSettings)
        {
            _config = configuration;
            _appSettings = appSettings.Value;
        }

        public string GenerateAccessToken(ApplicationUser user, int hourDefault, UserManager<ApplicationUser> roleManager)
        {
            if (hourDefault == 0)
            {
                hourDefault = hours;
            }
            var now = DateTime.Now;
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName.ToString()),
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim("FullName", user.FullName.ToString())

            };
            var roleClaims = roleManager.GetRolesAsync(user);

            foreach (var role in roleClaims.Result.ToList())
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
         
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                NotBefore = now,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(hourDefault),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public string GenerateAccessTokenCookie(IdentityUser user, int hourDefault, UserManager<IdentityUser> roleManager, HttpContext httpContext)
        {
            if (hourDefault == 0)
            {
                hourDefault = hours;
            }
            var now = DateTime.Now;
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Id.ToString())

            };
            var roleClaims = roleManager.GetRolesAsync(user);

            foreach (var role in roleClaims.Result.ToList())
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                NotBefore = now,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(hourDefault),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var rs = tokenHandler.WriteToken(token);
            httpContext.Request.Headers.Remove("Authorization");
            httpContext.Request.Headers.Add("Authorization", "Bearer" + rs) ;
            CookieOptions options = new CookieOptions
            {
                Expires = now.AddHours(hours)
            };
            KeyValuePair<string, string> authoCookie = new KeyValuePair<string, string>("Authorization", rs);
            httpContext.Request.Cookies.Append(authoCookie);
            httpContext.Response.Cookies.Append("x-headertoken",rs, options);
            return rs;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new  SymmetricSecurityKey(key),
                ValidateLifetime = true //in this case, we don't care about the token's expiration date
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (!(securityToken is JwtSecurityToken jwtSecurityToken) || !string.Equals(jwtSecurityToken.Header.Alg, SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                return null;
            }

            return principal;
        }
    }
}
