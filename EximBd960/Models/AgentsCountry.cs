using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EximBd960.Models
{
    public class AgentsCountry
    {
        [Key]
        public int AgentsCountryId { get; set; }

        public int AgentId { get; set; }
        [ForeignKey("AgentId")]
        public virtual Agent Agent { get; set; }

        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [Required(ErrorMessage = "Enter cost")]
        public int CostPerCountry { get; set; }
    }
}