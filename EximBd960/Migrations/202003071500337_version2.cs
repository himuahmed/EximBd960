namespace EximBd960.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Applicants", "PassportValidity", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Applicants", "VisaDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Applicants", "AgreementDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Applicants", "FlightDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Applicants", "FlightDate", c => c.DateTime());
            AlterColumn("dbo.Applicants", "AgreementDate", c => c.DateTime());
            AlterColumn("dbo.Applicants", "VisaDate", c => c.DateTime());
            AlterColumn("dbo.Applicants", "PassportValidity", c => c.DateTime());
        }
    }
}
