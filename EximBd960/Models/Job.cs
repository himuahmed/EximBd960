using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EximBd960.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        [Required(ErrorMessage = "Enter job's type please.")]

        public string JobType { get; set; }
    }
}