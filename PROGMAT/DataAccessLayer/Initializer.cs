using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PROGMAT.Models;

namespace PROGMAT.DataAccessLayer
{
    public class Initializer : DropCreateDatabaseAlways<LibraryContext>
    {
        protected override void Seed (LibraryContext context)
        {
            SeedLibrary(context);
            base.Seed(context);
        }

        private void SeedLibrary(LibraryContext context)
        {
            var users = new List<Users>
            {
            new Users() { UsersID = 1, Login = "Login1", Password = "Password1"},
            new Users() { UsersID = 2, Login = "Login2", Password = "Password2" },
            new Users() { UsersID = 3, Login = "Login3", Password = "Password3" },
            new Users() { UsersID = 4, Login = "Login4", Password = "Password4" },
            new Users() { UsersID = 5, Login = "Login5", Password = "Password5" },
            new Users() { UsersID = 6, Login = "Login6", Password = "Password6" },
            new Users() { UsersID = 7, Login = "Login7", Password = "Password7" }
            };
            users.ForEach(i => context.User.Add(i));
            context.SaveChanges();
            var books = new List<Books>
            {
            new Books() { BooksID=1, Author="Someone1", Name="Name1", DateOfCreation=DateTime.Now, Description="Description1", IsReserved=true, ReservationsID=1, UsersId=7},
            new Books() { BooksID=2, Author="Someone2", Name="Name2", DateOfCreation=DateTime.Now, Description="Description2", IsReserved=true, ReservationsID=2, UsersId=5},
            new Books() { BooksID=3, Author="Someone3", Name="Name3", DateOfCreation=DateTime.Now, Description="Description3", IsReserved=false},
            new Books() { BooksID=4, Author="Someone4", Name="Name4", DateOfCreation=DateTime.Now, Description="Description4", IsReserved=false},
            new Books() { BooksID=5, Author="Someone5", Name="Name5", DateOfCreation=DateTime.Now, Description="Description5", IsReserved=true, ReservationsID=3, UsersId=3},
            new Books() { BooksID=6, Author="Someone6", Name="Name6", DateOfCreation=DateTime.Now, Description="Description6", IsReserved=true, ReservationsID=4, UsersId=2}
            };
            books.ForEach(i => context.Book.Add(i));
            context.SaveChanges();
            var reservations = new List<Reservations>
            {
            new Reservations() { ReservationsID=1, DateOfReservations=DateTime.Today },
            new Reservations() { ReservationsID=2, DateOfReservations=DateTime.Today },
            new Reservations() { ReservationsID=3, DateOfReservations=DateTime.Today },
            new Reservations() { ReservationsID=4, DateOfReservations=DateTime.Today },
            };
            reservations.ForEach(i => context.Reservation.Add(i));
            context.SaveChanges();
        }
    }
}