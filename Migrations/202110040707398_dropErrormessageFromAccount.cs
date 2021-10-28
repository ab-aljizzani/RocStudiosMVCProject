namespace RocStudiosMVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropErrormessageFromAccount : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Accounts", "ErrorMessage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "ErrorMessage", c => c.String());
        }
    }
}
