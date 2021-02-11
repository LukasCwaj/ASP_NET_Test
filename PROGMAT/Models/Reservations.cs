using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROGMAT.Models
{
    public class Reservations
    {
        public int ReservationsID { get; set; }
        public int BooksID { get; set; }
        public int UsersId { get; set; }
        public DateTime DateOfReservations { get; set; }
    }
}