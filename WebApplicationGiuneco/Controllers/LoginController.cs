using LoginAndAuth.Models;
using LoginAndAuth.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAndAuth.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProcessLogin(UserModel userModel)
        {
            SecurityService securityService = new SecurityService();

            if (userModel.username != "" && userModel.password !="" && securityService.IsValid(userModel))
            {
                HttpContext.Session.SetString("username", userModel.username);
                HttpContext.Session.SetInt32("UserID", userModel.ID);

                return View("LoginSuccess", userModel);
            }
            {
                return View("LoginFailure", userModel);
            }
        }
    }
}
