using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Sipaz.Core.Entities;
using Sipaz.Core.Interfaces;

namespace Sipaz.Web.Controllers
{
    public class AccountController : Controller
    {
        public IUser _user;
        public AccountController(IUser user)
        {
            _user = user;
        }
      
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserModel model)
        {
            // username = anet

            var user = _user.GetUser(model.Email).FirstOrDefault();
            if (user!=null)
            {
                var userClaims = new List<Claim>()
                {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email,user.Mobile),
                 };

                var grandmaIdentity =
                    new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                HttpContext.SignInAsync(userPrincipal);
                return Json(true);
            }
            else
            {
                return Json(false);
            }

            
        }

        [HttpPost]
        public IActionResult Register(UserModel model)
        {
            Result result = _user.Register(model);
            if(result.IsSuccess)
            {
                var userClaims = new List<Claim>()
                {
                new Claim(ClaimTypes.Name, model.Name),
                new Claim(ClaimTypes.Email,model.Mobile),
                 };

                var grandmaIdentity =
                    new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                HttpContext.SignInAsync(userPrincipal);
            }
            return Json(new { result = result });
        }


        [HttpPost("token")]
        public IActionResult GetToken(AuthenticateRequest model)
        {
            var response = _user.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
    }
}
