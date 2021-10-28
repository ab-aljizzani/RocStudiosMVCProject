namespace RocStudiosMVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImgPath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "ImgPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "ImgPath");
        }
    }
}
