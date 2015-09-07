namespace SinglePageCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateregistery : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Registeries", "Value", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Registeries", "Value", c => c.String(nullable: false));
        }
    }
}
