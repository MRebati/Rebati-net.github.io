namespace SinglePageCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unconfig1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contents", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Contents", new[] { "Category_Id" });
            DropTable("dbo.Categories");
            DropTable("dbo.Contents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Slug = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        ContentData = c.String(nullable: false),
                        BackGroundContent = c.String(),
                        ImageUrl = c.String(),
                        Summery = c.String(nullable: false),
                        GooglePlusId = c.String(),
                        Author = c.String(),
                        Keywords = c.String(),
                        Modified = c.DateTime(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        CategoeyId = c.Int(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Contents", "Category_Id");
            AddForeignKey("dbo.Contents", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
