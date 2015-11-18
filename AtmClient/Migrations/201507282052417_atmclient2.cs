namespace AtmClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atmclient2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cajeros", "NsCajero");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cajeros", "NsCajero", c => c.String());
        }
    }
}
