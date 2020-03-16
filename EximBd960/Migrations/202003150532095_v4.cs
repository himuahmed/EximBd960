namespace EximBd960.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Applicants", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Applicants", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Applicants", "JobId", "dbo.Jobs");
            DropIndex("dbo.Applicants", new[] { "CountryId" });
            DropIndex("dbo.Applicants", new[] { "CompanyId" });
            DropIndex("dbo.Applicants", new[] { "JobId" });
            AlterColumn("dbo.Applicants", "CountryId", c => c.Int());
            AlterColumn("dbo.Applicants", "CompanyId", c => c.Int());
            AlterColumn("dbo.Applicants", "JobId", c => c.Int());
            CreateIndex("dbo.Applicants", "CountryId");
            CreateIndex("dbo.Applicants", "CompanyId");
            CreateIndex("dbo.Applicants", "JobId");
            AddForeignKey("dbo.Applicants", "CompanyId", "dbo.Companies", "CompanyId");
            AddForeignKey("dbo.Applicants", "CountryId", "dbo.Countries", "CountryId");
            AddForeignKey("dbo.Applicants", "JobId", "dbo.Jobs", "JobId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applicants", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Applicants", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Applicants", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Applicants", new[] { "JobId" });
            DropIndex("dbo.Applicants", new[] { "CompanyId" });
            DropIndex("dbo.Applicants", new[] { "CountryId" });
            AlterColumn("dbo.Applicants", "JobId", c => c.Int(nullable: false));
            AlterColumn("dbo.Applicants", "CompanyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Applicants", "CountryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Applicants", "JobId");
            CreateIndex("dbo.Applicants", "CompanyId");
            CreateIndex("dbo.Applicants", "CountryId");
            AddForeignKey("dbo.Applicants", "JobId", "dbo.Jobs", "JobId", cascadeDelete: true);
            AddForeignKey("dbo.Applicants", "CountryId", "dbo.Countries", "CountryId", cascadeDelete: true);
            AddForeignKey("dbo.Applicants", "CompanyId", "dbo.Companies", "CompanyId", cascadeDelete: true);
        }
    }
}
