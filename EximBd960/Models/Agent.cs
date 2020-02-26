using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EximBd960.Models
{
    public class Agent
    {
        [Key]
        public int AgentId { get; set; }
        [Required(ErrorMessage = "Enter agent name.")]
        public string AgentName { get; set; }

        [Required(ErrorMessage = "Enter agent mobile no.")]
        [StringLength(14,MinimumLength = 11,ErrorMessage = "Enter mobile no correctly.")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Enter address.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter NID number.")]
        public string NID { get; set; }

        [Required(ErrorMessage = "Enter passport number.")]
        public string PassportNo { get; set; }
    }
}