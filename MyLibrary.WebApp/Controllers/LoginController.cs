using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.WebApp.DTOs;

namespace MyLibrary.WebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoginController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public  IActionResult Index()
        {
            //var user = new UserDto { UserName="Admin", Roles=new List<int> {1,2 }, Id=1 };
            ////var user = userService.GetUserByEmail(model.Email);
            //var claims = new List<Claim>
            //{
            //new Claim("jti", user.Id.ToString(), ClaimValueTypes.Integer, "BookApp") 
            //    };

            //if (!string.IsNullOrEmpty(user.UserName))
            //    claims.Add(new Claim(ClaimTypes.Email, user.UserName, ClaimValueTypes.Email, "BookApp")); //kullanıcının hakkları
            //foreach (var item in user.Roles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, user.UserName, ClaimValueTypes.Integer, "BookApp"));
            //}

            ////create principal for the current authentication scheme
            //var userIdentity = new ClaimsIdentity(claims, "Authentication");
            //var userPrincipal = new ClaimsPrincipal(userIdentity);

            ////set value indicating whether session is persisted and the time at which the authentication was issued
            //var authenticationProperties = new AuthenticationProperties
            //{
            //    IsPersistent = true,
            //    IssuedUtc = DateTime.UtcNow,
            //    ExpiresUtc = DateTime.Now.AddDays(1)
            //};
            ////sign in
            //await _httpContextAccessor.HttpContext.SignInAsync("Authentication", userPrincipal, authenticationProperties);

            return  View();
        }

    }
}
