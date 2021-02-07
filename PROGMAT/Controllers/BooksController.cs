using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using PROGMAT.DataAccessLayer;
using PROGMAT.Models;

namespace PROGMAT.Controllers
{
    public class BooksController : Controller
    {
        private LibraryContext db = new LibraryContext();
        public ActionResult AddBook()
        {
            return View();
        }
        public ActionResult EditBook()
        {
            return View();
        }
        public ActionResult ListBook()
        {
            return View(db.Book.AsEnumerable());
        }
        [HttpPost]
        public ActionResult AddBookToDatabase(Books book)
        {
            book.DateOfCreation = DateTime.Now;
            db.Book.Add(book);
            db.SaveChanges();
            return RedirectToAction("AddBook");
        }
    }
}