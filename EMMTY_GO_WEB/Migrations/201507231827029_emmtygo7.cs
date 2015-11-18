namespace EMMTY_GO_WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emmtygo7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cajeros", "Online", c => c.Boolean(nullable: false));
            DropColumn("dbo.Cajeros", "AtmOnline");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cajeros", "AtmOnline", c => c.Boolean(nullable: false));
            DropColumn("dbo.Cajeros", "Online");
        }
    }
}
