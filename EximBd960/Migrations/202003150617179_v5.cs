namespace EximBd960.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Applicants", "ApplicantName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Applicants", "ApplicantName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
