using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using PROGMAT.DataAccessLayer;
using PROGMAT.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Infrastructure;
using PROGMAT.App_Start;

namespace PROGMAT.Controllers
{
    [AuthorizationFilter]
    public class BooksController : Controller
    {
        private LibraryContext db = new LibraryContext();

        public ActionResult AddBook()
        {
            if (TempData["bookAdded"] != null)
            {
                ViewBag.Message = "Succesfully added";
                TempData.Remove("bookAdded");
            }
            return View();
        }

        public ActionResult ListBook()
        {
            if (TempData["logIn"] != null)
            {
                ViewBag.Message = "Succesfully logged";
                TempData.Remove("logIn");
            }
                return View(db.Book.AsEnumerable());
        }

        [HttpPost]
        public ActionResult EditBook(string searchBy, string search)
        {
            if (searchBy == "Name")
                return View(db.Book.Where(book => book.Name == search || search == null).ToList());
            else
                return View(db.Book.Where(book => book.Author == search || search == null).ToList());
        }

        public ActionResult EditBook()
        {
            return View(db.Book.AsEnumerable());
        }

        [HttpPost]
        public ActionResult AddBookToDatabase(Books book)
        {
            try
            {
                db.Book.Add(book);
                db.SaveChanges();
                TempData["bookAdded"] = "Succesfully added";
                return RedirectToAction("AddBook");
            }
            catch (Exception e)
            {
                return View("Error",new HandleErrorInfo(e, "Books", "AddtBookToDatabase"));
            }
        }

        public ActionResult EditSingleBook(int? id)
        {
            Books book = db.Book.Find(id);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }

        [HttpPost]
        public ActionResult EditBookInDatabase([Bind(Include = "BooksID,Name,Author,Description,DateOfCreation")] Books book)
        {
            try
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EditBook");
            }
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "Books", "EditBookInDatabase"));
            }
        }
    }
}