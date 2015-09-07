namespace SinglePageCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addgallery : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GalleryItems", "GalleryId", "dbo.Galleries");
            DropIndex("dbo.GalleryItems", new[] { "GalleryId" });
            DropTable("dbo.GalleryItems");
            DropTable("dbo.Galleries");
        }
    }
}
