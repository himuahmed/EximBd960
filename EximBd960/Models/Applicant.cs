using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EximBd960.Models
{
    public class Applicant
    {
        public int ApplicantId { get; set; }
        public int UserId { get; set; }
        public DateTime EntryDate { get; set; }
        public string ApplicantName { get; set; }
        public string ImageURL { get; set; }
        public string PassportNo { get; set; }
        public DateTime PassportValidity { get; set; }
        public string BirthPlace { get; set; }
        public int Age { get; set; }
        public int Child { get; set; }
        public string MobileNo { get; set; }
        public int CountryId { get; set; }
        public int CompanyId { get; set; }
        public int AgentId { get; set; }
        public string MedicalStatus { get; set; }
        public string TcStatus { get; set; }
        public string PcStatus { get; set; }
        public DateTime CvDate { get; set; }
        public DateTime VisaDate { get; set; }
        public DateTime AgreementDate { get; set; }
        public string Finger { get; set; }
        public string EmbassyReport { get; set; }
        public string Manpower { get; set; }
        public string Status { get; set; }
        public DateTime FlightDate { get; set; }
        public string Note { get; set; }
    }
}