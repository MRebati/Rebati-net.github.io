namespace SinglePageCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecontent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contents", "GooglePlusId", c => c.String());
            AlterColumn("dbo.Contents", "Author", c => c.String());
            AlterColumn("dbo.Contents", "Keywords", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contents", "Keywords", c => c.String(nullable: false));
            AlterColumn("dbo.Contents", "Author", c => c.String(nullable: false));
            AlterColumn("dbo.Contents", "GooglePlusId", c => c.String(nullable: false));
        }
    }
}
