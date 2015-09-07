namespace SinglePageCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecontentaddcategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Contents", "ImageUrl", c => c.String());
            AddColumn("dbo.Contents", "CategoeyId", c => c.Int(nullable: false));
            AddColumn("dbo.Contents", "Category_Id", c => c.Int());
            CreateIndex("dbo.Contents", "Category_Id");
            AddForeignKey("dbo.Contents", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Contents", new[] { "Category_Id" });
            DropColumn("dbo.Contents", "Category_Id");
            DropColumn("dbo.Contents", "CategoeyId");
            DropColumn("dbo.Contents", "ImageUrl");
            DropTable("dbo.Categories");
        }
    }
}
