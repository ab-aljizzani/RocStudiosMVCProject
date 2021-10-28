namespace RocStudiosMVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstName = c.String(nullable: false),
                        lastName = c.String(nullable: false),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false),
                        conFirmPass = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AlterColumn("dbo.Abouts", "aboutTitle", c => c.String(nullable: false));
            AlterColumn("dbo.Abouts", "aboutEng", c => c.String(nullable: false));
            AlterColumn("dbo.Abouts", "aboutAr", c => c.String(nullable: false));
            AlterColumn("dbo.Abouts", "aboutImg", c => c.String(nullable: false));
            AlterColumn("dbo.Abouts", "ImgPath", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "ClientName", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "ClientImg", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "ClientImgPath", c => c.String(nullable: false));
            AlterColumn("dbo.Portfolios", "PortImgName", c => c.String(nullable: false));
            AlterColumn("dbo.Portfolios", "PortImgPath", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "ServTitle", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "ServDesc", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "ServImg", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "ServImgPath", c => c.String(nullable: false));
            AlterColumn("dbo.Teams", "TeamMemEngName", c => c.String(nullable: false));
            AlterColumn("dbo.Teams", "TeamMemArName", c => c.String(nullable: false));
            AlterColumn("dbo.Teams", "TeamMemEngJob", c => c.String(nullable: false));
            AlterColumn("dbo.Teams", "TeamMemArJob", c => c.String(nullable: false));
            AlterColumn("dbo.Teams", "TeamMemImge", c => c.String(nullable: false));
            AlterColumn("dbo.Teams", "TeamMemImgPath", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teams", "TeamMemImgPath", c => c.String());
            AlterColumn("dbo.Teams", "TeamMemImge", c => c.String());
            AlterColumn("dbo.Teams", "TeamMemArJob", c => c.String());
            AlterColumn("dbo.Teams", "TeamMemEngJob", c => c.String());
            AlterColumn("dbo.Teams", "TeamMemArName", c => c.String());
            AlterColumn("dbo.Teams", "TeamMemEngName", c => c.String());
            AlterColumn("dbo.Services", "ServImgPath", c => c.String());
            AlterColumn("dbo.Services", "ServImg", c => c.String());
            AlterColumn("dbo.Services", "ServDesc", c => c.String());
            AlterColumn("dbo.Services", "ServTitle", c => c.String());
            AlterColumn("dbo.Portfolios", "PortImgPath", c => c.String());
            AlterColumn("dbo.Portfolios", "PortImgName", c => c.String());
            AlterColumn("dbo.Clients", "ClientImgPath", c => c.String());
            AlterColumn("dbo.Clients", "ClientImg", c => c.String());
            AlterColumn("dbo.Clients", "ClientName", c => c.String());
            AlterColumn("dbo.Abouts", "ImgPath", c => c.String());
            AlterColumn("dbo.Abouts", "aboutImg", c => c.String());
            AlterColumn("dbo.Abouts", "aboutAr", c => c.String());
            AlterColumn("dbo.Abouts", "aboutEng", c => c.String());
            AlterColumn("dbo.Abouts", "aboutTitle", c => c.String());
            DropTable("dbo.Accounts");
        }
    }
}
