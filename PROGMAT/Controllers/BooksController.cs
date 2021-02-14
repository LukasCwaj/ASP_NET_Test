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
        //Create context
        private LibraryContext db = new LibraryContext();

        //Return "Add Book" view
        public ActionResult AddBook()
        {
            if (TempData["bookAdded"] != null)
            {
                ViewBag.Message = "Succesfully added";
                TempData.Remove("bookAdded");
            }
            if (TempData["addBookWrongData"] != null)
            {
                ViewBag.Message = "Fill data in all fields";
                TempData.Remove("addBookWrongData");
            }
            return View();
        }

        //Return "List Book" view
        public ActionResult ListBook()
        {
            if (TempData["logIn"] != null)
            {
                ViewBag.Message = "Succesfully logged";
                TempData.Remove("logIn");
            }
            return View(db.Book.AsEnumerable());
        }

        //Return "Edit Book" view with records filter by data from view "Edit Book"
        [HttpPost]
        public ActionResult EditBook(string searchBy, string search)
        {
            if (searchBy == "Name")
                return View(db.Book.Where(book => book.Name == search || search == null).ToList());
            else
                return View(db.Book.Where(book => book.Author == search || search == null).ToList());
        }

        //Return "Edit Book" view with list of all books
        public ActionResult EditBook()
        {
            if (TempData["bookEdited"] != null)
            {
                ViewBag.Message = "Succesfully edited";
                TempData.Remove("bookEdited");
            }
            return View(db.Book.AsEnumerable());
        }

        //Add book specify in "Add Book" view to database 
        [HttpPost]
        public ActionResult AddBookToDatabase(Books book)
        {
            try
            {
                if (book.Name != null && book.Author != null && book.Description != null 
                    && book.DateOfCreation != null)
                {
                    db.Book.Add(book);
                    db.SaveChanges();
                    TempData["bookAdded"] = "Succesfully added";
                    return RedirectToAction("ListBook");
                }
                else
                {
                    TempData["addBookWrongData"] = "Fill data in all fields";
                    return RedirectToAction("AddBook");
                }
            }
            catch (Exception e)
            {
                return View("Error",new HandleErrorInfo(e, "Books", "AddtBookToDatabase"));
            }
        }

        //Return "Edit Single Book" view after button click on "Edit Book" list
        public ActionResult EditSingleBook(int? id)
        {
            Books book = db.Book.Find(id);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }

        //Edit book specify in "Edit Single Book" view to database
        [HttpPost]
        public ActionResult EditBookInDatabase(Books book)
        {
            try
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                TempData["bookEdited"] = "Succesfully edited";
                return RedirectToAction("EditBook");
            }
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "Books", "EditBookInDatabase"));
            }
        }
    }
}