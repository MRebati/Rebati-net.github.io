namespace SinglePageCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateinsight : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Insights", "Agent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Insights", "Agent", c => c.String());
        }
    }
}
