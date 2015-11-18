namespace EMMTY_GO_WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emmtygo1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aceptadores_Billetes",
                c => new
                    {
                        IdAceptador_Billetes = c.Int(nullable: false, identity: true),
                        ModeloAceptador_Billetes = c.String(nullable: false),
                        NombreAceptador_Billetes = c.String(nullable: false),
                        NSAceptador_Billetes = c.String(nullable: false),
                        StatusAceptador_Billetes = c.String(nullable: false),
                        ErrorAceptador_Billetes = c.Boolean(nullable: false),
                        MarcaAceptador_Billetes = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdAceptador_Billetes);
            
            CreateTable(
                "dbo.Cajeros",
                c => new
                    {
                        IdCajero = c.Int(nullable: false, identity: true),
                        ColorCajero = c.String(nullable: false),
                        FechaEntregaCajero = c.DateTime(nullable: false),
                        FechaSalidaCajero = c.DateTime(nullable: false),
                        FechaEnsambladoCajero = c.DateTime(nullable: false),
                        NSCajero = c.String(nullable: false),
                        NombreCajero = c.String(nullable: false),
                        NombreEnsamblador = c.String(nullable: false),
                        UbicacionCajero = c.String(nullable: false),
                        ErrorCajero = c.Boolean(nullable: false),
                        StatusCajero = c.String(nullable: false),
                        ModeloCajero = c.String(nullable: false),
                        TipoCajero = c.String(nullable: false),
                        IdAceptador_Billetes = c.Int(),
                        IdDispensador = c.Int(),
                        IdCliente = c.Int(),
                        IdPC = c.Int(),
                        IdImpresora = c.Int(),
                        IdAceptador_Monedas = c.Int(),
                        IdTarjeta = c.Int(),
                        IdUPS = c.Int(),
                        IdScanner = c.Int(),
                        IdMonitor = c.Int(),
                        IdSucursal = c.Int(),
                        IdToneleroA = c.Int(),
                        IdToneleroB = c.Int(),
                        EfectivoActual = c.Int(nullable: false),
                        EfectivoDispensado = c.Int(nullable: false),
                        EfectivoInicial = c.Int(nullable: false),
                        NivelBajoEfectivo = c.Int(nullable: false),
                        RowUpdate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdCajero)
                .ForeignKey("dbo.Aceptadores_Billetes", t => t.IdAceptador_Billetes)
                .ForeignKey("dbo.Aceptadores_Monedas", t => t.IdAceptador_Monedas)
                .ForeignKey("dbo.Clientes", t => t.IdCliente)
                .ForeignKey("dbo.Dispensadores", t => t.IdDispensador)
                .ForeignKey("dbo.Impresoras", t => t.IdImpresora)
                .ForeignKey("dbo.Monitores", t => t.IdMonitor)
                .ForeignKey("dbo.PCes", t => t.IdPC)
                .ForeignKey("dbo.Scanners", t => t.IdScanner)
                .ForeignKey("dbo.Sucursales", t => t.IdSucursal)
                .ForeignKey("dbo.Tarjetas", t => t.IdTarjeta)
                .ForeignKey("dbo.TonelerosA", t => t.IdToneleroA)
                .ForeignKey("dbo.TonelerosB", t => t.IdToneleroB)
                .ForeignKey("dbo.UPes", t => t.IdUPS)
                .Index(t => t.IdAceptador_Billetes)
                .Index(t => t.IdDispensador)
                .Index(t => t.IdCliente)
                .Index(t => t.IdPC)
                .Index(t => t.IdImpresora)
                .Index(t => t.IdAceptador_Monedas)
                .Index(t => t.IdTarjeta)
                .Index(t => t.IdUPS)
                .Index(t => t.IdScanner)
                .Index(t => t.IdMonitor)
                .Index(t => t.IdSucursal)
                .Index(t => t.IdToneleroA)
                .Index(t => t.IdToneleroB);
            
            CreateTable(
                "dbo.Aceptadores_Monedas",
                c => new
                    {
                        IdAceptador_Monedas = c.Int(nullable: false, identity: true),
                        ModeloAceptador_Monedas = c.String(nullable: false),
                        NombreAceptador_Monedas = c.String(nullable: false),
                        NSAceptador_Monedas = c.String(nullable: false),
                        StatusAceptador_Monedas = c.String(nullable: false),
                        ErrorAceptador_Monedas = c.Boolean(nullable: false),
                        MarcaAceptador_Monedas = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdAceptador_Monedas);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        IdCliente = c.Int(nullable: false, identity: true),
                        LicenciaStatus = c.String(nullable: false),
                        NombreCliente = c.String(nullable: false),
                        TipoCliente = c.String(nullable: false),
                        IdUser = c.String(),
                    })
                .PrimaryKey(t => t.IdCliente);
            
            CreateTable(
                "dbo.Dispensadores",
                c => new
                    {
                        IdDispensador = c.Int(nullable: false, identity: true),
                        EfectivoActualDispensador = c.Int(nullable: false),
                        EfectivoDispensadoDispensador = c.Int(nullable: false),
                        EfectivoInicialDispensador = c.Int(nullable: false),
                        ModeloDispensador = c.String(nullable: false),
                        NSDispensador = c.String(nullable: false),
                        StatusDispensador = c.String(nullable: false),
                        TipoBillete = c.String(nullable: false),
                        ErrorDispensador = c.Boolean(nullable: false),
                        MarcaDispensador = c.String(nullable: false),
                        NombreDispensador = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdDispensador);
            
            CreateTable(
                "dbo.Impresoras",
                c => new
                    {
                        IdImpresora = c.Int(nullable: false, identity: true),
                        NSImpresora = c.String(nullable: false),
                        NombreImpresora = c.String(nullable: false),
                        ModeloImpresora = c.String(nullable: false),
                        StatusImpresora = c.String(nullable: false),
                        PapelImpresora = c.Boolean(nullable: false),
                        ErrorImpresora = c.Boolean(nullable: false),
                        MarcaImpresora = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdImpresora);
            
            CreateTable(
                "dbo.Monitores",
                c => new
                    {
                        IdMonitor = c.Int(nullable: false, identity: true),
                        MarcaMonitor = c.String(nullable: false),
                        ModeloMonitor = c.String(nullable: false),
                        NombreMonitor = c.String(nullable: false),
                        NSMonitor = c.String(nullable: false),
                        StatusMonitor = c.String(nullable: false),
                        ErrorMonitor = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdMonitor);
            
            CreateTable(
                "dbo.PCes",
                c => new
                    {
                        IdPC = c.Int(nullable: false, identity: true),
                        MarcaPC = c.String(nullable: false),
                        ModeloPC = c.String(nullable: false),
                        NombrePC = c.String(nullable: false),
                        NSPC = c.String(nullable: false),
                        OSPC = c.String(nullable: false),
                        StatusPC = c.String(nullable: false),
                        ErrorPC = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdPC);
            
            CreateTable(
                "dbo.ReportesCajeros",
                c => new
                    {
                        IdReporteCajero = c.Int(nullable: false, identity: true),
                        IdReporte = c.Int(),
                        IdCajero = c.Int(),
                    })
                .PrimaryKey(t => t.IdReporteCajero)
                .ForeignKey("dbo.Cajeros", t => t.IdCajero)
                .ForeignKey("dbo.Reportes", t => t.IdReporte)
                .Index(t => t.IdReporte)
                .Index(t => t.IdCajero);
            
            CreateTable(
                "dbo.Reportes",
                c => new
                    {
                        IdReporte = c.Int(nullable: false, identity: true),
                        FechaReporte = c.DateTime(nullable: false),
                        CorrectivoReporte = c.String(nullable: false),
                        PreventivoReporte = c.String(nullable: false),
                        TecnicoReporte = c.String(nullable: false),
                        NombreReporte = c.String(nullable: false),
                        NSReporte = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdReporte);
            
            CreateTable(
                "dbo.Scanners",
                c => new
                    {
                        IdScanner = c.Int(nullable: false, identity: true),
                        MarcaScanner = c.String(nullable: false),
                        ModeloScanner = c.String(nullable: false),
                        NombreScanner = c.String(nullable: false),
                        NSScanner = c.String(nullable: false),
                        StatusScanner = c.String(nullable: false),
                        ErrorScanner = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdScanner);
            
            CreateTable(
                "dbo.Sucursales",
                c => new
                    {
                        IdSucursal = c.Int(nullable: false, identity: true),
                        SupervisorCajero = c.String(nullable: false),
                        EmpresaSucursal = c.String(nullable: false),
                        TelefonoSucursal = c.Int(nullable: false),
                        GerenteSucursal = c.String(nullable: false),
                        DireccionSucursal = c.String(nullable: false),
                        NombreSucursal = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdSucursal);
            
            CreateTable(
                "dbo.Tarjetas",
                c => new
                    {
                        IdTarjeta = c.Int(nullable: false, identity: true),
                        ModeloTarjeta = c.String(nullable: false),
                        NSTarjeta = c.String(nullable: false),
                        StatusTarjeta = c.String(nullable: false),
                        ErrorTarjeta = c.Boolean(nullable: false),
                        MarcaTarjeta = c.String(nullable: false),
                        NombreTarjeta = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdTarjeta);
            
            CreateTable(
                "dbo.TonelerosA",
                c => new
                    {
                        IdToneleroA = c.Int(nullable: false, identity: true),
                        NombreTonelero = c.String(nullable: false),
                        ModeloTonelero = c.String(nullable: false),
                        NSTonelero = c.String(nullable: false),
                        StatusTonelero = c.String(nullable: false),
                        TipoMoneda = c.String(nullable: false),
                        EfectivoActualTonelero = c.Int(nullable: false),
                        EfectivoDispensadoTonelero = c.Int(nullable: false),
                        EfectivoInicialTonelero = c.Int(nullable: false),
                        ErrorTonelero = c.Boolean(nullable: false),
                        MarcaTonelero = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdToneleroA);
            
            CreateTable(
                "dbo.TonelerosB",
                c => new
                    {
                        IdToneleroB = c.Int(nullable: false, identity: true),
                        NombreTonelero = c.String(nullable: false),
                        ModeloTonelero = c.String(nullable: false),
                        NSTonelero = c.String(nullable: false),
                        StatusTonelero = c.String(nullable: false),
                        TipoMoneda = c.String(nullable: false),
                        EfectivoActualTonelero = c.Int(nullable: false),
                        EfectivoDispensadoTonelero = c.Int(nullable: false),
                        EfectivoInicialTonelero = c.Int(nullable: false),
                        ErrorTonelero = c.Boolean(nullable: false),
                        MarcaTonelero = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdToneleroB);
            
            CreateTable(
                "dbo.UPes",
                c => new
                    {
                        IdUPS = c.Int(nullable: false, identity: true),
                        MarcaUPS = c.String(nullable: false),
                        ModeloUPS = c.String(nullable: false),
                        NombreUPS = c.String(nullable: false),
                        NSUPS = c.String(nullable: false),
                        StatusUPS = c.String(nullable: false),
                        ErrorUPS = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdUPS);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IsConnected = c.Boolean(nullable: false),
                        Name = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        AlterEmail = c.String(),
                        AlterPhoneNumber = c.String(),
                        Email = c.String(nullable: false, maxLength: 256),
                        PhoneNumber = c.String(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        Cleinte_IdCliente = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.Cleinte_IdCliente)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Cleinte_IdCliente);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Connections",
                c => new
                    {
                        ConnectionID = c.String(nullable: false, maxLength: 128),
                        UserAgent = c.String(),
                        Connected = c.Boolean(nullable: false),
                        ConnectionDate = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ConnectionID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ConversationRooms",
                c => new
                    {
                        RoomName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.RoomName);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.ApplicationUserCajeroes",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Cajero_IdCajero = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Cajero_IdCajero })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cajeros", t => t.Cajero_IdCajero, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Cajero_IdCajero);
            
            CreateTable(
                "dbo.ConversationRoomApplicationUsers",
                c => new
                    {
                        ConversationRoom_RoomName = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ConversationRoom_RoomName, t.ApplicationUser_Id })
                .ForeignKey("dbo.ConversationRooms", t => t.ConversationRoom_RoomName, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.ConversationRoom_RoomName)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ConversationRoomApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ConversationRoomApplicationUsers", "ConversationRoom_RoomName", "dbo.ConversationRooms");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Connections", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Cleinte_IdCliente", "dbo.Clientes");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserCajeroes", "Cajero_IdCajero", "dbo.Cajeros");
            DropForeignKey("dbo.ApplicationUserCajeroes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cajeros", "IdUPS", "dbo.UPes");
            DropForeignKey("dbo.Cajeros", "IdToneleroB", "dbo.TonelerosB");
            DropForeignKey("dbo.Cajeros", "IdToneleroA", "dbo.TonelerosA");
            DropForeignKey("dbo.Cajeros", "IdTarjeta", "dbo.Tarjetas");
            DropForeignKey("dbo.Cajeros", "IdSucursal", "dbo.Sucursales");
            DropForeignKey("dbo.Cajeros", "IdScanner", "dbo.Scanners");
            DropForeignKey("dbo.ReportesCajeros", "IdReporte", "dbo.Reportes");
            DropForeignKey("dbo.ReportesCajeros", "IdCajero", "dbo.Cajeros");
            DropForeignKey("dbo.Cajeros", "IdPC", "dbo.PCes");
            DropForeignKey("dbo.Cajeros", "IdMonitor", "dbo.Monitores");
            DropForeignKey("dbo.Cajeros", "IdImpresora", "dbo.Impresoras");
            DropForeignKey("dbo.Cajeros", "IdDispensador", "dbo.Dispensadores");
            DropForeignKey("dbo.Cajeros", "IdCliente", "dbo.Clientes");
            DropForeignKey("dbo.Cajeros", "IdAceptador_Monedas", "dbo.Aceptadores_Monedas");
            DropForeignKey("dbo.Cajeros", "IdAceptador_Billetes", "dbo.Aceptadores_Billetes");
            DropIndex("dbo.ConversationRoomApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ConversationRoomApplicationUsers", new[] { "ConversationRoom_RoomName" });
            DropIndex("dbo.ApplicationUserCajeroes", new[] { "Cajero_IdCajero" });
            DropIndex("dbo.ApplicationUserCajeroes", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Connections", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Cleinte_IdCliente" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ReportesCajeros", new[] { "IdCajero" });
            DropIndex("dbo.ReportesCajeros", new[] { "IdReporte" });
            DropIndex("dbo.Cajeros", new[] { "IdToneleroB" });
            DropIndex("dbo.Cajeros", new[] { "IdToneleroA" });
            DropIndex("dbo.Cajeros", new[] { "IdSucursal" });
            DropIndex("dbo.Cajeros", new[] { "IdMonitor" });
            DropIndex("dbo.Cajeros", new[] { "IdScanner" });
            DropIndex("dbo.Cajeros", new[] { "IdUPS" });
            DropIndex("dbo.Cajeros", new[] { "IdTarjeta" });
            DropIndex("dbo.Cajeros", new[] { "IdAceptador_Monedas" });
            DropIndex("dbo.Cajeros", new[] { "IdImpresora" });
            DropIndex("dbo.Cajeros", new[] { "IdPC" });
            DropIndex("dbo.Cajeros", new[] { "IdCliente" });
            DropIndex("dbo.Cajeros", new[] { "IdDispensador" });
            DropIndex("dbo.Cajeros", new[] { "IdAceptador_Billetes" });
            DropTable("dbo.ConversationRoomApplicationUsers");
            DropTable("dbo.ApplicationUserCajeroes");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ConversationRooms");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Connections");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UPes");
            DropTable("dbo.TonelerosB");
            DropTable("dbo.TonelerosA");
            DropTable("dbo.Tarjetas");
            DropTable("dbo.Sucursales");
            DropTable("dbo.Scanners");
            DropTable("dbo.Reportes");
            DropTable("dbo.ReportesCajeros");
            DropTable("dbo.PCes");
            DropTable("dbo.Monitores");
            DropTable("dbo.Impresoras");
            DropTable("dbo.Dispensadores");
            DropTable("dbo.Clientes");
            DropTable("dbo.Aceptadores_Monedas");
            DropTable("dbo.Cajeros");
            DropTable("dbo.Aceptadores_Billetes");
        }
    }
}
