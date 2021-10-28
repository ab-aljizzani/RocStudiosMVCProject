namespace RocStudiosMVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeamTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        TeamMemEngName = c.String(),
                        TeamMemArName = c.String(),
                        TeamMemEngJob = c.String(),
                        TeamMemArJob = c.String(),
                        TeamMemImge = c.String(),
                        TeamMemImgPath = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teams");
        }
    }
}
