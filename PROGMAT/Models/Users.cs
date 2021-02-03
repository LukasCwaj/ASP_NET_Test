using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PROGMAT.Models
{
    public class Users
    {
        public int UsersID { get; set; }
        [Required(ErrorMessage ="Login is required")]
        [StringLength(30)]
        public string Login { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(12)]
        public string Password { get; set; }
    }
}