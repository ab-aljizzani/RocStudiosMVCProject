namespace RocStudiosMVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class accountUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "ErrorMessage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "ErrorMessage");
        }
    }
}
