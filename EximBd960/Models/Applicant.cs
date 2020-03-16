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

        [Display(Name = "Enrolled By: ")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Display(Name = "Enroll Date: ")]
        // [Required(ErrorMessage = "Enter EntryDate Please")]
        public DateTime? EntryDate { get; set; }

        [Display(Name = "Applicant's Name: ")]
       // [Required(ErrorMessage = "Name Cant be empty")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Password length should be between 3 to 50.")]
        public string ApplicantName { get; set; }

        [Display(Name = "Upload image: ")]
        [Column(TypeName = "varchar(MAX)")]
        //[Required(ErrorMessage = "Upload Image please")]
        public string ImageURL { get; set; }

        [Display(Name = "Passport No.: ")]
        //[Required(ErrorMessage = "Enter Passport number.")]
        public string PassportNo { get; set; }

        [Display(Name = "Passport Validity: ")]
        //[Required(ErrorMessage = "Enter passport validity")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PassportValidity { get; set; }

        [Display(Name = "Birth Place: ")]
        //[Required(ErrorMessage = "Enter birth place.")]
        public string BirthPlace { get; set; }

        [Display(Name = "Applicant's Age: ")]
        //[Required(ErrorMessage = "Enter Age.")]
        public int Age { get; set; }

        [Display(Name = "Number of Child: ")]
        //[Required(ErrorMessage = "Enter the number of child.")]
        public int Child { get; set; }

        [Display(Name = "Mobile No.: ")]
        [Required(ErrorMessage = "Enter Mobile number.")]
        public string MobileNo { get; set; }

        [Display(Name = "Country: ")]
        public int? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [Display(Name = "Company: ")]
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

        [Display(Name = "Agents Name: ")]
        public int AgentId { get; set; }
        [ForeignKey("AgentId")]
        public virtual Agent Agent { get; set; }

        [Display(Name = "Medical Status: ")]
        //[Required(ErrorMessage = "Enter Medical Status.")]
        public string MedicalStatus { get; set; }

        [Display(Name = "TC Status: ")]
        //[Required(ErrorMessage = "Enter Tc status.")]
        public string TcStatus { get; set; }

        [Display(Name = "PC Status: ")]
        //[Required(ErrorMessage = "Enter pc status.")]
        public string PcStatus { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "CV Date: ")]
        //[Required(ErrorMessage = "Enter CV date.")]
        public DateTime? CvDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Visa Date: ")]
        public DateTime? VisaDate { get; set; }

        [Display(Name = "Agreement Date: ")]
        //[Required(ErrorMessage = "Enter agreement date.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? AgreementDate { get; set; }

        [Display(Name = "Finger: ")]
        public string Finger { get; set; }

        [Display(Name = "Embassy Report: ")]
        public string EmbassyReport { get; set; }

        [Display(Name = "Manpower: ")]
        public string Manpower { get; set; }

        [Display(Name = "Status: ")]
        public string Status { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Flight Date: ")]
        public DateTime? FlightDate { get; set; }

        [Display(Name = "Note: ")]
        public string Note { get; set; }

        public int? JobId { get; set; }
        [ForeignKey("JobId")]
        public virtual Job Job { get; set; }
    }
}