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
        }
    }
}