using PROGMAT.App_Start;
using PROGMAT.DataAccessLayer;
using PROGMAT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROGMAT.Controllers
{
    [AuthorizationFilter]
    public class HomeController : Controller
    {
        //Create context
        private LibraryContext db = new LibraryContext();

        //Return "Home" view
        [AllowAnonymous]
        public ActionResult Home()
        {
            if (TempData["failLogIn"] != null)
            {
                ViewBag.Message = "Wrong user or password";
                TempData.Remove("failLogIn");
            }
            else if (TempData["createTheSameUser"] != null)
            {
                ViewBag.Message = "The user name is existing, try to use another user name";
                TempData.Remove("createTheSameUser");
            }
            else if (TempData["wrongData"] != null)
            {
                ViewBag.Message = "Wrong data try again";
                TempData.Remove("wrongData");
            }
            else if(TempData["registrationDone"] != null)
            {
                ViewBag.Message = "Successfully registered";
                TempData.Remove("registrationDone");
            }
            return View();
        }
    }
}