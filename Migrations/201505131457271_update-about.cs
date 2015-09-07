namespace SinglePageCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateabout : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IndexAbouts", "Position", c => c.String());
            AddColumn("dbo.IndexAbouts", "ShortDescribtion", c => c.String());
            AddColumn("dbo.IndexAbouts", "LongDescribtion", c => c.String(nullable: false));
            DropColumn("dbo.IndexAbouts", "Slug");
            DropColumn("dbo.IndexAbouts", "Content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IndexAbouts", "Content", c => c.String(nullable: false));
            AddColumn("dbo.IndexAbouts", "Slug", c => c.String(nullable: false));
            DropColumn("dbo.IndexAbouts", "LongDescribtion");
            DropColumn("dbo.IndexAbouts", "ShortDescribtion");
            DropColumn("dbo.IndexAbouts", "Position");
        }
    }
}
