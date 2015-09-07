namespace SinglePageCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase23 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImageCategories", "ImageCategoryId", "dbo.ImageCategories");
            DropIndex("dbo.ImageCategories", new[] { "ImageCategoryId" });
            AlterColumn("dbo.Images", "ImageCategoryId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Images", "ImageCategoryId");
            AddForeignKey("dbo.Images", "ImageCategoryId", "dbo.ImageCategories", "Id");
            DropColumn("dbo.ImageCategories", "Directory");
            DropColumn("dbo.ImageCategories", "ImageCategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ImageCategories", "ImageCategoryId", c => c.String(maxLength: 128));
            AddColumn("dbo.ImageCategories", "Directory", c => c.String());
            DropForeignKey("dbo.Images", "ImageCategoryId", "dbo.ImageCategories");
            DropIndex("dbo.Images", new[] { "ImageCategoryId" });
            AlterColumn("dbo.Images", "ImageCategoryId", c => c.String());
            CreateIndex("dbo.ImageCategories", "ImageCategoryId");
            AddForeignKey("dbo.ImageCategories", "ImageCategoryId", "dbo.ImageCategories", "Id");
        }
    }
}
