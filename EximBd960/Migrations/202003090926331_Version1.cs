namespace EximBd960.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        AgentId = c.Int(nullable: false, identity: true),
                        AgentName = c.String(nullable: false),
                        MobileNo = c.String(nullable: false, maxLength: 14),
                        Address = c.String(),
                        NID = c.String(),
                        PassportNo = c.String(),
                    })
                .PrimaryKey(t => t.AgentId);
            
            CreateTable(
                "dbo.AgentsCountries",
                c => new
                    {
                        AgentsCountryId = c.Int(nullable: false, identity: true),
                        AgentId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                        CostPerCountry = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AgentsCountryId)
                .ForeignKey("dbo.Agents", t => t.AgentId, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.AgentId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        ApplicantId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        ApplicantName = c.String(nullable: false, maxLength: 50),
                        ImageURL = c.String(),
                        PassportNo = c.String(),
                        PassportValidity = c.DateTime(),
                        BirthPlace = c.String(),
                        Age = c.Int(nullable: false),
                        Child = c.Int(nullable: false),
                        MobileNo = c.String(nullable: false),
                        CountryId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        AgentId = c.Int(nullable: false),
                        MedicalStatus = c.String(),
                        TcStatus = c.String(),
                        PcStatus = c.String(),
                        CvDate = c.DateTime(),
                        VisaDate = c.DateTime(),
                        AgreementDate = c.DateTime(),
                        Finger = c.String(),
                        EmbassyReport = c.String(),
                        Manpower = c.String(),
                        Status = c.String(),
                        FlightDate = c.DateTime(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.ApplicantId)
                .ForeignKey("dbo.Agents", t => t.AgentId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CountryId)
                .Index(t => t.CompanyId)
                .Index(t => t.AgentId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 20),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.ExperiencedApplicants",
                c => new
                    {
                        ExperiencedApplicantId = c.Int(nullable: false, identity: true),
                        ApplicantId = c.Int(nullable: false),
                        Country = c.String(),
                        Experience = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ExperiencedApplicantId)
                .ForeignKey("dbo.Applicants", t => t.ApplicantId, cascadeDelete: true)
                .Index(t => t.ApplicantId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        JobType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.JobId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExperiencedApplicants", "ApplicantId", "dbo.Applicants");
            DropForeignKey("dbo.Applicants", "UserId", "dbo.Users");
            DropForeignKey("dbo.Applicants", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Applicants", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Applicants", "AgentId", "dbo.Agents");
            DropForeignKey("dbo.AgentsCountries", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.AgentsCountries", "AgentId", "dbo.Agents");
            DropIndex("dbo.ExperiencedApplicants", new[] { "ApplicantId" });
            DropIndex("dbo.Applicants", new[] { "AgentId" });
            DropIndex("dbo.Applicants", new[] { "CompanyId" });
            DropIndex("dbo.Applicants", new[] { "CountryId" });
            DropIndex("dbo.Applicants", new[] { "UserId" });
            DropIndex("dbo.AgentsCountries", new[] { "CountryId" });
            DropIndex("dbo.AgentsCountries", new[] { "AgentId" });
            DropTable("dbo.Jobs");
            DropTable("dbo.ExperiencedApplicants");
            DropTable("dbo.Users");
            DropTable("dbo.Companies");
            DropTable("dbo.Applicants");
            DropTable("dbo.Countries");
            DropTable("dbo.AgentsCountries");
            DropTable("dbo.Agents");
        }
    }
}
