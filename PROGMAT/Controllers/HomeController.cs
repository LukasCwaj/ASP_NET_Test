using PROGMAT.DataAccessLayer;
using PROGMAT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROGMAT.Controllers
{
    public class HomeController : Controller
    {
        private LibraryContext db = new LibraryContext();

        public ActionResult Home()
        {
            if (TempData["failLogIn"] != null)
            {
                ViewBag.Message = "Wrong user or password";
                TempData.Remove("failLogIn");
            }
            return View();
        }
    }
}