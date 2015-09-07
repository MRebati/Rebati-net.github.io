namespace SinglePageCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateimagecat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImageCategories", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ImageCategories", "Modified", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ImageCategories", "Modified");
            DropColumn("dbo.ImageCategories", "CreateDate");
        }
    }
}
