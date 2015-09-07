namespace SinglePageCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class additemsToDb : DbMigration
    {
        public override void Up()
        {
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
                "dbo.IndexAbouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Slug = c.String(nullable: false),
                        Content = c.String(nullable: false),
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
            DropTable("dbo.Sliders");
            DropTable("dbo.IndexContents");
            DropTable("dbo.IndexAbouts");
            DropTable("dbo.ContactUs");
        }
    }
}
