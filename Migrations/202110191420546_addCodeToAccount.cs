namespace RocStudiosMVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCodeToAccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "code");
        }
    }
}
