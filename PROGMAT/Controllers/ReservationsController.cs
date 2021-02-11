using PROGMAT.DataAccessLayer;
using PROGMAT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROGMAT.Controllers
{
    public class ReservationsController : Controller
    {
        private LibraryContext db = new LibraryContext();
        public ActionResult AddReservation(int? id)
        {
            Books book = db.Book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            return RedirectToAction("ListBook", "Books");
        }
        public ActionResult DeleteReservation(int? id)
        {
            return RedirectToAction("AddBook", "Books");
        }
    }
}