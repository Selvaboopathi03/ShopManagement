using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class User
    {
        public int UserID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$",
        ErrorMessage = "Password must be at least 8 characters long and contain at least one letter and one number.")]
        public string PasswordHash { get; set; }

        [Required]
        public string Role { get; set; }
    }

}
