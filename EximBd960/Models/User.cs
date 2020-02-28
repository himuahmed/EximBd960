using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EximBd960.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Enter Username please.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter Password please.")]
        [StringLength(20,MinimumLength = 5,ErrorMessage = "Password length should be between 5 to 20.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Role can't be empty.")]
        public string Role { get; set; }
    }
} 