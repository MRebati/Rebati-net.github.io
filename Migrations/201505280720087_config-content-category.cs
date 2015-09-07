namespace SinglePageCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class configcontentcategory : DbMigration
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
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Contents", new[] { "CategoryId" });
            DropTable("dbo.Contents");
            DropTable("dbo.Categories");
        }
    }
}
