using PROGMAT.DataAccessLayer;
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
        public ActionResult Reservation()
        {
            return View(db.Book.AsEnumerable());
        }
    }
}