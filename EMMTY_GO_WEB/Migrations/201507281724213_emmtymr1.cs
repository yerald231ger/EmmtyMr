namespace EMMTY_GO_WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emmtymr1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Aceptadores_Billetes", "StatusAceptador_Billetes", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Aceptadores_Billetes", "ErrorAceptador_Billetes", c => c.String(nullable: false));
            AlterColumn("dbo.Cajeros", "ErrorCajero", c => c.String(nullable: false));
            AlterColumn("dbo.Cajeros", "StatusCajero", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Aceptadores_Monedas", "StatusAceptador_Monedas", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Aceptadores_Monedas", "ErrorAceptador_Monedas", c => c.String(nullable: false));
            AlterColumn("dbo.Dispensadores", "StatusDispensador", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Dispensadores", "ErrorDispensador", c => c.String(nullable: false));
            AlterColumn("dbo.Impresoras", "StatusImpresora", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Impresoras", "ErrorImpresora", c => c.String(nullable: false));
            AlterColumn("dbo.Monitores", "StatusMonitor", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Monitores", "ErrorMonitor", c => c.String(nullable: false));
            AlterColumn("dbo.PCes", "StatusPC", c => c.Boolean(nullable: false));
            AlterColumn("dbo.PCes", "ErrorPC", c => c.String(nullable: false));
            AlterColumn("dbo.Scanners", "StatusScanner", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Scanners", "ErrorScanner", c => c.String(nullable: false));
            AlterColumn("dbo.Tarjetas", "StatusTarjeta", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tarjetas", "ErrorTarjeta", c => c.String(nullable: false));
            AlterColumn("dbo.TonelerosA", "StatusTonelero", c => c.Boolean(nullable: false));
            AlterColumn("dbo.TonelerosA", "ErrorTonelero", c => c.String(nullable: false));
            AlterColumn("dbo.TonelerosB", "StatusTonelero", c => c.Boolean(nullable: false));
            AlterColumn("dbo.TonelerosB", "ErrorTonelero", c => c.String(nullable: false));
            AlterColumn("dbo.UPes", "StatusUPS", c => c.Boolean(nullable: false));
            AlterColumn("dbo.UPes", "ErrorUPS", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UPes", "ErrorUPS", c => c.Boolean(nullable: false));
            AlterColumn("dbo.UPes", "StatusUPS", c => c.String(nullable: false));
            AlterColumn("dbo.TonelerosB", "ErrorTonelero", c => c.Boolean(nullable: false));
            AlterColumn("dbo.TonelerosB", "StatusTonelero", c => c.String(nullable: false));
            AlterColumn("dbo.TonelerosA", "ErrorTonelero", c => c.Boolean(nullable: false));
            AlterColumn("dbo.TonelerosA", "StatusTonelero", c => c.String(nullable: false));
            AlterColumn("dbo.Tarjetas", "ErrorTarjeta", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tarjetas", "StatusTarjeta", c => c.String(nullable: false));
            AlterColumn("dbo.Scanners", "ErrorScanner", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Scanners", "StatusScanner", c => c.String(nullable: false));
            AlterColumn("dbo.PCes", "ErrorPC", c => c.Boolean(nullable: false));
            AlterColumn("dbo.PCes", "StatusPC", c => c.String(nullable: false));
            AlterColumn("dbo.Monitores", "ErrorMonitor", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Monitores", "StatusMonitor", c => c.String(nullable: false));
            AlterColumn("dbo.Impresoras", "ErrorImpresora", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Impresoras", "StatusImpresora", c => c.String(nullable: false));
            AlterColumn("dbo.Dispensadores", "ErrorDispensador", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Dispensadores", "StatusDispensador", c => c.String(nullable: false));
            AlterColumn("dbo.Aceptadores_Monedas", "ErrorAceptador_Monedas", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Aceptadores_Monedas", "StatusAceptador_Monedas", c => c.String(nullable: false));
            AlterColumn("dbo.Cajeros", "StatusCajero", c => c.String(nullable: false));
            AlterColumn("dbo.Cajeros", "ErrorCajero", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Aceptadores_Billetes", "ErrorAceptador_Billetes", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Aceptadores_Billetes", "StatusAceptador_Billetes", c => c.String(nullable: false));
        }
    }
}
