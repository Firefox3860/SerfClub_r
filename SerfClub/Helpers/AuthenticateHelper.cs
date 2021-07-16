using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SerfClub.Helpers
{
    public class AuthenticateHelper
    {
        public static async Task Authenticate(string userName, bool rememberMe, HttpContext httpContext)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            var props = new AuthenticationProperties();
            if (rememberMe)
            {
                props.IsPersistent = rememberMe;
                props.ExpiresUtc = DateTime.Now.AddHours(2);
            }
            else
            {

                props.ExpiresUtc = DateTime.Now.AddMinutes(30);
            }
            // установка аутентификационных куки
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id), props);
        }
    }
}
