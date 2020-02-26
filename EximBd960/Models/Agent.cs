using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EximBd960.Models
{
    public class Agent
    {
        public int AgentId { get; set; }
        public string AgentName { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string NID { get; set; }
        public string PassportNo { get; set; }
    }
}