namespace EMMTY_GO_WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emmtygo3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clientes", "IdUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "IdUser", c => c.String());
        }
    }
}
