namespace SinglePageCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2insight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Insights", "Ip", c => c.String());
            AddColumn("dbo.Insights", "Browser", c => c.String());
            AddColumn("dbo.Insights", "Agent", c => c.String());
            AddColumn("dbo.Insights", "LastVisited", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Insights", "LastVisited");
            DropColumn("dbo.Insights", "Agent");
            DropColumn("dbo.Insights", "Browser");
            DropColumn("dbo.Insights", "Ip");
        }
    }
}
