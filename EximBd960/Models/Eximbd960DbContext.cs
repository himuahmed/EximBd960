using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EximBd960.Models
{
    public class Eximbd960DbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<AgentsCountry> AgentsCountries { get; set; }
        public DbSet<ExperiencedApplicant> ExperiencedApplicants { get; set; }
            
    }
}