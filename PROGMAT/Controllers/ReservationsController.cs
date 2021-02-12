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
            book.IsReserved = true;
            if (Session["userID"]==null)
            {
                return RedirectToAction("Home", "Home");
            }
            int currentUserID = Convert.ToInt32(Session["userID"].ToString());
            int currentBookID = book.BooksID;
            DateTime dateOfCreation = Convert.ToDateTime(DateTime.Now.ToString("d"));
            Reservations reservation = new Reservations(currentBookID, currentUserID, dateOfCreation);
            db.Reservation.Add(reservation);
            db.SaveChanges();

            return RedirectToAction("ListBook", "Books");
        }
        public ActionResult DeleteReservation(int? idR, int? idB)
        {
            Reservations reservation = db.Reservation.Find(idR);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            if (Session["userID"] == null)
            {
                return RedirectToAction("Home", "Home");
            }
            Books book = db.Book.Find(idB);
            book.IsReserved = false;
            db.Reservation.Remove(reservation);
            db.SaveChanges();

            return RedirectToAction("ListBook", "Books");
        }
        public ActionResult ReservationList()
        {
            return View(db.Reservation.AsEnumerable());
        }
    }
}