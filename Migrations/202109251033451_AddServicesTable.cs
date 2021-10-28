namespace RocStudiosMVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddServicesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ServTitle = c.String(),
                        ServDesc = c.String(),
                        ServImg = c.String(),
                        ServImgPath = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Services");
        }
    }
}
