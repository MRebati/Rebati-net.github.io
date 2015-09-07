namespace SinglePageCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateimageCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Slug = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        ContentData = c.String(nullable: false),
                        Summery = c.String(nullable: false),
                        GooglePlusId = c.String(),
                        Author = c.String(),
                        UserName = c.String(),
                        UserId = c.String(),
                        Keywords = c.String(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
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
            
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Message = c.String(nullable: false),
                        Read = c.Boolean(nullable: false),
                        Time = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Describtion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GalleryItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Describtion = c.String(),
                        MediaUrl = c.String(),
                        LinkUrl = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        GalleryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Galleries", t => t.GalleryId, cascadeDelete: true)
                .Index(t => t.GalleryId);
            
            CreateTable(
                "dbo.ImageCategories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Directory = c.String(),
                        ImageCategoryId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ImageCategories", t => t.ImageCategoryId)
                .Index(t => t.ImageCategoryId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ImageName = c.String(),
                        Path = c.String(),
                        ImageCategoryId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IndexAbouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Position = c.String(),
                        ShortDescribtion = c.String(),
                        LongDescribtion = c.String(nullable: false),
                        UserImageUrl = c.String(),
                        RightImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IndexContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Identifier = c.String(),
                        Slug = c.String(),
                        Content = c.String(nullable: false),
                        HasBackground = c.Boolean(nullable: false),
                        BackgroundImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Insights",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Url = c.String(),
                        Ip = c.String(),
                        Browser = c.String(),
                        UserAgent = c.String(),
                        LastVisited = c.String(),
                        IsUser = c.Boolean(nullable: false),
                        UserId = c.String(),
                        UserName = c.String(),
                        PageName = c.String(),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Subject = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        Priority = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Read = c.Boolean(nullable: false),
                        Show = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Registeries",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Value = c.String(),
                        IsHtml = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        Title = c.String(),
                        CaptionImg = c.String(),
                        LinkUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageCategories", "ImageCategoryId", "dbo.ImageCategories");
            DropForeignKey("dbo.GalleryItems", "GalleryId", "dbo.Galleries");
            DropForeignKey("dbo.Contents", "CategoryId", "dbo.Categories");
            DropIndex("dbo.ImageCategories", new[] { "ImageCategoryId" });
            DropIndex("dbo.GalleryItems", new[] { "GalleryId" });
            DropIndex("dbo.Contents", new[] { "CategoryId" });
            DropTable("dbo.Sliders");
            DropTable("dbo.Registeries");
            DropTable("dbo.Messages");
            DropTable("dbo.Menus");
            DropTable("dbo.Insights");
            DropTable("dbo.IndexContents");
            DropTable("dbo.IndexAbouts");
            DropTable("dbo.Images");
            DropTable("dbo.ImageCategories");
            DropTable("dbo.GalleryItems");
            DropTable("dbo.Galleries");
            DropTable("dbo.ContactUs");
            DropTable("dbo.Contents");
            DropTable("dbo.Categories");
            DropTable("dbo.Blogs");
        }
    }
}
