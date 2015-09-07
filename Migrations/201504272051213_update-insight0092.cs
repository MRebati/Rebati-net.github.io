namespace SinglePageCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateinsight0092 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Insights", "UserAgent", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Insights", "UserAgent");
        }
    }
}
