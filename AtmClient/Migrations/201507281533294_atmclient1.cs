namespace AtmClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atmclient1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AceptadoresBilletes", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.AceptadoresBilletes", "Error", c => c.String());
            AlterColumn("dbo.AceptadoresMonedas", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.AceptadoresMonedas", "Error", c => c.String());
            AlterColumn("dbo.Dispensadores", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Dispensadores", "Error", c => c.String());
            AlterColumn("dbo.Impresoras", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Impresoras", "Error", c => c.String());
            AlterColumn("dbo.Scanners", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Scanners", "Error", c => c.String());
            AlterColumn("dbo.Tarjetas", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tarjetas", "Error", c => c.String());
            AlterColumn("dbo.TonelerosA", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.TonelerosA", "Error", c => c.String());
            AlterColumn("dbo.TonelerosB", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.TonelerosB", "Error", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TonelerosB", "Error", c => c.Boolean(nullable: false));
            AlterColumn("dbo.TonelerosB", "Status", c => c.String());
            AlterColumn("dbo.TonelerosA", "Error", c => c.Boolean(nullable: false));
            AlterColumn("dbo.TonelerosA", "Status", c => c.String());
            AlterColumn("dbo.Tarjetas", "Error", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tarjetas", "Status", c => c.String());
            AlterColumn("dbo.Scanners", "Error", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Scanners", "Status", c => c.String());
            AlterColumn("dbo.Impresoras", "Error", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Impresoras", "Status", c => c.String());
            AlterColumn("dbo.Dispensadores", "Error", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Dispensadores", "Status", c => c.String());
            AlterColumn("dbo.AceptadoresMonedas", "Error", c => c.Boolean(nullable: false));
            AlterColumn("dbo.AceptadoresMonedas", "Status", c => c.String());
            AlterColumn("dbo.AceptadoresBilletes", "Error", c => c.Boolean(nullable: false));
            AlterColumn("dbo.AceptadoresBilletes", "Status", c => c.String());
        }
    }
}
