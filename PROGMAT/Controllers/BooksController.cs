using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using PROGMAT.DataAccessLayer;

namespace PROGMAT.Controllers
{
    public class BooksController : Controller
    {
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
            LibraryContext context = new LibraryContext();
            return View(context.Book.AsEnumerable());
        }
    }
}