using System;
using System.ComponentModel.DataAnnotations;

namespace PROGMAT.Models
{
    public class Books
    {
        public int BooksID { get; set; }
        public int ReservationsID { get; set; }
        public int UsersId { get; set; }
        [Required(ErrorMessage = "Name of book is required")]
        [StringLength(30)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Author of book is required")]
        [StringLength(30)]
        public string Author { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Description { get; set; }
        public bool IsReserved { get; set; }

    }
}