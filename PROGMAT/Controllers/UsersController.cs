using PROGMAT.DataAccessLayer;
using PROGMAT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROGMAT.Controllers
{
    public class UsersController : Controller
    {
        private LibraryContext db = new LibraryContext();
        [HttpPost]
        public ActionResult CreateUser(Users user)
        {
            if (db.User.Any(users => users.Login == user.Login))
            {
                return RedirectToAction("Home", "Home");
            }
            else if (user.Login!=null || user.Password != null)
            { 
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Home", "Home");
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }
        }
        public ActionResult LogIn(Users user)
        {
            Session["userID"] = user.UsersID;
            Session["userName"] = user.Login;
            return RedirectToAction("ListBook", "Books");
        }
        public ActionResult LogOut()
        {
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Home", "Home"); 
        }
    }
}