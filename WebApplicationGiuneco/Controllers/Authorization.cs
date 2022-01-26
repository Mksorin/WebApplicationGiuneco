using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationGiuneco.Controllers
{
    internal class Authorization : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string username = context.HttpContext.Session.GetString("username");

            if (username == "" || username == null)
            {
                context.Result = new RedirectResult("/Login");
            }
            else
            {
                //altrimenti è loggato
            }
        }
    }
}
