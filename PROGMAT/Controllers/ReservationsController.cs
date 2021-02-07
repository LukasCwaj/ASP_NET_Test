using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROGMAT.Controllers
{
    public class ReservationsController : Controller
    {
        // GET: Reservatiom
        public ActionResult Reservation()
        {
            return View();
        }
    }
}