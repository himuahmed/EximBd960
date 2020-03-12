namespace EximBd960.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applicantv3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Applicants", "ImageURL", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Applicants", "ImageURL", c => c.String());
        }
    }
}
