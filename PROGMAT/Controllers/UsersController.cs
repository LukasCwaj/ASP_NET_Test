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
    public class UsersController : Controller
    {
        //Create context
        private LibraryContext db = new LibraryContext();
        
        //Create user and add to database 
        [AllowAnonymous]
        [HttpPost]
        public ActionResult CreateUser(Users user)
        {
            if (db.User.Any(users => users.Login == user.Login))
            {
                TempData["createTheSameUser"] = "The user name is existing, try to use another user name";
                return RedirectToAction("Home", "Home");
            }
            else if (user.Login != null || user.Password != null)
            {
                db.User.Add(user);
                db.SaveChanges();
                TempData["registrationDone"] = "Successfully registered";
                return RedirectToAction("Home", "Home");
            }
            else
            {
                TempData["wrongData"] = "Wrong data try again";
                return RedirectToAction("Home", "Home");
            }
        }

        //Login to session, compare data with data in database, authorize entry to another view
        [AllowAnonymous]
        public ActionResult LogIn(Users user)
        {
            var userDetail = db.User.Where(u => u.Login == user.Login && 
                                           u.Password == user.Password).FirstOrDefault();
            if (userDetail != null)
            {
                Session["userID"] = userDetail.UsersID;
                Session["userName"] = userDetail.Login;
                TempData["logIn"] = "Succesfully logged";
                return RedirectToAction("ListBook", "Books");
            }
            else
                TempData["failLogIn"] = "Wrong user or password";
                return RedirectToAction("Home", "Home");
        }

        //Abandon session and return to "Home" view
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Home", "Home"); 
        }
    }
}