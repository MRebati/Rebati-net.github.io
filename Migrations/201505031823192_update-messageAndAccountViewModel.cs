namespace SinglePageCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemessageAndAccountViewModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Subject = c.String(),
                        Name = c.String(),
                        Content = c.String(),
                        Type = c.String(),
                        Priority = c.String(),
                        Date = c.DateTime(nullable: false),
                        Read = c.Boolean(nullable: false),
                        Show = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Messages");
        }
    }
}
