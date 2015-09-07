namespace SinglePageCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addimage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ImageName = c.String(),
                        Path = c.String(),
                        ImageCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ImageCategories", t => t.ImageCategoryId, cascadeDelete: true)
                .Index(t => t.ImageCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "ImageCategoryId", "dbo.ImageCategories");
            DropIndex("dbo.Images", new[] { "ImageCategoryId" });
            DropTable("dbo.Images");
            DropTable("dbo.ImageCategories");
        }
    }
}
