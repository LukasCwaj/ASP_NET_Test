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
    public class ReservationsController : Controller
    {
        //Create context
        private LibraryContext db = new LibraryContext();

        //Add reservation basic on id of book from "List Book" view and userID from session
        public ActionResult AddReservation(int? id)
        {
            Books book = db.Book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            book.IsReserved = true;

            int currentUserID = Convert.ToInt32(Session["userID"].ToString());
            int currentBookID = book.BooksID;
            DateTime dateOfCreation = Convert.ToDateTime(DateTime.Now.ToString("d"));

            Reservations reservation = new Reservations(currentBookID, currentUserID, dateOfCreation);

            db.Reservation.Add(reservation);
            db.SaveChanges();
            return RedirectToAction("ListBook", "Books");
        }

        //Delete reservation basic on 
        public ActionResult DeleteReservation(int? idR, int? idB)
        {
            Reservations reservation = db.Reservation.Find(idR);
            if (reservation == null)
            {
                return HttpNotFound();
            }

            Books book = db.Book.Find(idB);
            if (book == null)
            {
                return HttpNotFound();
            }

            book.IsReserved = false;

            db.Reservation.Remove(reservation);
            db.SaveChanges();
            return RedirectToAction("ReservationList", "Reservations");
        }

        //Return "Reservation List" view with records filter by data from "Reservation List" view
        [HttpPost]
        public ActionResult ReservationList(string searchBy, int search)
        {
            if (searchBy == "Book")
                return View(db.Reservation.Where(reservation => reservation.BooksID == search ||
                reservation == null).ToList());
            else
                return View(db.Reservation.Where(reservation => reservation.UsersId == search ||
                reservation == null).ToList());
        }

        //Return "Reservation List" with all data
        public ActionResult ReservationList()
        {
            return View(db.Reservation.AsEnumerable());
        }
    }
}