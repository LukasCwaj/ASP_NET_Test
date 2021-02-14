using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PROGMAT.App_Start;
using PROGMAT.DataAccessLayer;
using PROGMAT.Models;

namespace PROGMAT.Controllers
{
    [AuthorizationFilter]
    public class SearchController : Controller
    {
        private LibraryContext db = new LibraryContext();
        [HttpPost]
        public ActionResult SearchBook(string searchBy, string search)
        {
            if (searchBy=="Name")
            return View(db.Book.Where(book => book.Name == search || search==null).ToList());
            else
                return View(db.Book.Where(book => book.Author == search || search == null).ToList());
        }
        public ActionResult SearchReservation()
        {
            return View();
        }
    }
}