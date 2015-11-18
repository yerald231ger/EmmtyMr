namespace AtmClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atmclient3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cajeros", "NsCajero", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cajeros", "NsCajero");
        }
    }
}
