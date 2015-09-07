namespace SinglePageCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addinsight : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "GooglePlusId", c => c.String());
            AlterColumn("dbo.Blogs", "Author", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "Author", c => c.String(nullable: false));
            AlterColumn("dbo.Blogs", "GooglePlusId", c => c.String(nullable: false));
        }
    }
}
