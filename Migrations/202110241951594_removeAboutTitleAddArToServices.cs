namespace RocStudiosMVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeAboutTitleAddArToServices : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "ServTitleEng", c => c.String(nullable: false));
            AddColumn("dbo.Services", "ServTitleAr", c => c.String(nullable: false));
            AddColumn("dbo.Services", "ServDescEng", c => c.String(nullable: false));
            AddColumn("dbo.Services", "ServDescAr", c => c.String(nullable: false));
            DropColumn("dbo.Abouts", "aboutTitle");
            DropColumn("dbo.Services", "ServTitle");
            DropColumn("dbo.Services", "ServDesc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "ServDesc", c => c.String(nullable: false));
            AddColumn("dbo.Services", "ServTitle", c => c.String(nullable: false));
            AddColumn("dbo.Abouts", "aboutTitle", c => c.String(nullable: false));
            DropColumn("dbo.Services", "ServDescAr");
            DropColumn("dbo.Services", "ServDescEng");
            DropColumn("dbo.Services", "ServTitleAr");
            DropColumn("dbo.Services", "ServTitleEng");
        }
    }
}
