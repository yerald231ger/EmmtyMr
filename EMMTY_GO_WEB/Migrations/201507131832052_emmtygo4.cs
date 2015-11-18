namespace EMMTY_GO_WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emmtygo4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cajeros", "EnabledNotification", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cajeros", "EnabledNotification");
        }
    }
}
