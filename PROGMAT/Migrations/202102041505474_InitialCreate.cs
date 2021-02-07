namespace PROGMAT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BooksID = c.Int(nullable: false, identity: true),
                        ReservationsID = c.Int(nullable: false),
                        UsersId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30),
                        Author = c.String(nullable: false, maxLength: 30),
                        DateOfCreation = c.DateTime(nullable: false),
                        Description = c.String(),
                        IsReserved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BooksID);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationsID = c.Int(nullable: false, identity: true),
                        DateOfReservations = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationsID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UsersID = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 12),
                    })
                .PrimaryKey(t => t.UsersID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Reservations");
            DropTable("dbo.Books");
        }
    }
}
