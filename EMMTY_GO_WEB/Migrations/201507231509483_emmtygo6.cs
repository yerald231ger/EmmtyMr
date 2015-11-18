namespace EMMTY_GO_WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emmtygo6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cajeros", "AtmUserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cajeros", "AtmUserId");
        }
    }
}
