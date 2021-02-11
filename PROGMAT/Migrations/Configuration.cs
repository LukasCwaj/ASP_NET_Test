namespace PROGMAT.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PROGMAT.DataAccessLayer;

    public sealed class Configuration : DbMigrationsConfiguration<PROGMAT.DataAccessLayer.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PROGMAT.DataAccessLayer.LibraryContext";
        }

        protected override void Seed(PROGMAT.DataAccessLayer.LibraryContext context)
        {
            Initializer.SeedLibrary(context);
        }
    }
}
