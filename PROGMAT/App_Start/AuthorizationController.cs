using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROGMAT.App_Start
{
    public class AuthorizationFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // Don't check for authorization as AllowAnonymous filter is applied to the action or controller 
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined
                (typeof(AllowAnonymousAttribute), true))
            { 
                return;
            }

            // Check for authorization  
            if (HttpContext.Current.Session["UserName"] == null)
            {
                filterContext.Result = new RedirectResult("~/Home/Home");
            }
        }
    }
}