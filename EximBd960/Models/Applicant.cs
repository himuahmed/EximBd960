using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EximBd960.Models
{
    public class Applicant
    {
        [Key]
        public int ApplicantId { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required(ErrorMessage = "Enter EntryDate Please")]
        public DateTime EntryDate { get; set; }

        [Required(ErrorMessage = "Name Cant be empty")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Password length should be between 3 to 50.")]
        public string ApplicantName { get; set; }

        //[Required(ErrorMessage = "Upload Image please")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Enter Passport number.")]
        public string PassportNo { get; set; }

        [Required(ErrorMessage = "Enter passport validity")]
        public DateTime PassportValidity { get; set; }

        [Required(ErrorMessage = "Enter birth place.")]
        public string BirthPlace { get; set; }

        [Required(ErrorMessage = "Enter Age.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Enter the number of child.")]
        public int Child { get; set; }

        [Required(ErrorMessage = "Enter Mobile number.")]
        public string MobileNo { get; set; }

        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }


        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

        public int AgentId { get; set; }
        [ForeignKey("AgentId")]
        public virtual Agent Agent { get; set; }

        //[Required(ErrorMessage = "Enter Medical Status.")]
        public string MedicalStatus { get; set; }

        //[Required(ErrorMessage = "Enter Tc status.")]
        public string TcStatus { get; set; }

        //[Required(ErrorMessage = "Enter pc status.")]
        public string PcStatus { get; set; }

        //[Required(ErrorMessage = "Enter CV date.")]
        public DateTime CvDate { get; set; }

        public DateTime VisaDate { get; set; }

        //[Required(ErrorMessage = "Enter agreement date.")]
        public DateTime AgreementDate { get; set; }

        
        public string Finger { get; set; }
        public string EmbassyReport { get; set; }
        public string Manpower { get; set; }
        public string Status { get; set; }
        public DateTime FlightDate { get; set; }
        public string Note { get; set; }
    }
}