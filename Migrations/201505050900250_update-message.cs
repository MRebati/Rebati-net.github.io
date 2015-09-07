namespace SinglePageCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemessage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "Subject", c => c.String(nullable: false));
            AlterColumn("dbo.Messages", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Messages", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Messages", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.Messages", "Priority", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "Priority", c => c.String());
            AlterColumn("dbo.Messages", "Type", c => c.String());
            AlterColumn("dbo.Messages", "Content", c => c.String());
            AlterColumn("dbo.Messages", "Name", c => c.String());
            AlterColumn("dbo.Messages", "Subject", c => c.String());
        }
    }
}
