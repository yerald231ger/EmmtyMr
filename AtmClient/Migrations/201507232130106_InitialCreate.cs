namespace AtmClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AceptadoresBilletes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Status = c.String(),
                        Error = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cajeros",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RowUpdate = c.Boolean(nullable: false),
                        NsCajero = c.String(),
                        AceptadorBilletes_Id = c.String(maxLength: 128),
                        AceptadorMonedas_Id = c.String(maxLength: 128),
                        Dispensador_Id = c.String(maxLength: 128),
                        Impresora_Id = c.String(maxLength: 128),
                        Scanner_Id = c.String(maxLength: 128),
                        Tarjeta_Id = c.String(maxLength: 128),
                        ToneleroA_Id = c.String(maxLength: 128),
                        ToneleroB_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AceptadoresBilletes", t => t.AceptadorBilletes_Id)
                .ForeignKey("dbo.AceptadoresMonedas", t => t.AceptadorMonedas_Id)
                .ForeignKey("dbo.Dispensadores", t => t.Dispensador_Id)
                .ForeignKey("dbo.Impresoras", t => t.Impresora_Id)
                .ForeignKey("dbo.Scanners", t => t.Scanner_Id)
                .ForeignKey("dbo.Tarjetas", t => t.Tarjeta_Id)
                .ForeignKey("dbo.TonelerosA", t => t.ToneleroA_Id)
                .ForeignKey("dbo.TonelerosB", t => t.ToneleroB_Id)
                .Index(t => t.AceptadorBilletes_Id)
                .Index(t => t.AceptadorMonedas_Id)
                .Index(t => t.Dispensador_Id)
                .Index(t => t.Impresora_Id)
                .Index(t => t.Scanner_Id)
                .Index(t => t.Tarjeta_Id)
                .Index(t => t.ToneleroA_Id)
                .Index(t => t.ToneleroB_Id);
            
            CreateTable(
                "dbo.AceptadoresMonedas",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Status = c.String(),
                        Error = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dispensadores",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        EfectivoInicial = c.Int(nullable: false),
                        EfectivoDispensado = c.Int(nullable: false),
                        EfectivoActual = c.Int(nullable: false),
                        ValorDispensador = c.Int(nullable: false),
                        Status = c.String(),
                        Error = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Impresoras",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Papel = c.Boolean(nullable: false),
                        Status = c.String(),
                        Error = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Scanners",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Status = c.String(),
                        Error = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tarjetas",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Status = c.String(),
                        Error = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TonelerosA",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        EfectivoInicial = c.Int(nullable: false),
                        EfectivoDispensado = c.Int(nullable: false),
                        EfectivoActual = c.Int(nullable: false),
                        ValorDispensador = c.Int(nullable: false),
                        Status = c.String(),
                        Error = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TonelerosB",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        EfectivoInicial = c.Int(nullable: false),
                        EfectivoDispensado = c.Int(nullable: false),
                        EfectivoActual = c.Int(nullable: false),
                        ValorDispensador = c.Int(nullable: false),
                        Status = c.String(),
                        Error = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cajeros", "ToneleroB_Id", "dbo.TonelerosB");
            DropForeignKey("dbo.Cajeros", "ToneleroA_Id", "dbo.TonelerosA");
            DropForeignKey("dbo.Cajeros", "Tarjeta_Id", "dbo.Tarjetas");
            DropForeignKey("dbo.Cajeros", "Scanner_Id", "dbo.Scanners");
            DropForeignKey("dbo.Cajeros", "Impresora_Id", "dbo.Impresoras");
            DropForeignKey("dbo.Cajeros", "Dispensador_Id", "dbo.Dispensadores");
            DropForeignKey("dbo.Cajeros", "AceptadorMonedas_Id", "dbo.AceptadoresMonedas");
            DropForeignKey("dbo.Cajeros", "AceptadorBilletes_Id", "dbo.AceptadoresBilletes");
            DropIndex("dbo.Cajeros", new[] { "ToneleroB_Id" });
            DropIndex("dbo.Cajeros", new[] { "ToneleroA_Id" });
            DropIndex("dbo.Cajeros", new[] { "Tarjeta_Id" });
            DropIndex("dbo.Cajeros", new[] { "Scanner_Id" });
            DropIndex("dbo.Cajeros", new[] { "Impresora_Id" });
            DropIndex("dbo.Cajeros", new[] { "Dispensador_Id" });
            DropIndex("dbo.Cajeros", new[] { "AceptadorMonedas_Id" });
            DropIndex("dbo.Cajeros", new[] { "AceptadorBilletes_Id" });
            DropTable("dbo.TonelerosB");
            DropTable("dbo.TonelerosA");
            DropTable("dbo.Tarjetas");
            DropTable("dbo.Scanners");
            DropTable("dbo.Impresoras");
            DropTable("dbo.Dispensadores");
            DropTable("dbo.AceptadoresMonedas");
            DropTable("dbo.Cajeros");
            DropTable("dbo.AceptadoresBilletes");
        }
    }
}
