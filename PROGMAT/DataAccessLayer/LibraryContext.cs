using PROGMAT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PROGMAT.DataAccessLayer
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("LibraryContext")
        {

        }
        static LibraryContext()
        {
            Database.SetInitializer<LibraryContext>(new Initializer());
        }
        public DbSet<Users> User { get; set; }
        public DbSet<Books> Book { get; set; }
        public DbSet<Reservations> Reservation { get; set; }
    }
}