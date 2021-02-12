using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROGMAT.Models
{
    public class Reservations
    {
        public Reservations(int currentBookID, int currentUserID, DateTime dateOfCreation)
        {
            this.BooksID = currentBookID;
            this.UsersId = currentUserID;
            this.DateOfReservations = dateOfCreation;
        }
        public Reservations(int currentReservationID)
        {
            this.ReservationsID = currentReservationID;
        }
        public Reservations()
        { 
        }
        public int ReservationsID { get; set; }
        public int BooksID { get; set; }
        public int UsersId { get; set; }
        public DateTime DateOfReservations { get; set; }
    }
}