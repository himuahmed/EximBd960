using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EximBd960.Models
{
    public class ExperiencedApplicant
    {
        [Key]
        public int ExperiencedApplicantId { get; set; }

        public int ApplicantId { get; set; }
        [ForeignKey("ApplicantId")]
        public virtual Applicant Applicant { get; set; }

        public string Country { get; set; }
        public double Experience { get; set; }
    }
}