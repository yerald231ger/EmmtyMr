namespace EMMTY_GO_WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<EMMTY_GO_WEB.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EMMTY_GO_WEB.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            
            context.Aceptadores_Billetes.AddOrUpdate(ab => ab.IdAceptador_Billetes,
             new Aceptador_Billetes
             {
                 IdAceptador_Billetes = 1,
                 ErrorAceptador_Billetes = "NoError",
                 MarcaAceptador_Billetes = "MEI CASHFLOW",
                 ModeloAceptador_Billetes = "MEI SCNL",
                 NombreAceptador_Billetes = "Aceptador MEI",
                 StatusAceptador_Billetes = false,
                 NSAceptador_Billetes = "658475120001"
             },
             new Aceptador_Billetes
             {
                 IdAceptador_Billetes = 2,
                 ErrorAceptador_Billetes = "NoError",
                 MarcaAceptador_Billetes = "MEI CASHFLOW",
                 ModeloAceptador_Billetes = "MEI SCNL",
                 NombreAceptador_Billetes = "Aceptador MEI",
                 StatusAceptador_Billetes = false,
                 NSAceptador_Billetes = "658475120002"
             },
             new Aceptador_Billetes
             {
                 IdAceptador_Billetes = 3,
                 ErrorAceptador_Billetes = "NoError",
                 MarcaAceptador_Billetes = "MEI CASHFLOW",
                 ModeloAceptador_Billetes = "MEI SCNL",
                 NombreAceptador_Billetes = "Aceptador MEI",
                 StatusAceptador_Billetes = false,
                 NSAceptador_Billetes = "658475120003"
             },
              new Aceptador_Billetes
              {
                  IdAceptador_Billetes = 4,
                  ErrorAceptador_Billetes = "NoError",
                  MarcaAceptador_Billetes = "MEI CASHFLOW",
                  ModeloAceptador_Billetes = "MEI SCNL",
                  NombreAceptador_Billetes = "Aceptador MEI",
                  StatusAceptador_Billetes = false,
                  NSAceptador_Billetes = "658475120004"
              },
             new Aceptador_Billetes
             {
                 IdAceptador_Billetes = 5,
                 ErrorAceptador_Billetes = "NoError",
                 MarcaAceptador_Billetes = "MEI CASHFLOW",
                 ModeloAceptador_Billetes = "MEI SCNL",
                 NombreAceptador_Billetes = "Aceptador MEI",
                 StatusAceptador_Billetes = false,
                 NSAceptador_Billetes = "658475120005"
             },
             new Aceptador_Billetes
             {
                 IdAceptador_Billetes = 6,
                 ErrorAceptador_Billetes = "NoError",
                 MarcaAceptador_Billetes = "MEI CASHFLOW",
                 ModeloAceptador_Billetes = "MEI SCNL",
                 NombreAceptador_Billetes = "Aceptador MEI",
                 StatusAceptador_Billetes = false,
                 NSAceptador_Billetes = "658475120006"
             }, new Aceptador_Billetes
             {
                 IdAceptador_Billetes = 7,
                 ErrorAceptador_Billetes = "NoError",
                 MarcaAceptador_Billetes = "MEI CASHFLOW",
                 ModeloAceptador_Billetes = "MEI SCNL",
                 NombreAceptador_Billetes = "Aceptador MEI",
                 StatusAceptador_Billetes = false,
                 NSAceptador_Billetes = "658475120007"
             },
             new Aceptador_Billetes
             {
                 IdAceptador_Billetes = 8,
                 ErrorAceptador_Billetes = "NoError",
                 MarcaAceptador_Billetes = "MEI CASHFLOW",
                 ModeloAceptador_Billetes = "MEI SCNL",
                 NombreAceptador_Billetes = "Aceptador MEI",
                 StatusAceptador_Billetes = false,
                 NSAceptador_Billetes = "658475120008"
             },
             new Aceptador_Billetes
             {
                 IdAceptador_Billetes = 9,
                 ErrorAceptador_Billetes = "NoError",
                 MarcaAceptador_Billetes = "MEI CASHFLOW",
                 ModeloAceptador_Billetes = "MEI SCNL",
                 NombreAceptador_Billetes = "Aceptador MEI",
                 StatusAceptador_Billetes = false,
                 NSAceptador_Billetes = "658475120009"
             }, new Aceptador_Billetes
             {
                 IdAceptador_Billetes = 10,
                 ErrorAceptador_Billetes = "NoError",
                 MarcaAceptador_Billetes = "MEI CASHFLOW",
                 ModeloAceptador_Billetes = "MEI SCNL",
                 NombreAceptador_Billetes = "Aceptador MEI",
                 StatusAceptador_Billetes = false,
                 NSAceptador_Billetes = "6584751200010"
             },
             new Aceptador_Billetes
             {
                 IdAceptador_Billetes = 11,
                 ErrorAceptador_Billetes = "NoError",
                 MarcaAceptador_Billetes = "MEI CASHFLOW",
                 ModeloAceptador_Billetes = "MEI SCNL",
                 NombreAceptador_Billetes = "Aceptador MEI",
                 StatusAceptador_Billetes = false,
                 NSAceptador_Billetes = "6584751200011"
             },
             new Aceptador_Billetes
             {
                 IdAceptador_Billetes = 12,
                 ErrorAceptador_Billetes = "NoError",
                 MarcaAceptador_Billetes = "MEI CASHFLOW",
                 ModeloAceptador_Billetes = "MEI SCNL",
                 NombreAceptador_Billetes = "Aceptador MEI",
                 StatusAceptador_Billetes = false,
                 NSAceptador_Billetes = "6584751200012"
             }, new Aceptador_Billetes
             {
                 IdAceptador_Billetes = 13,
                 ErrorAceptador_Billetes = "NoError",
                 MarcaAceptador_Billetes = "MEI CASHFLOW",
                 ModeloAceptador_Billetes = "MEI SCNL",
                 NombreAceptador_Billetes = "Aceptador MEI",
                 StatusAceptador_Billetes = false,
                 NSAceptador_Billetes = "6584751200013"
             },
             new Aceptador_Billetes
             {
                 IdAceptador_Billetes = 14,
                 ErrorAceptador_Billetes = "NoError",
                 MarcaAceptador_Billetes = "MEI CASHFLOW",
                 ModeloAceptador_Billetes = "MEI SCNL",
                 NombreAceptador_Billetes = "Aceptador MEI",
                 StatusAceptador_Billetes = false,
                 NSAceptador_Billetes = "6584751200014"
             },
             new Aceptador_Billetes
             {
                 IdAceptador_Billetes = 15,
                 ErrorAceptador_Billetes = "NoError",
                 MarcaAceptador_Billetes = "MEI CASHFLOW",
                 ModeloAceptador_Billetes = "MEI SCNL",
                 NombreAceptador_Billetes = "Aceptador MEI",
                 StatusAceptador_Billetes = false,
                 NSAceptador_Billetes = "6584751200015"
             });

            context.Aceptadores_Monedas.AddOrUpdate(am => am.IdAceptador_Monedas,
                new Aceptador_Monedas
                {
                    IdAceptador_Monedas = 1,
                    ErrorAceptador_Monedas = "NoError",
                    MarcaAceptador_Monedas = "MEI",
                    ModeloAceptador_Monedas = "330",
                    NombreAceptador_Monedas = "Aceptador Monedas MEI",
                    StatusAceptador_Monedas = false,
                    NSAceptador_Monedas = "65847GB000001"
                },
                new Aceptador_Monedas
                {
                    IdAceptador_Monedas = 2,
                    ErrorAceptador_Monedas = "NoError",
                    MarcaAceptador_Monedas = "MEI",
                    ModeloAceptador_Monedas = "330",
                    NombreAceptador_Monedas = "Aceptador Monedas MEI",
                    StatusAceptador_Monedas = false,
                    NSAceptador_Monedas = "65847GB000002"
                },
                new Aceptador_Monedas
                {
                    IdAceptador_Monedas = 3,
                    ErrorAceptador_Monedas = "NoError",
                    MarcaAceptador_Monedas = "MEI",
                    ModeloAceptador_Monedas = "330",
                    NombreAceptador_Monedas = "Aceptador Monedas MEI",
                    StatusAceptador_Monedas = false,
                    NSAceptador_Monedas = "65847GB000003"
                },
                new Aceptador_Monedas
                {
                    IdAceptador_Monedas = 4,
                    ErrorAceptador_Monedas = "NoError",
                    MarcaAceptador_Monedas = "MEI",
                    ModeloAceptador_Monedas = "330",
                    NombreAceptador_Monedas = "Aceptador Monedas MEI",
                    StatusAceptador_Monedas = false,
                    NSAceptador_Monedas = "65847GB000004"
                },
                new Aceptador_Monedas
                {
                    IdAceptador_Monedas = 5,
                    ErrorAceptador_Monedas = "NoError",
                    MarcaAceptador_Monedas = "MEI",
                    ModeloAceptador_Monedas = "330",
                    NombreAceptador_Monedas = "Aceptador Monedas MEI",
                    StatusAceptador_Monedas = false,
                    NSAceptador_Monedas = "65847GB000005"
                },
                new Aceptador_Monedas
                {
                    IdAceptador_Monedas = 6,
                    ErrorAceptador_Monedas = "NoError",
                    MarcaAceptador_Monedas = "MEI",
                    ModeloAceptador_Monedas = "330",
                    NombreAceptador_Monedas = "Aceptador Monedas MEI",
                    StatusAceptador_Monedas = false,
                    NSAceptador_Monedas = "65847GB000006"
                },
                new Aceptador_Monedas
                {
                    IdAceptador_Monedas = 7,
                    ErrorAceptador_Monedas = "NoError",
                    MarcaAceptador_Monedas = "MEI",
                    ModeloAceptador_Monedas = "330",
                    NombreAceptador_Monedas = "Aceptador Monedas MEI",
                    StatusAceptador_Monedas = false,
                    NSAceptador_Monedas = "65847GB000007"
                },
                new Aceptador_Monedas
                {
                    IdAceptador_Monedas = 8,
                    ErrorAceptador_Monedas = "NoError",
                    MarcaAceptador_Monedas = "MEI",
                    ModeloAceptador_Monedas = "330",
                    NombreAceptador_Monedas = "Aceptador Monedas MEI",
                    StatusAceptador_Monedas = false,
                    NSAceptador_Monedas = "65847GB000008"
                },
                new Aceptador_Monedas
                {
                    IdAceptador_Monedas = 9,
                    ErrorAceptador_Monedas = "NoError",
                    MarcaAceptador_Monedas = "MEI",
                    ModeloAceptador_Monedas = "330",
                    NombreAceptador_Monedas = "Aceptador Monedas MEI",
                    StatusAceptador_Monedas = false,
                    NSAceptador_Monedas = "65847GB000009"
                },
                new Aceptador_Monedas
                {
                    IdAceptador_Monedas = 10,
                    ErrorAceptador_Monedas = "NoError",
                    MarcaAceptador_Monedas = "MEI",
                    ModeloAceptador_Monedas = "330",
                    NombreAceptador_Monedas = "Aceptador Monedas MEI",
                    StatusAceptador_Monedas = false,
                    NSAceptador_Monedas = "65847GB0000010"
                },
                new Aceptador_Monedas
                {
                    IdAceptador_Monedas = 11,
                    ErrorAceptador_Monedas = "NoError",
                    MarcaAceptador_Monedas = "MEI",
                    ModeloAceptador_Monedas = "330",
                    NombreAceptador_Monedas = "Aceptador Monedas MEI",
                    StatusAceptador_Monedas = false,
                    NSAceptador_Monedas = "65847GB0000011"
                },
                new Aceptador_Monedas
                {
                    IdAceptador_Monedas = 12,
                    ErrorAceptador_Monedas = "NoError",
                    MarcaAceptador_Monedas = "MEI",
                    ModeloAceptador_Monedas = "330",
                    NombreAceptador_Monedas = "Aceptador Monedas MEI",
                    StatusAceptador_Monedas = false,
                    NSAceptador_Monedas = "65847GB0000012"
                },
                new Aceptador_Monedas
                {
                    IdAceptador_Monedas = 13,
                    ErrorAceptador_Monedas = "NoError",
                    MarcaAceptador_Monedas = "MEI",
                    ModeloAceptador_Monedas = "330",
                    NombreAceptador_Monedas = "Aceptador Monedas MEI",
                    StatusAceptador_Monedas = false,
                    NSAceptador_Monedas = "65847GB0000013"
                },
                new Aceptador_Monedas
                {
                    IdAceptador_Monedas = 14,
                    ErrorAceptador_Monedas = "NoError",
                    MarcaAceptador_Monedas = "MEI",
                    ModeloAceptador_Monedas = "330",
                    NombreAceptador_Monedas = "Aceptador Monedas MEI",
                    StatusAceptador_Monedas = false,
                    NSAceptador_Monedas = "65847GB0000014"
                },
                new Aceptador_Monedas
                {
                    IdAceptador_Monedas = 15,
                    ErrorAceptador_Monedas = "NoError",
                    MarcaAceptador_Monedas = "MEI",
                    ModeloAceptador_Monedas = "330",
                    NombreAceptador_Monedas = "Aceptador Monedas MEI",
                    StatusAceptador_Monedas = false,
                    NSAceptador_Monedas = "65847GB0000015"
                });

            context.Monitores.AddOrUpdate(mon => mon.IdMonitor,
                new Monitor
                {
                    IdMonitor = 1,
                    ErrorMonitor = "NoError",
                    MarcaMonitor = "ELO Technologies",
                    ModeloMonitor = "ELO 3210",
                    NombreMonitor = "Monitor Touch",
                    StatusMonitor = false,
                    NSMonitor = "AL2454223SS01"
                },
                new Monitor
                {
                    IdMonitor = 2,
                    ErrorMonitor = "NoError",
                    MarcaMonitor = "ELO Technologies",
                    ModeloMonitor = "ELO 3210",
                    NombreMonitor = "Monitor Touch",
                    StatusMonitor = false,
                    NSMonitor = "AL2454223SS02"
                },
                new Monitor
                {
                    IdMonitor = 3,
                    ErrorMonitor = "NoError",
                    MarcaMonitor = "ELO Technologies",
                    ModeloMonitor = "ELO 3210",
                    NombreMonitor = "Monitor Touch",
                    StatusMonitor = false,
                    NSMonitor = "AL2454223SS03"
                },
                new Monitor
                {
                    IdMonitor = 4,
                    ErrorMonitor = "NoError",
                    MarcaMonitor = "ELO Technologies",
                    ModeloMonitor = "ELO 3210",
                    NombreMonitor = "Monitor Touch",
                    StatusMonitor = false,
                    NSMonitor = "AL2454223SS04"
                },
                new Monitor
                {
                    IdMonitor = 5,
                    ErrorMonitor = "NoError",
                    MarcaMonitor = "ELO Technologies",
                    ModeloMonitor = "ELO 3210",
                    NombreMonitor = "Monitor Touch",
                    StatusMonitor = false,
                    NSMonitor = "AL2454223SS05"
                },
                new Monitor
                {
                    IdMonitor = 6,
                    ErrorMonitor = "NoError",
                    MarcaMonitor = "ELO Technologies",
                    ModeloMonitor = "ELO 3210",
                    NombreMonitor = "Monitor Touch",
                    StatusMonitor = false,
                    NSMonitor = "AL2454223SS06"
                },
                new Monitor
                {
                    IdMonitor = 7,
                    ErrorMonitor = "NoError",
                    MarcaMonitor = "ELO Technologies",
                    ModeloMonitor = "ELO 3210",
                    NombreMonitor = "Monitor Touch",
                    StatusMonitor = false,
                    NSMonitor = "AL2454223SS07"
                },
                new Monitor
                {
                    IdMonitor = 8,
                    ErrorMonitor = "NoError",
                    MarcaMonitor = "ELO Technologies",
                    ModeloMonitor = "ELO 3210",
                    NombreMonitor = "Monitor Touch",
                    StatusMonitor = false,
                    NSMonitor = "AL2454223SS08"
                },
                new Monitor
                {
                    IdMonitor = 9,
                    ErrorMonitor = "NoError",
                    MarcaMonitor = "ELO Technologies",
                    ModeloMonitor = "ELO 3210",
                    NombreMonitor = "Monitor Touch",
                    StatusMonitor = false,
                    NSMonitor = "AL2454223SS09"
                },
                new Monitor
                {
                    IdMonitor = 10,
                    ErrorMonitor = "NoError",
                    MarcaMonitor = "ELO Technologies",
                    ModeloMonitor = "ELO 3210",
                    NombreMonitor = "Monitor Touch",
                    StatusMonitor = false,
                    NSMonitor = "AL2454223SS010"
                },
                new Monitor
                {
                    IdMonitor = 11,
                    ErrorMonitor = "NoError",
                    MarcaMonitor = "ELO Technologies",
                    ModeloMonitor = "ELO 3210",
                    NombreMonitor = "Monitor Touch",
                    StatusMonitor = false,
                    NSMonitor = "AL2454223SS011"
                },
                new Monitor
                {
                    IdMonitor = 12,
                    ErrorMonitor = "NoError",
                    MarcaMonitor = "ELO Technologies",
                    ModeloMonitor = "ELO 3210",
                    NombreMonitor = "Monitor Touch",
                    StatusMonitor = false,
                    NSMonitor = "AL2454223SS012"
                },
                new Monitor
                {
                    IdMonitor = 13,
                    ErrorMonitor = "NoError",
                    MarcaMonitor = "ELO Technologies",
                    ModeloMonitor = "ELO 3210",
                    NombreMonitor = "Monitor Touch",
                    StatusMonitor = false,
                    NSMonitor = "AL2454223SS013"
                },
                new Monitor
                {
                    IdMonitor = 14,
                    ErrorMonitor = "NoError",
                    MarcaMonitor = "ELO Technologies",
                    ModeloMonitor = "ELO 3210",
                    NombreMonitor = "Monitor Touch",
                    StatusMonitor = false,
                    NSMonitor = "AL2454223SS014"
                },
                new Monitor
                {
                    IdMonitor = 15,
                    ErrorMonitor = "NoError",
                    MarcaMonitor = "ELO Technologies",
                    ModeloMonitor = "ELO 3210",
                    NombreMonitor = "Monitor Touch",
                    StatusMonitor = false,
                    NSMonitor = "AL2454223SS015"
                });

            context.Impresoras.AddOrUpdate(imp => imp.IdImpresora,
                new Impresora
                {
                    IdImpresora = 1,
                    ErrorImpresora = "NoError",
                    MarcaImpresora = "Zebra Technologies",
                    ModeloImpresora = "TTP-2030",
                    NombreImpresora = "Impresora Zebra",
                    StatusImpresora = false,
                    NSImpresora = "04000AB3020101",
                    PapelImpresora = false
                },
                new Impresora
                {
                    IdImpresora = 2,
                    ErrorImpresora = "NoError",
                    MarcaImpresora = "Zebra Technologies",
                    ModeloImpresora = "TTP-2030",
                    NombreImpresora = "Impresora Zebra",
                    StatusImpresora = false,
                    NSImpresora = "04000AB3020102",
                    PapelImpresora = false
                },
                new Impresora
                {
                    IdImpresora = 3,
                    ErrorImpresora = "NoError",
                    MarcaImpresora = "Zebra Technologies",
                    ModeloImpresora = "TTP-2030",
                    NombreImpresora = "Impresora Zebra",
                    StatusImpresora = false,
                    NSImpresora = "04000AB3020103",
                    PapelImpresora = false
                },
                new Impresora
                {
                    IdImpresora = 4,
                    ErrorImpresora = "NoError",
                    MarcaImpresora = "Zebra Technologies",
                    ModeloImpresora = "TTP-2030",
                    NombreImpresora = "Impresora Zebra",
                    StatusImpresora = false,
                    NSImpresora = "04000AB3020104",
                    PapelImpresora = false
                },
                new Impresora
                {
                    IdImpresora = 5,
                    ErrorImpresora = "NoError",
                    MarcaImpresora = "Zebra Technologies",
                    ModeloImpresora = "TTP-2030",
                    NombreImpresora = "Impresora Zebra",
                    StatusImpresora = false,
                    NSImpresora = "04000AB3020105",
                    PapelImpresora = false
                },
                new Impresora
                {
                    IdImpresora = 6,
                    ErrorImpresora = "NoError",
                    MarcaImpresora = "Zebra Technologies",
                    ModeloImpresora = "TTP-2030",
                    NombreImpresora = "Impresora Zebra",
                    StatusImpresora = false,
                    NSImpresora = "04000AB3020106",
                    PapelImpresora = false
                },
                new Impresora
                {
                    IdImpresora = 7,
                    ErrorImpresora = "NoError",
                    MarcaImpresora = "Zebra Technologies",
                    ModeloImpresora = "TTP-2030",
                    NombreImpresora = "Impresora Zebra",
                    StatusImpresora = false,
                    NSImpresora = "04000AB3020107",
                    PapelImpresora = false
                },
                new Impresora
                {
                    IdImpresora = 8,
                    ErrorImpresora = "NoError",
                    MarcaImpresora = "Zebra Technologies",
                    ModeloImpresora = "TTP-2030",
                    NombreImpresora = "Impresora Zebra",
                    StatusImpresora = false,
                    NSImpresora = "04000AB3020108",
                    PapelImpresora = false
                },
                new Impresora
                {
                    IdImpresora = 9,
                    ErrorImpresora = "NoError",
                    MarcaImpresora = "Zebra Technologies",
                    ModeloImpresora = "TTP-2030",
                    NombreImpresora = "Impresora Zebra",
                    StatusImpresora = false,
                    NSImpresora = "04000AB3020109",
                    PapelImpresora = false
                },
                new Impresora
                {
                    IdImpresora = 10,
                    ErrorImpresora = "NoError",
                    MarcaImpresora = "Zebra Technologies",
                    ModeloImpresora = "TTP-2030",
                    NombreImpresora = "Impresora Zebra",
                    StatusImpresora = false,
                    NSImpresora = "04000AB30201010",
                    PapelImpresora = false
                },
                new Impresora
                {
                    IdImpresora = 11,
                    ErrorImpresora = "NoError",
                    MarcaImpresora = "Zebra Technologies",
                    ModeloImpresora = "TTP-2030",
                    NombreImpresora = "Impresora Zebra",
                    StatusImpresora = false,
                    NSImpresora = "04000AB30201011",
                    PapelImpresora = false
                },
                new Impresora
                {
                    IdImpresora = 12,
                    ErrorImpresora = "NoError",
                    MarcaImpresora = "Zebra Technologies",
                    ModeloImpresora = "TTP-2030",
                    NombreImpresora = "Impresora Zebra",
                    StatusImpresora = false,
                    NSImpresora = "04000AB30201012",
                    PapelImpresora = false
                },
                new Impresora
                {
                    IdImpresora = 13,
                    ErrorImpresora = "NoError",
                    MarcaImpresora = "Zebra Technologies",
                    ModeloImpresora = "TTP-2030",
                    NombreImpresora = "Impresora Zebra",
                    StatusImpresora = false,
                    NSImpresora = "04000AB30201013",
                    PapelImpresora = false
                },
                new Impresora
                {
                    IdImpresora = 14,
                    ErrorImpresora = "NoError",
                    MarcaImpresora = "Zebra Technologies",
                    ModeloImpresora = "TTP-2030",
                    NombreImpresora = "Impresora Zebra",
                    StatusImpresora = false,
                    NSImpresora = "04000AB30201014",
                    PapelImpresora = false
                },
                new Impresora
                {
                    IdImpresora = 15,
                    ErrorImpresora = "NoError",
                    MarcaImpresora = "Zebra Technologies",
                    ModeloImpresora = "TTP-2030",
                    NombreImpresora = "Impresora Zebra",
                    StatusImpresora = false,
                    NSImpresora = "04000AB30201015",
                    PapelImpresora = false
                });

            context.PCes.AddOrUpdate(pc => pc.IdPC,
                new PC
                {
                    IdPC = 1,
                    ErrorPC = "NoError",
                    MarcaPC = "HP",
                    ModeloPC = "ProDesk SFF",
                    NombrePC = "Computadora",
                    StatusPC = false,
                    NSPC = "MXL54265VKA1",
                    OSPC = "Windows 7"
                },
                new PC
                {
                    IdPC = 2,
                    ErrorPC = "NoError",
                    MarcaPC = "HP",
                    ModeloPC = "ProDesk SFF",
                    NombrePC = "Computadora",
                    StatusPC = false,
                    NSPC = "MXL54265VKB2",
                    OSPC = "Windows 7"
                },
                new PC
                {
                    IdPC = 3,
                    ErrorPC = "NoError",
                    MarcaPC = "HP",
                    ModeloPC = "ProDesk SFF",
                    NombrePC = "Computadora",
                    StatusPC = false,
                    NSPC = "MXL54265VKC3",
                    OSPC = "Windows 7"
                },
                new PC
                {
                    IdPC = 4,
                    ErrorPC = "NoError",
                    MarcaPC = "HP",
                    ModeloPC = "ProDesk SFF",
                    NombrePC = "Computadora",
                    StatusPC = false,
                    NSPC = "MXL54265VKC4",
                    OSPC = "Windows 7"
                },
                new PC
                {
                    IdPC = 5,
                    ErrorPC = "NoError",
                    MarcaPC = "HP",
                    ModeloPC = "ProDesk SFF",
                    NombrePC = "Computadora",
                    StatusPC = false,
                    NSPC = "MXL54265VKC5",
                    OSPC = "Windows 7"
                },
                new PC
                {
                    IdPC = 6,
                    ErrorPC = "NoError",
                    MarcaPC = "HP",
                    ModeloPC = "ProDesk SFF",
                    NombrePC = "Computadora",
                    StatusPC = false,
                    NSPC = "MXL54265VKC6",
                    OSPC = "Windows 7"
                },
                new PC
                {
                    IdPC = 7,
                    ErrorPC = "NoError",
                    MarcaPC = "HP",
                    ModeloPC = "ProDesk SFF",
                    NombrePC = "Computadora",
                    StatusPC = false,
                    NSPC = "MXL54265VKC7",
                    OSPC = "Windows 7"
                },
                new PC
                {
                    IdPC = 8,
                    ErrorPC = "NoError",
                    MarcaPC = "HP",
                    ModeloPC = "ProDesk SFF",
                    NombrePC = "Computadora",
                    StatusPC = false,
                    NSPC = "MXL54265VKC8",
                    OSPC = "Windows 7"
                },
                new PC
                {
                    IdPC = 9,
                    ErrorPC = "NoError",
                    MarcaPC = "HP",
                    ModeloPC = "ProDesk SFF",
                    NombrePC = "Computadora",
                    StatusPC = false,
                    NSPC = "MXL54265VKC9",
                    OSPC = "Windows 7"
                },
                new PC
                {
                    IdPC = 10,
                    ErrorPC = "NoError",
                    MarcaPC = "HP",
                    ModeloPC = "ProDesk SFF",
                    NombrePC = "Computadora",
                    StatusPC = false,
                    NSPC = "MXL54265VKC10",
                    OSPC = "Windows 7"
                },
                new PC
                {
                    IdPC = 11,
                    ErrorPC = "NoError",
                    MarcaPC = "HP",
                    ModeloPC = "ProDesk SFF",
                    NombrePC = "Computadora",
                    StatusPC = false,
                    NSPC = "MXL54265VKC11",
                    OSPC = "Windows 7"
                },
                new PC
                {
                    IdPC = 12,
                    ErrorPC = "NoError",
                    MarcaPC = "HP",
                    ModeloPC = "ProDesk SFF",
                    NombrePC = "Computadora",
                    StatusPC = false,
                    NSPC = "MXL54265VKC12",
                    OSPC = "Windows 7"
                },
                new PC
                {
                    IdPC = 13,
                    ErrorPC = "NoError",
                    MarcaPC = "HP",
                    ModeloPC = "ProDesk SFF",
                    NombrePC = "Computadora",
                    StatusPC = false,
                    NSPC = "MXL54265VKC13",
                    OSPC = "Windows 7"
                },
                new PC
                {
                    IdPC = 14,
                    ErrorPC = "NoError",
                    MarcaPC = "HP",
                    ModeloPC = "ProDesk SFF",
                    NombrePC = "Computadora",
                    StatusPC = false,
                    NSPC = "MXL54265VKC14",
                    OSPC = "Windows 7"
                },
                new PC
                {
                    IdPC = 15,
                    ErrorPC = "NoError",
                    MarcaPC = "HP",
                    ModeloPC = "ProDesk SFF",
                    NombrePC = "Computadora",
                    StatusPC = false,
                    NSPC = "MXL54265VKC15",
                    OSPC = "Windows 7"
                });

            context.Scanners.AddOrUpdate(sca => sca.IdScanner,
                new Scanner
                {
                    IdScanner = 1,
                    ErrorScanner = "NoError",
                    MarcaScanner = "MetroLogic",
                    ModeloScanner = "Ninguno",
                    NombreScanner = "Scaner",
                    NSScanner = "602014501",
                    StatusScanner = false
                },
                new Scanner
                {
                    IdScanner = 2,
                    ErrorScanner = "NoError",
                    MarcaScanner = "MetroLogic",
                    ModeloScanner = "Ninguno",
                    NombreScanner = "Scaner",
                    NSScanner = "602014502",
                    StatusScanner = false
                },
                new Scanner
                {
                    IdScanner = 3,
                    ErrorScanner = "NoError",
                    MarcaScanner = "MetroLogic",
                    ModeloScanner = "Ninguno",
                    NombreScanner = "Scaner",
                    NSScanner = "602014503",
                    StatusScanner = false
                },
                new Scanner
                {
                    IdScanner = 4,
                    ErrorScanner = "NoError",
                    MarcaScanner = "MetroLogic",
                    ModeloScanner = "Ninguno",
                    NombreScanner = "Scaner",
                    NSScanner = "602014504",
                    StatusScanner = false
                },
                new Scanner
                {
                    IdScanner = 5,
                    ErrorScanner = "NoError",
                    MarcaScanner = "MetroLogic",
                    ModeloScanner = "Ninguno",
                    NombreScanner = "Scaner",
                    NSScanner = "602014505",
                    StatusScanner = false
                },
                new Scanner
                {
                    IdScanner = 6,
                    ErrorScanner = "NoError",
                    MarcaScanner = "MetroLogic",
                    ModeloScanner = "Ninguno",
                    NombreScanner = "Scaner",
                    NSScanner = "602014506",
                    StatusScanner = false
                },
                new Scanner
                {
                    IdScanner = 7,
                    ErrorScanner = "NoError",
                    MarcaScanner = "MetroLogic",
                    ModeloScanner = "Ninguno",
                    NombreScanner = "Scaner",
                    NSScanner = "602014507",
                    StatusScanner = false
                },
                new Scanner
                {
                    IdScanner = 8,
                    ErrorScanner = "NoError",
                    MarcaScanner = "MetroLogic",
                    ModeloScanner = "Ninguno",
                    NombreScanner = "Scaner",
                    NSScanner = "602014508",
                    StatusScanner = false
                },
                new Scanner
                {
                    IdScanner = 9,
                    ErrorScanner = "NoError",
                    MarcaScanner = "MetroLogic",
                    ModeloScanner = "Ninguno",
                    NombreScanner = "Scaner",
                    NSScanner = "602014509",
                    StatusScanner = false
                },
                new Scanner
                {
                    IdScanner = 10,
                    ErrorScanner = "NoError",
                    MarcaScanner = "MetroLogic",
                    ModeloScanner = "Ninguno",
                    NombreScanner = "Scaner",
                    NSScanner = "6020145010",
                    StatusScanner = false
                },
                new Scanner
                {
                    IdScanner = 11,
                    ErrorScanner = "NoError",
                    MarcaScanner = "MetroLogic",
                    ModeloScanner = "Ninguno",
                    NombreScanner = "Scaner",
                    NSScanner = "6020145011",
                    StatusScanner = false
                },
                new Scanner
                {
                    IdScanner = 12,
                    ErrorScanner = "NoError",
                    MarcaScanner = "MetroLogic",
                    ModeloScanner = "Ninguno",
                    NombreScanner = "Scaner",
                    NSScanner = "6020145012",
                    StatusScanner = false
                },
                new Scanner
                {
                    IdScanner = 13,
                    ErrorScanner = "NoError",
                    MarcaScanner = "MetroLogic",
                    ModeloScanner = "Ninguno",
                    NombreScanner = "Scaner",
                    NSScanner = "6020145013",
                    StatusScanner = false
                },
                new Scanner
                {
                    IdScanner = 14,
                    ErrorScanner = "NoError",
                    MarcaScanner = "MetroLogic",
                    ModeloScanner = "Ninguno",
                    NombreScanner = "Scaner",
                    NSScanner = "6020145014",
                    StatusScanner = false
                },
                new Scanner
                {
                    IdScanner = 15,
                    ErrorScanner = "NoError",
                    MarcaScanner = "MetroLogic",
                    ModeloScanner = "Ninguno",
                    NombreScanner = "Scaner",
                    NSScanner = "6020145015",
                    StatusScanner = false
                });

            context.Tarjetas.AddOrUpdate(t => t.IdTarjeta,
                new Tarjeta
                {
                    IdTarjeta = 1,
                    ErrorTarjeta = "NoError",
                    MarcaTarjeta = "tarjeta",
                    ModeloTarjeta = "EM-001",
                    NombreTarjeta = "EM",
                    NSTarjeta = "07000231",
                    StatusTarjeta = false
                },
                new Tarjeta
                {
                    IdTarjeta = 2,
                    ErrorTarjeta = "NoError",
                    MarcaTarjeta = "tarjeta",
                    ModeloTarjeta = "EM-001",
                    NombreTarjeta = "EM",
                    NSTarjeta = "07000232",
                    StatusTarjeta = false
                },
                new Tarjeta
                {
                    IdTarjeta = 3,
                    ErrorTarjeta = "NoError",
                    MarcaTarjeta = "tarjeta",
                    ModeloTarjeta = "EM-001",
                    NombreTarjeta = "EM",
                    NSTarjeta = "07000233",
                    StatusTarjeta = false
                },
                new Tarjeta
                {
                    IdTarjeta = 4,
                    ErrorTarjeta = "NoError",
                    MarcaTarjeta = "tarjeta",
                    ModeloTarjeta = "EM-001",
                    NombreTarjeta = "EM",
                    NSTarjeta = "07000234",
                    StatusTarjeta = false
                },
                new Tarjeta
                {
                    IdTarjeta = 5,
                    ErrorTarjeta = "NoError",
                    MarcaTarjeta = "tarjeta",
                    ModeloTarjeta = "EM-001",
                    NombreTarjeta = "EM",
                    NSTarjeta = "07000235",
                    StatusTarjeta = false
                },
                new Tarjeta
                {
                    IdTarjeta = 6,
                    ErrorTarjeta = "NoError",
                    MarcaTarjeta = "tarjeta",
                    ModeloTarjeta = "EM-001",
                    NombreTarjeta = "EM",
                    NSTarjeta = "07000236",
                    StatusTarjeta = false
                },
                new Tarjeta
                {
                    IdTarjeta = 7,
                    ErrorTarjeta = "NoError",
                    MarcaTarjeta = "tarjeta",
                    ModeloTarjeta = "EM-001",
                    NombreTarjeta = "EM",
                    NSTarjeta = "07000237",
                    StatusTarjeta = false
                },
                new Tarjeta
                {
                    IdTarjeta = 8,
                    ErrorTarjeta = "NoError",
                    MarcaTarjeta = "tarjeta",
                    ModeloTarjeta = "EM-001",
                    NombreTarjeta = "EM",
                    NSTarjeta = "07000238",
                    StatusTarjeta = false
                },
                new Tarjeta
                {
                    IdTarjeta = 9,
                    ErrorTarjeta = "NoError",
                    MarcaTarjeta = "tarjeta",
                    ModeloTarjeta = "EM-001",
                    NombreTarjeta = "EM",
                    NSTarjeta = "07000239",
                    StatusTarjeta = false
                },
                new Tarjeta
                {
                    IdTarjeta = 10,
                    ErrorTarjeta = "NoError",
                    MarcaTarjeta = "tarjeta",
                    ModeloTarjeta = "EM-001",
                    NombreTarjeta = "EM",
                    NSTarjeta = "070002310",
                    StatusTarjeta = false
                },
                new Tarjeta
                {
                    IdTarjeta = 11,
                    ErrorTarjeta = "NoError",
                    MarcaTarjeta = "tarjeta",
                    ModeloTarjeta = "EM-001",
                    NombreTarjeta = "EM",
                    NSTarjeta = "070002311",
                    StatusTarjeta = false
                },
                new Tarjeta
                {
                    IdTarjeta = 12,
                    ErrorTarjeta = "NoError",
                    MarcaTarjeta = "tarjeta",
                    ModeloTarjeta = "EM-001",
                    NombreTarjeta = "EM",
                    NSTarjeta = "070002312",
                    StatusTarjeta = false
                },
                new Tarjeta
                {
                    IdTarjeta = 13,
                    ErrorTarjeta = "NoError",
                    MarcaTarjeta = "tarjeta",
                    ModeloTarjeta = "EM-001",
                    NombreTarjeta = "EM",
                    NSTarjeta = "070002313",
                    StatusTarjeta = false
                },
                new Tarjeta
                {
                    IdTarjeta = 14,
                    ErrorTarjeta = "NoError",
                    MarcaTarjeta = "tarjeta",
                    ModeloTarjeta = "EM-001",
                    NombreTarjeta = "EM",
                    NSTarjeta = "070002314",
                    StatusTarjeta = false
                },
                new Tarjeta
                {
                    IdTarjeta = 15,
                    ErrorTarjeta = "NoError",
                    MarcaTarjeta = "tarjeta",
                    ModeloTarjeta = "EM-001",
                    NombreTarjeta = "EM",
                    NSTarjeta = "070002315",
                    StatusTarjeta = false
                });

            context.TonelerosA.AddOrUpdate(ton => ton.IdToneleroA,
                new ToneleroA
                {
                    IdToneleroA = 1,
                    TipoMoneda = "1 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 1 Peso",
                    NombreTonelero = "Tonelero de un Peso",
                    NSTonelero = "9-07000221",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroA
                {
                    IdToneleroA = 2,
                    TipoMoneda = "1 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 1 Peso",
                    NombreTonelero = "Tonelero de un Peso",
                    NSTonelero = "9-07000222",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroA
                {
                    IdToneleroA = 3,
                    TipoMoneda = "1 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 1 Peso",
                    NombreTonelero = "Tonelero de un Peso",
                    NSTonelero = "9-07000223",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroA
                {
                    IdToneleroA = 4,
                    TipoMoneda = "1 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 1 Peso",
                    NombreTonelero = "Tonelero de un Peso",
                    NSTonelero = "9-07000224",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroA
                {
                    IdToneleroA = 5,
                    TipoMoneda = "1 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 1 Peso",
                    NombreTonelero = "Tonelero de un Peso",
                    NSTonelero = "9-07000225",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroA
                {
                    IdToneleroA = 6,
                    TipoMoneda = "1 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 1 Peso",
                    NombreTonelero = "Tonelero de un Peso",
                    NSTonelero = "9-07000226",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroA
                {
                    IdToneleroA = 7,
                    TipoMoneda = "1 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 1 Peso",
                    NombreTonelero = "Tonelero de un Peso",
                    NSTonelero = "9-07000227",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroA
                {
                    IdToneleroA = 8,
                    TipoMoneda = "1 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 1 Peso",
                    NombreTonelero = "Tonelero de un Peso",
                    NSTonelero = "9-07000228",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroA
                {
                    IdToneleroA = 9,
                    TipoMoneda = "1 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 1 Peso",
                    NombreTonelero = "Tonelero de un Peso",
                    NSTonelero = "9-07000229",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroA
                {
                    IdToneleroA = 10,
                    TipoMoneda = "1 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 1 Peso",
                    NombreTonelero = "Tonelero de un Peso",
                    NSTonelero = "9-070002210",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroA
                {
                    IdToneleroA = 11,
                    TipoMoneda = "1 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 1 Peso",
                    NombreTonelero = "Tonelero de un Peso",
                    NSTonelero = "9-070002211",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroA
                {
                    IdToneleroA = 12,
                    TipoMoneda = "1 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 1 Peso",
                    NombreTonelero = "Tonelero de un Peso",
                    NSTonelero = "9-070002212",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroA
                {
                    IdToneleroA = 13,
                    TipoMoneda = "1 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 1 Peso",
                    NombreTonelero = "Tonelero de un Peso",
                    NSTonelero = "9-070002213",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroA
                {
                    IdToneleroA = 14,
                    TipoMoneda = "1 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 1 Peso",
                    NombreTonelero = "Tonelero de un Peso",
                    NSTonelero = "9-070002214",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroA
                {
                    IdToneleroA = 15,
                    TipoMoneda = "1 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 1 Peso",
                    NombreTonelero = "Tonelero de un Peso",
                    NSTonelero = "9-070002215",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                });

            context.TonelerosB.AddOrUpdate(ton => ton.IdToneleroB,
                new ToneleroB
                {
                    IdToneleroB = 1,
                    TipoMoneda = "5 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 5 Peso",
                    NombreTonelero = "Tonelero de Cinco Pesos",
                    NSTonelero = "9-070002221",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroB
                {
                    IdToneleroB = 2,
                    TipoMoneda = "5 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 5 Peso",
                    NombreTonelero = "Tonelero de Cinco Pesos",
                    NSTonelero = "9-070002242",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroB
                {
                    IdToneleroB = 3,
                    TipoMoneda = "5 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 5 Peso",
                    NombreTonelero = "Tonelero de Cinco Pesos",
                    NSTonelero = "9-070002263",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroB
                {
                    IdToneleroB = 4,
                    TipoMoneda = "5 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 5 Peso",
                    NombreTonelero = "Tonelero de Cinco Pesos",
                    NSTonelero = "9-070002264",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroB
                {
                    IdToneleroB = 5,
                    TipoMoneda = "5 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 5 Peso",
                    NombreTonelero = "Tonelero de Cinco Pesos",
                    NSTonelero = "9-070002265",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroB
                {
                    IdToneleroB = 6,
                    TipoMoneda = "5 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 5 Peso",
                    NombreTonelero = "Tonelero de Cinco Pesos",
                    NSTonelero = "9-070002266",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroB
                {
                    IdToneleroB = 7,
                    TipoMoneda = "5 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 5 Peso",
                    NombreTonelero = "Tonelero de Cinco Pesos",
                    NSTonelero = "9-070002267",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroB
                {
                    IdToneleroB = 8,
                    TipoMoneda = "5 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 5 Peso",
                    NombreTonelero = "Tonelero de Cinco Pesos",
                    NSTonelero = "9-070002268",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroB
                {
                    IdToneleroB = 9,
                    TipoMoneda = "5 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 5 Peso",
                    NombreTonelero = "Tonelero de Cinco Pesos",
                    NSTonelero = "9-070002269",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroB
                {
                    IdToneleroB = 10,
                    TipoMoneda = "5 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 5 Peso",
                    NombreTonelero = "Tonelero de Cinco Pesos",
                    NSTonelero = "9-0700022610",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroB
                {
                    IdToneleroB = 11,
                    TipoMoneda = "5 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 5 Peso",
                    NombreTonelero = "Tonelero de Cinco Pesos",
                    NSTonelero = "9-0700022611",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroB
                {
                    IdToneleroB = 12,
                    TipoMoneda = "5 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 5 Peso",
                    NombreTonelero = "Tonelero de Cinco Pesos",
                    NSTonelero = "9-0700022612",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroB
                {
                    IdToneleroB = 13,
                    TipoMoneda = "5 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 5 Peso",
                    NombreTonelero = "Tonelero de Cinco Pesos",
                    NSTonelero = "9-0700022613",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroB
                {
                    IdToneleroB = 14,
                    TipoMoneda = "5 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 5 Peso",
                    NombreTonelero = "Tonelero de Cinco Pesos",
                    NSTonelero = "9-0700022614",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                },
                new ToneleroB
                {
                    IdToneleroB = 15,
                    TipoMoneda = "5 Peso",
                    ErrorTonelero = "NoError",
                    MarcaTonelero = "Standar",
                    ModeloTonelero = "Standar Hopper Mex 5 Peso",
                    NombreTonelero = "Tonelero de Cinco Pesos",
                    NSTonelero = "9-0700022615",
                    StatusTonelero = false,
                    EfectivoActualTonelero = 0,
                    EfectivoDispensadoTonelero = 0,
                    EfectivoInicialTonelero = 0
                });

            context.Dispensadores.AddOrUpdate(ton => ton.IdDispensador,
                new Dispensador
                {
                    IdDispensador = 1,
                    TipoBillete = "50 Peso",
                    ErrorDispensador = "NoError",
                    MarcaDispensador = "MiniMech",
                    ModeloDispensador = "MiniMech Tellaris",
                    NombreDispensador = "Dispensador de Billetes",
                    NSDispensador = "10243321",
                    StatusDispensador = false,
                    EfectivoActualDispensador = 0,
                    EfectivoDispensadoDispensador = 0,
                    EfectivoInicialDispensador = 0
                },
                new Dispensador
                {
                    IdDispensador = 2,
                    TipoBillete = "50 Peso",
                    ErrorDispensador = "NoError",
                    MarcaDispensador = "MiniMech",
                    ModeloDispensador = "MiniMech Tellaris",
                    NombreDispensador = "Dispensador de Billetes",
                    NSDispensador = "10243322",
                    StatusDispensador = false,
                    EfectivoActualDispensador = 0,
                    EfectivoDispensadoDispensador = 0,
                    EfectivoInicialDispensador = 0
                },
                new Dispensador
                {
                    IdDispensador = 3,
                    TipoBillete = "50 Peso",
                    ErrorDispensador = "NoError",
                    MarcaDispensador = "MiniMech",
                    ModeloDispensador = "MiniMech Tellaris",
                    NombreDispensador = "Dispensador de Billetes",
                    NSDispensador = "10243323",
                    StatusDispensador = false,
                    EfectivoActualDispensador = 0,
                    EfectivoDispensadoDispensador = 0,
                    EfectivoInicialDispensador = 0
                },
                new Dispensador
                {
                    IdDispensador = 4,
                    TipoBillete = "50 Peso",
                    ErrorDispensador = "NoError",
                    MarcaDispensador = "MiniMech",
                    ModeloDispensador = "MiniMech Tellaris",
                    NombreDispensador = "Dispensador de Billetes",
                    NSDispensador = "10243324",
                    StatusDispensador = false,
                    EfectivoActualDispensador = 0,
                    EfectivoDispensadoDispensador = 0,
                    EfectivoInicialDispensador = 0
                },
                new Dispensador
                {
                    IdDispensador = 5,
                    TipoBillete = "50 Peso",
                    ErrorDispensador = "NoError",
                    MarcaDispensador = "MiniMech",
                    ModeloDispensador = "MiniMech Tellaris",
                    NombreDispensador = "Dispensador de Billetes",
                    NSDispensador = "10243325",
                    StatusDispensador = false,
                    EfectivoActualDispensador = 0,
                    EfectivoDispensadoDispensador = 0,
                    EfectivoInicialDispensador = 0
                },
                new Dispensador
                {
                    IdDispensador = 6,
                    TipoBillete = "50 Peso",
                    ErrorDispensador = "NoError",
                    MarcaDispensador = "MiniMech",
                    ModeloDispensador = "MiniMech Tellaris",
                    NombreDispensador = "Dispensador de Billetes",
                    NSDispensador = "10243326",
                    StatusDispensador = false,
                    EfectivoActualDispensador = 0,
                    EfectivoDispensadoDispensador = 0,
                    EfectivoInicialDispensador = 0
                },
                new Dispensador
                {
                    IdDispensador = 7,
                    TipoBillete = "50 Peso",
                    ErrorDispensador = "NoError",
                    MarcaDispensador = "MiniMech",
                    ModeloDispensador = "MiniMech Tellaris",
                    NombreDispensador = "Dispensador de Billetes",
                    NSDispensador = "10243327",
                    StatusDispensador = false,
                    EfectivoActualDispensador = 0,
                    EfectivoDispensadoDispensador = 0,
                    EfectivoInicialDispensador = 0
                },
                new Dispensador
                {
                    IdDispensador = 8,
                    TipoBillete = "50 Peso",
                    ErrorDispensador = "NoError",
                    MarcaDispensador = "MiniMech",
                    ModeloDispensador = "MiniMech Tellaris",
                    NombreDispensador = "Dispensador de Billetes",
                    NSDispensador = "10243328",
                    StatusDispensador = false,
                    EfectivoActualDispensador = 0,
                    EfectivoDispensadoDispensador = 0,
                    EfectivoInicialDispensador = 0
                },
                new Dispensador
                {
                    IdDispensador = 9,
                    TipoBillete = "50 Peso",
                    ErrorDispensador = "NoError",
                    MarcaDispensador = "MiniMech",
                    ModeloDispensador = "MiniMech Tellaris",
                    NombreDispensador = "Dispensador de Billetes",
                    NSDispensador = "10243329",
                    StatusDispensador = false,
                    EfectivoActualDispensador = 0,
                    EfectivoDispensadoDispensador = 0,
                    EfectivoInicialDispensador = 0
                },
                new Dispensador
                {
                    IdDispensador = 10,
                    TipoBillete = "50 Peso",
                    ErrorDispensador = "NoError",
                    MarcaDispensador = "MiniMech",
                    ModeloDispensador = "MiniMech Tellaris",
                    NombreDispensador = "Dispensador de Billetes",
                    NSDispensador = "102433210",
                    StatusDispensador = false,
                    EfectivoActualDispensador = 0,
                    EfectivoDispensadoDispensador = 0,
                    EfectivoInicialDispensador = 0
                },
                new Dispensador
                {
                    IdDispensador = 11,
                    TipoBillete = "50 Peso",
                    ErrorDispensador = "NoError",
                    MarcaDispensador = "MiniMech",
                    ModeloDispensador = "MiniMech Tellaris",
                    NombreDispensador = "Dispensador de Billetes",
                    NSDispensador = "102433211",
                    StatusDispensador = false,
                    EfectivoActualDispensador = 0,
                    EfectivoDispensadoDispensador = 0,
                    EfectivoInicialDispensador = 0
                },
                new Dispensador
                {
                    IdDispensador = 12,
                    TipoBillete = "50 Peso",
                    ErrorDispensador = "NoError",
                    MarcaDispensador = "MiniMech",
                    ModeloDispensador = "MiniMech Tellaris",
                    NombreDispensador = "Dispensador de Billetes",
                    NSDispensador = "102433212",
                    StatusDispensador = false,
                    EfectivoActualDispensador = 0,
                    EfectivoDispensadoDispensador = 0,
                    EfectivoInicialDispensador = 0
                },
                new Dispensador
                {
                    IdDispensador = 13,
                    TipoBillete = "50 Peso",
                    ErrorDispensador = "NoError",
                    MarcaDispensador = "MiniMech",
                    ModeloDispensador = "MiniMech Tellaris",
                    NombreDispensador = "Dispensador de Billetes",
                    NSDispensador = "102433213",
                    StatusDispensador = false,
                    EfectivoActualDispensador = 0,
                    EfectivoDispensadoDispensador = 0,
                    EfectivoInicialDispensador = 0
                },
                new Dispensador
                {
                    IdDispensador = 14,
                    TipoBillete = "50 Peso",
                    ErrorDispensador = "NoError",
                    MarcaDispensador = "MiniMech",
                    ModeloDispensador = "MiniMech Tellaris",
                    NombreDispensador = "Dispensador de Billetes",
                    NSDispensador = "102433214",
                    StatusDispensador = false,
                    EfectivoActualDispensador = 0,
                    EfectivoDispensadoDispensador = 0,
                    EfectivoInicialDispensador = 0
                },
                new Dispensador
                {
                    IdDispensador = 15,
                    TipoBillete = "50 Peso",
                    ErrorDispensador = "NoError",
                    MarcaDispensador = "MiniMech",
                    ModeloDispensador = "MiniMech Tellaris",
                    NombreDispensador = "Dispensador de Billetes",
                    NSDispensador = "102433215",
                    StatusDispensador = false,
                    EfectivoActualDispensador = 0,
                    EfectivoDispensadoDispensador = 0,
                    EfectivoInicialDispensador = 0
                });

            context.UPSes.AddOrUpdate(u => u.IdUPS,
                new UPS
                {
                    IdUPS = 1,
                    ErrorUPS = "NoError",
                    MarcaUPS = "Trip-Lite",
                    ModeloUPS = "Trip-Lite 25130",
                    NombreUPS = "UPS",
                    NSUPS = "20150231MVO65971841",
                    StatusUPS = false
                },
                new UPS
                {
                    IdUPS = 2,
                    ErrorUPS = "NoError",
                    MarcaUPS = "Trip-Lite",
                    ModeloUPS = "Trip-Lite 25130",
                    NombreUPS = "UPS",
                    NSUPS = "20150231MVO65971842",
                    StatusUPS = false
                },
                new UPS
                {
                    IdUPS = 3,
                    ErrorUPS = "NoError",
                    MarcaUPS = "Trip-Lite",
                    ModeloUPS = "Trip-Lite 25130",
                    NombreUPS = "UPS",
                    NSUPS = "20150231MVO65971843",
                    StatusUPS = false
                },
                new UPS
                {
                    IdUPS = 4,
                    ErrorUPS = "NoError",
                    MarcaUPS = "Trip-Lite",
                    ModeloUPS = "Trip-Lite 25130",
                    NombreUPS = "UPS",
                    NSUPS = "20150231MVO65971844",
                    StatusUPS = false
                },
                new UPS
                {
                    IdUPS = 5,
                    ErrorUPS = "NoError",
                    MarcaUPS = "Trip-Lite",
                    ModeloUPS = "Trip-Lite 25130",
                    NombreUPS = "UPS",
                    NSUPS = "20150231MVO65971845",
                    StatusUPS = false
                },
                new UPS
                {
                    IdUPS = 6,
                    ErrorUPS = "NoError",
                    MarcaUPS = "Trip-Lite",
                    ModeloUPS = "Trip-Lite 25130",
                    NombreUPS = "UPS",
                    NSUPS = "20150231MVO65971846",
                    StatusUPS = false
                },
                new UPS
                {
                    IdUPS = 7,
                    ErrorUPS = "NoError",
                    MarcaUPS = "Trip-Lite",
                    ModeloUPS = "Trip-Lite 25130",
                    NombreUPS = "UPS",
                    NSUPS = "20150231MVO65971847",
                    StatusUPS = false
                },
                new UPS
                {
                    IdUPS = 8,
                    ErrorUPS = "NoError",
                    MarcaUPS = "Trip-Lite",
                    ModeloUPS = "Trip-Lite 25130",
                    NombreUPS = "UPS",
                    NSUPS = "20150231MVO65971848",
                    StatusUPS = false
                },
                new UPS
                {
                    IdUPS = 9,
                    ErrorUPS = "NoError",
                    MarcaUPS = "Trip-Lite",
                    ModeloUPS = "Trip-Lite 25130",
                    NombreUPS = "UPS",
                    NSUPS = "20150231MVO65971849",
                    StatusUPS = false
                },
                new UPS
                {
                    IdUPS = 10,
                    ErrorUPS = "NoError",
                    MarcaUPS = "Trip-Lite",
                    ModeloUPS = "Trip-Lite 25130",
                    NombreUPS = "UPS",
                    NSUPS = "20150231MVO659718410",
                    StatusUPS = false
                },
                new UPS
                {
                    IdUPS = 11,
                    ErrorUPS = "NoError",
                    MarcaUPS = "Trip-Lite",
                    ModeloUPS = "Trip-Lite 25130",
                    NombreUPS = "UPS",
                    NSUPS = "20150231MVO659718411",
                    StatusUPS = false
                },
                new UPS
                {
                    IdUPS = 12,
                    ErrorUPS = "NoError",
                    MarcaUPS = "Trip-Lite",
                    ModeloUPS = "Trip-Lite 25130",
                    NombreUPS = "UPS",
                    NSUPS = "20150231MVO659718412",
                    StatusUPS = false
                },
                new UPS
                {
                    IdUPS = 13,
                    ErrorUPS = "NoError",
                    MarcaUPS = "Trip-Lite",
                    ModeloUPS = "Trip-Lite 25130",
                    NombreUPS = "UPS",
                    NSUPS = "20150231MVO659718413",
                    StatusUPS = false
                },
                new UPS
                {
                    IdUPS = 14,
                    ErrorUPS = "NoError",
                    MarcaUPS = "Trip-Lite",
                    ModeloUPS = "Trip-Lite 25130",
                    NombreUPS = "UPS",
                    NSUPS = "20150231MVO659718414",
                    StatusUPS = false
                },
                new UPS
                {
                    IdUPS = 15,
                    ErrorUPS = "NoError",
                    MarcaUPS = "Trip-Lite",
                    ModeloUPS = "Trip-Lite 25130",
                    NombreUPS = "UPS",
                    NSUPS = "20150231MVO659718415",
                    StatusUPS = false
                });

            context.Reportes.AddOrUpdate(r => r.IdReporte,
                new Reporte
                {
                    IdReporte = 1,
                    CorrectivoReporte = "Ninguno",
                    FechaReporte = new DateTime(2015, 02, 21),
                    NombreReporte = "Mantenimiento Cable",
                    NSReporte = "20003651",
                    PreventivoReporte = "Ninguno",
                    TecnicoReporte = "Emiliano"
                },
                new Reporte
                {
                    IdReporte = 2,
                    CorrectivoReporte = "Ninguno",
                    FechaReporte = new DateTime(2015, 02, 21),
                    NombreReporte = "Mantenimiento Cable",
                    NSReporte = "20003652",
                    PreventivoReporte = "Ninguno",
                    TecnicoReporte = "Emiliano"
                },
                new Reporte
                {
                    IdReporte = 3,
                    CorrectivoReporte = "Ninguno",
                    FechaReporte = new DateTime(2015, 02, 21),
                    NombreReporte = "Mantenimiento Cable",
                    NSReporte = "20003653",
                    PreventivoReporte = "Ninguno",
                    TecnicoReporte = "Emiliano"
                },
                new Reporte
                {
                    IdReporte = 4,
                    CorrectivoReporte = "Ninguno",
                    FechaReporte = new DateTime(2015, 02, 21),
                    NombreReporte = "Mantenimiento Cable",
                    NSReporte = "20003654",
                    PreventivoReporte = "Ninguno",
                    TecnicoReporte = "Emiliano"
                },
                new Reporte
                {
                    IdReporte = 5,
                    CorrectivoReporte = "Ninguno",
                    FechaReporte = new DateTime(2015, 02, 21),
                    NombreReporte = "Mantenimiento Cable",
                    NSReporte = "20003655",
                    PreventivoReporte = "Ninguno",
                    TecnicoReporte = "Emiliano"
                },
                new Reporte
                {
                    IdReporte = 6,
                    CorrectivoReporte = "Ninguno",
                    FechaReporte = new DateTime(2015, 02, 21),
                    NombreReporte = "Mantenimiento Cable",
                    NSReporte = "20003656",
                    PreventivoReporte = "Ninguno",
                    TecnicoReporte = "Emiliano"
                },
                new Reporte
                {
                    IdReporte = 7,
                    CorrectivoReporte = "Ninguno",
                    FechaReporte = new DateTime(2015, 02, 21),
                    NombreReporte = "Mantenimiento Cable",
                    NSReporte = "20003657",
                    PreventivoReporte = "Ninguno",
                    TecnicoReporte = "Emiliano"
                },
                new Reporte
                {
                    IdReporte = 8,
                    CorrectivoReporte = "Ninguno",
                    FechaReporte = new DateTime(2015, 02, 21),
                    NombreReporte = "Mantenimiento Cable",
                    NSReporte = "20003658",
                    PreventivoReporte = "Ninguno",
                    TecnicoReporte = "Emiliano"
                },
                new Reporte
                {
                    IdReporte = 9,
                    CorrectivoReporte = "Ninguno",
                    FechaReporte = new DateTime(2015, 02, 21),
                    NombreReporte = "Mantenimiento Cable",
                    NSReporte = "20003659",
                    PreventivoReporte = "Ninguno",
                    TecnicoReporte = "Emiliano"
                },
                new Reporte
                {
                    IdReporte = 10,
                    CorrectivoReporte = "Ninguno",
                    FechaReporte = new DateTime(2015, 02, 21),
                    NombreReporte = "Mantenimiento Cable",
                    NSReporte = "200036510",
                    PreventivoReporte = "Ninguno",
                    TecnicoReporte = "Emiliano"
                },
                new Reporte
                {
                    IdReporte = 11,
                    CorrectivoReporte = "Ninguno",
                    FechaReporte = new DateTime(2015, 02, 21),
                    NombreReporte = "Mantenimiento Cable",
                    NSReporte = "2000365111",
                    PreventivoReporte = "Ninguno",
                    TecnicoReporte = "Emiliano"
                },
                new Reporte
                {
                    IdReporte = 12,
                    CorrectivoReporte = "Ninguno",
                    FechaReporte = new DateTime(2015, 02, 21),
                    NombreReporte = "Mantenimiento Cable",
                    NSReporte = "2000365312",
                    PreventivoReporte = "Ninguno",
                    TecnicoReporte = "Emiliano"
                },
                new Reporte
                {
                    IdReporte = 13,
                    CorrectivoReporte = "Ninguno",
                    FechaReporte = new DateTime(2015, 02, 21),
                    NombreReporte = "Mantenimiento Cable",
                    NSReporte = "2000365113",
                    PreventivoReporte = "Ninguno",
                    TecnicoReporte = "Emiliano"
                },
                new Reporte
                {
                    IdReporte = 14,
                    CorrectivoReporte = "Ninguno",
                    FechaReporte = new DateTime(2015, 02, 21),
                    NombreReporte = "Mantenimiento Cable",
                    NSReporte = "2000365214",
                    PreventivoReporte = "Ninguno",
                    TecnicoReporte = "Emiliano"
                },
                new Reporte
                {
                    IdReporte = 15,
                    CorrectivoReporte = "Ninguno",
                    FechaReporte = new DateTime(2015, 02, 21),
                    NombreReporte = "Mantenimiento Cable",
                    NSReporte = "2000365315",
                    PreventivoReporte = "Ninguno",
                    TecnicoReporte = "Emiliano"
                },
                new Reporte
                {
                    IdReporte = 16,
                    CorrectivoReporte = "Ninguno",
                    FechaReporte = new DateTime(2015, 02, 21),
                    NombreReporte = "Mantenimiento Cable",
                    NSReporte = "2000365116",
                    PreventivoReporte = "Ninguno",
                    TecnicoReporte = "Emiliano"
                },
                new Reporte
                {
                    IdReporte = 17,
                    CorrectivoReporte = "Ninguno",
                    FechaReporte = new DateTime(2015, 02, 21),
                    NombreReporte = "Mantenimiento Cable",
                    NSReporte = "2000365217",
                    PreventivoReporte = "Ninguno",
                    TecnicoReporte = "Emiliano"
                },
                new Reporte
                {
                    IdReporte = 18,
                    CorrectivoReporte = "Ninguno",
                    FechaReporte = new DateTime(2015, 02, 21),
                    NombreReporte = "Mantenimiento Cable",
                    NSReporte = "2000365318",
                    PreventivoReporte = "Ninguno",
                    TecnicoReporte = "Emiliano"
                });

            context.Sucursales.AddOrUpdate(s => s.IdSucursal,
                new Sucursal
                {
                    IdSucursal = 1,
                    DireccionSucursal = "Ninguna",
                    EmpresaSucursal = "CableVision",
                    GerenteSucursal = "Ninguno",
                    NombreSucursal = "Matriz",
                    SupervisorCajero = "Ninguno",
                    TelefonoSucursal = 818001
                },
                new Sucursal
                {
                    IdSucursal = 2,
                    DireccionSucursal = "Ninguna",
                    EmpresaSucursal = "CableVision",
                    GerenteSucursal = "Ninguno",
                    NombreSucursal = "Lincol",
                    SupervisorCajero = "Ninguno",
                    TelefonoSucursal = 818002
                },
                new Sucursal
                {
                    IdSucursal = 3,
                    DireccionSucursal = "Ninguna",
                    EmpresaSucursal = "CableVision",
                    GerenteSucursal = "Ninguno",
                    NombreSucursal = "Saltillo",
                    SupervisorCajero = "Ninguno",
                    TelefonoSucursal = 818003
                },
                new Sucursal
                {
                    IdSucursal = 4,
                    DireccionSucursal = "Ninguna",
                    EmpresaSucursal = "Prosis",
                    GerenteSucursal = "Ninguno",
                    NombreSucursal = "Chihuahua",
                    SupervisorCajero = "Ninguno",
                    TelefonoSucursal = 818004
                },
                new Sucursal
                {
                    IdSucursal = 5,
                    DireccionSucursal = "Ninguna",
                    EmpresaSucursal = "Prosis",
                    GerenteSucursal = "Ninguno",
                    NombreSucursal = "Monterrey",
                    SupervisorCajero = "Ninguno",
                    TelefonoSucursal = 818005
                },
                new Sucursal
                {
                    IdSucursal = 6,
                    DireccionSucursal = "Ninguna",
                    EmpresaSucursal = "Prosis",
                    GerenteSucursal = "Ninguno",
                    NombreSucursal = "Centro Comercial",
                    SupervisorCajero = "Ninguno",
                    TelefonoSucursal = 818006
                });

            context.Clientes.AddOrUpdate(c => c.IdCliente,
                new Cliente
                {
                    IdCliente = 1,
                    LicenciaStatus = "OK",
                    NombreCliente = "CableVision",
                    TipoCliente = "Moral"
                },
                new Cliente
                {
                    IdCliente = 2,
                    LicenciaStatus = "OK",
                    NombreCliente = "Prosis",
                    TipoCliente = "Moral"
                },
                new Cliente
                {
                    IdCliente = 3,
                    LicenciaStatus = "OK",
                    NombreCliente = "EMMTY",
                    TipoCliente = "Moral"
                });

            context.Cajeros.AddOrUpdate(c => c.IdCajero,
                new Cajero
                {
                    IdCajero = 1,
                    IdAceptador_Billetes = 1,
                    IdAceptador_Monedas = 1,
                    IdDispensador = 1,
                    IdImpresora = 1,
                    IdMonitor = 1,
                    IdPC = 1,
                    IdScanner = 1,
                    IdTarjeta = 1,
                    IdUPS = 1,
                    IdToneleroA = 1,
                    IdToneleroB = 1,
                    IdCliente = 1,
                    IdSucursal = 1,
                    TipoCajero = "Apertura Frontal",
                    ModeloCajero = "EZ-PAY 01",
                    NSCajero = "Miditec20150312ger1021",
                    NombreCajero = "Cajero EMMTY",
                    StatusCajero = false,
                    UbicacionCajero = "Ninguna",
                    NombreEnsamblador = "Gerardo Sanchez",
                    ColorCajero = "Naranja",
                    ErrorCajero = "NoError",
                    FechaEnsambladoCajero = new DateTime(2015, 03, 21),
                    FechaEntregaCajero = new DateTime(2015, 03, 24),
                    FechaSalidaCajero = new DateTime(2015, 03, 23),
                    EfectivoActual = 0,
                    EfectivoInicial = 0,
                    EfectivoDispensado = 0,
                    NivelBajoEfectivo = 0,
                    RowUpdate = false
                },
                new Cajero
                {
                    IdCajero = 2,
                    IdAceptador_Billetes = 2,
                    IdAceptador_Monedas = 2,
                    IdDispensador = 2,
                    IdImpresora = 2,
                    IdMonitor = 2,
                    IdPC = 2,
                    IdScanner = 2,
                    IdTarjeta = 2,
                    IdUPS = 2,
                    IdToneleroA = 2,
                    IdToneleroB = 2,
                    IdCliente = 1,
                    IdSucursal = 1,
                    TipoCajero = "Apertura Frontal",
                    ModeloCajero = "EZ-PAY 01",
                    NSCajero = "Miditec20150312ger1022",
                    NombreEnsamblador = "Gerardo Sanchez",
                    NombreCajero = "Cajero EMMTY",
                    StatusCajero = false,
                    UbicacionCajero = "Ninguna",
                    ColorCajero = "Naranja",
                    ErrorCajero = "NoError",
                    FechaEnsambladoCajero = new DateTime(2015, 03, 21),
                    FechaEntregaCajero = new DateTime(2015, 03, 24),
                    FechaSalidaCajero = new DateTime(2015, 03, 23),
                    EfectivoActual = 0,
                    EfectivoInicial = 0,
                    EfectivoDispensado = 0,
                    NivelBajoEfectivo = 0,
                    RowUpdate = false
                },
                new Cajero
                {
                    IdCajero = 3,
                    IdAceptador_Billetes = 3,
                    IdAceptador_Monedas = 3,
                    IdDispensador = 3,
                    IdImpresora = 3,
                    IdMonitor = 3,
                    IdPC = 3,
                    IdScanner = 3,
                    IdTarjeta = 3,
                    IdUPS = 3,
                    IdToneleroA = 3,
                    IdToneleroB = 3,
                    IdCliente = 1,
                    IdSucursal = 2,
                    TipoCajero = "Apertura Frontal",
                    ModeloCajero = "EZ-PAY 01",
                    NSCajero = "Miditec20150312ger1023",
                    NombreCajero = "Cajero EMMTY",
                    StatusCajero = false,
                    NombreEnsamblador = "Gerardo Sanchez",
                    UbicacionCajero = "Ninguna",
                    ColorCajero = "Naranja",
                    ErrorCajero = "NoError",
                    FechaEnsambladoCajero = new DateTime(2015, 03, 21),
                    FechaEntregaCajero = new DateTime(2015, 03, 24),
                    FechaSalidaCajero = new DateTime(2015, 03, 23),
                    EfectivoActual = 0,
                    EfectivoInicial = 0,
                    EfectivoDispensado = 0,
                    NivelBajoEfectivo = 0,
                    RowUpdate = false
                },
                new Cajero
                {
                    IdCajero = 4,
                    IdAceptador_Billetes = 4,
                    IdAceptador_Monedas = 4,
                    IdDispensador = 4,
                    IdImpresora = 4,
                    IdMonitor = 4,
                    IdPC = 4,
                    IdScanner = 4,
                    IdTarjeta = 4,
                    IdUPS = 4,
                    IdToneleroA = 4,
                    IdToneleroB = 4,
                    IdCliente = 1,
                    IdSucursal = 2,
                    TipoCajero = "Apertura Frontal",
                    ModeloCajero = "EZ-PAY 01",
                    NSCajero = "Miditec20150312ger1024",
                    NombreCajero = "Cajero EMMTY",
                    StatusCajero = false,
                    NombreEnsamblador = "Gerardo Sanchez",
                    UbicacionCajero = "Ninguna",
                    ColorCajero = "Naranja",
                    ErrorCajero = "NoError",
                    FechaEnsambladoCajero = new DateTime(2015, 03, 21),
                    FechaEntregaCajero = new DateTime(2015, 03, 24),
                    FechaSalidaCajero = new DateTime(2015, 03, 23),
                    EfectivoActual = 0,
                    EfectivoInicial = 0,
                    EfectivoDispensado = 0,
                    NivelBajoEfectivo = 0,
                    RowUpdate = false
                },
                new Cajero
                {
                    IdCajero = 5,
                    IdAceptador_Billetes = 5,
                    IdAceptador_Monedas = 5,
                    IdDispensador = 5,
                    IdImpresora = 5,
                    IdMonitor = 5,
                    IdPC = 5,
                    IdScanner = 5,
                    IdTarjeta = 5,
                    IdUPS = 5,
                    IdToneleroA = 5,
                    IdToneleroB = 5,
                    IdCliente = 1,
                    IdSucursal = 2,
                    TipoCajero = "Apertura Frontal",
                    ModeloCajero = "EZ-PAY 01",
                    NSCajero = "Miditec20150312ger1025",
                    NombreCajero = "Cajero EMMTY",
                    StatusCajero = false,
                    NombreEnsamblador = "Gerardo Sanchez",
                    UbicacionCajero = "Ninguna",
                    ColorCajero = "Naranja",
                    ErrorCajero = "NoError",
                    FechaEnsambladoCajero = new DateTime(2015, 03, 21),
                    FechaEntregaCajero = new DateTime(2015, 03, 24),
                    FechaSalidaCajero = new DateTime(2015, 03, 23),
                    EfectivoActual = 0,
                    EfectivoInicial = 0,
                    EfectivoDispensado = 0,
                    NivelBajoEfectivo = 0,
                    RowUpdate = false
                },
                new Cajero
                {
                    IdCajero = 6,
                    IdAceptador_Billetes = 6,
                    IdAceptador_Monedas = 6,
                    IdDispensador = 6,
                    IdImpresora = 6,
                    IdMonitor = 6,
                    IdPC = 6,
                    IdScanner = 6,
                    IdTarjeta = 6,
                    IdUPS = 6,
                    IdToneleroA = 6,
                    IdToneleroB = 6,
                    IdCliente = 1,
                    IdSucursal = 3,
                    TipoCajero = "Apertura Frontal",
                    ModeloCajero = "EZ-PAY 01",
                    NSCajero = "Miditec20150312ger1026",
                    NombreCajero = "Cajero EMMTY",
                    StatusCajero = false,
                    NombreEnsamblador = "Gerardo Sanchez",
                    UbicacionCajero = "Ninguna",
                    ColorCajero = "Naranja",
                    ErrorCajero = "NoError",
                    FechaEnsambladoCajero = new DateTime(2015, 03, 21),
                    FechaEntregaCajero = new DateTime(2015, 03, 24),
                    FechaSalidaCajero = new DateTime(2015, 03, 23),
                    EfectivoActual = 0,
                    EfectivoInicial = 0,
                    EfectivoDispensado = 0,
                    NivelBajoEfectivo = 0,
                    RowUpdate = false
                },
                new Cajero
                {
                    IdCajero = 7,
                    IdAceptador_Billetes = 7,
                    IdAceptador_Monedas = 7,
                    IdDispensador = 7,
                    IdImpresora = 7,
                    IdMonitor = 7,
                    IdPC = 7,
                    IdScanner = 7,
                    IdTarjeta = 7,
                    IdUPS = 7,
                    IdToneleroA = 7,
                    IdToneleroB = 7,
                    IdCliente = 1,
                    IdSucursal = 3,
                    TipoCajero = "Apertura Frontal",
                    ModeloCajero = "EZ-PAY 01",
                    NSCajero = "Miditec20150312ger1027",
                    NombreCajero = "Cajero EMMTY",
                    StatusCajero = false,
                    NombreEnsamblador = "Gerardo Sanchez",
                    UbicacionCajero = "Ninguna",
                    ColorCajero = "Naranja",
                    ErrorCajero = "NoError",
                    FechaEnsambladoCajero = new DateTime(2015, 03, 21),
                    FechaEntregaCajero = new DateTime(2015, 03, 24),
                    FechaSalidaCajero = new DateTime(2015, 03, 23),
                    EfectivoActual = 0,
                    EfectivoInicial = 0,
                    EfectivoDispensado = 0,
                    NivelBajoEfectivo = 0,
                    RowUpdate = false
                },
                new Cajero
                {
                    IdCajero = 8,
                    IdAceptador_Billetes = 8,
                    IdAceptador_Monedas = 8,
                    IdDispensador = 8,
                    IdImpresora = 8,
                    IdMonitor = 8,
                    IdPC = 8,
                    IdScanner = 8,
                    IdTarjeta = 8,
                    IdUPS = 8,
                    IdToneleroA = 8,
                    IdToneleroB = 8,
                    IdCliente = 2,
                    IdSucursal = 4,
                    TipoCajero = "Apertura Frontal",
                    ModeloCajero = "EZ-PAY 01",
                    NSCajero = "Miditec20150312ger1028",
                    NombreCajero = "Cajero EMMTY",
                    StatusCajero = false,
                    NombreEnsamblador = "Gerardo Sanchez",
                    UbicacionCajero = "Ninguna",
                    ColorCajero = "Naranja",
                    ErrorCajero = "NoError",
                    FechaEnsambladoCajero = new DateTime(2015, 03, 21),
                    FechaEntregaCajero = new DateTime(2015, 03, 24),
                    FechaSalidaCajero = new DateTime(2015, 03, 23),
                    EfectivoActual = 0,
                    EfectivoInicial = 0,
                    EfectivoDispensado = 0,
                    NivelBajoEfectivo = 0,
                    RowUpdate = false
                },
                new Cajero
                {
                    IdCajero = 9,
                    IdAceptador_Billetes = 9,
                    IdAceptador_Monedas = 9,
                    IdDispensador = 9,
                    IdImpresora = 9,
                    IdMonitor = 9,
                    IdPC = 9,
                    IdScanner = 9,
                    IdTarjeta = 9,
                    IdUPS = 9,
                    IdToneleroA = 9,
                    IdToneleroB = 9,
                    IdCliente = 2,
                    IdSucursal = 4,
                    TipoCajero = "Apertura Frontal",
                    ModeloCajero = "EZ-PAY 01",
                    NSCajero = "Miditec20150312ger1029",
                    NombreCajero = "Cajero EMMTY",
                    StatusCajero = false,
                    NombreEnsamblador = "Gerardo Sanchez",
                    UbicacionCajero = "Ninguna",
                    ColorCajero = "Naranja",
                    ErrorCajero = "NoError",
                    FechaEnsambladoCajero = new DateTime(2015, 03, 21),
                    FechaEntregaCajero = new DateTime(2015, 03, 24),
                    FechaSalidaCajero = new DateTime(2015, 03, 23),
                    EfectivoActual = 0,
                    EfectivoInicial = 0,
                    EfectivoDispensado = 0,
                    NivelBajoEfectivo = 0,
                    RowUpdate = false
                },
                new Cajero
                {
                    IdCajero = 10,
                    IdAceptador_Billetes = 10,
                    IdAceptador_Monedas = 10,
                    IdDispensador = 10,
                    IdImpresora = 10,
                    IdMonitor = 10,
                    IdPC = 10,
                    IdScanner = 10,
                    IdTarjeta = 10,
                    IdUPS = 10,
                    IdToneleroA = 10,
                    IdToneleroB = 10,
                    IdCliente = 2,
                    IdSucursal = 4,
                    TipoCajero = "Apertura Frontal",
                    ModeloCajero = "EZ-PAY 01",
                    NSCajero = "Miditec20150312ger10210",
                    NombreCajero = "Cajero EMMTY",
                    StatusCajero = false,
                    NombreEnsamblador = "Gerardo Sanchez",
                    UbicacionCajero = "Ninguna",
                    ColorCajero = "Naranja",
                    ErrorCajero = "NoError",
                    FechaEnsambladoCajero = new DateTime(2015, 03, 21),
                    FechaEntregaCajero = new DateTime(2015, 03, 24),
                    FechaSalidaCajero = new DateTime(2015, 03, 23),
                    EfectivoActual = 0,
                    EfectivoInicial = 0,
                    EfectivoDispensado = 0,
                    NivelBajoEfectivo = 0,
                    RowUpdate = false
                },
                new Cajero
                {
                    IdCajero = 11,
                    IdAceptador_Billetes = 11,
                    IdAceptador_Monedas = 11,
                    IdDispensador = 11,
                    IdImpresora = 11,
                    IdMonitor = 11,
                    IdPC = 11,
                    IdScanner = 11,
                    IdTarjeta = 11,
                    IdUPS = 11,
                    IdToneleroA = 11,
                    IdToneleroB = 11,
                    IdCliente = 2,
                    IdSucursal = 5,
                    TipoCajero = "Apertura Frontal",
                    ModeloCajero = "EZ-PAY 01",
                    NSCajero = "Miditec20150312ger10211",
                    NombreCajero = "Cajero EMMTY",
                    StatusCajero = false,
                    NombreEnsamblador = "Gerardo Sanchez",
                    UbicacionCajero = "Ninguna",
                    ColorCajero = "Naranja",
                    ErrorCajero = "NoError",
                    FechaEnsambladoCajero = new DateTime(2015, 03, 21),
                    FechaEntregaCajero = new DateTime(2015, 03, 24),
                    FechaSalidaCajero = new DateTime(2015, 03, 23),
                    EfectivoActual = 0,
                    EfectivoInicial = 0,
                    EfectivoDispensado = 0,
                    NivelBajoEfectivo = 0,
                    RowUpdate = false
                },
                new Cajero
                {
                    IdCajero = 12,
                    IdAceptador_Billetes = 12,
                    IdAceptador_Monedas = 12,
                    IdDispensador = 12,
                    IdImpresora = 12,
                    IdMonitor = 12,
                    IdPC = 12,
                    IdScanner = 12,
                    IdTarjeta = 12,
                    IdUPS = 12,
                    IdToneleroA = 12,
                    IdToneleroB = 12,
                    IdCliente = 2,
                    IdSucursal = 5,
                    TipoCajero = "Apertura Frontal",
                    ModeloCajero = "EZ-PAY 01",
                    NSCajero = "Miditec20150312ger10212",
                    NombreCajero = "Cajero EMMTY",
                    StatusCajero = false,
                    NombreEnsamblador = "Gerardo Sanchez",
                    UbicacionCajero = "Ninguna",
                    ColorCajero = "Naranja",
                    ErrorCajero = "NoError",
                    FechaEnsambladoCajero = new DateTime(2015, 03, 21),
                    FechaEntregaCajero = new DateTime(2015, 03, 24),
                    FechaSalidaCajero = new DateTime(2015, 03, 23),
                    EfectivoActual = 0,
                    EfectivoInicial = 0,
                    EfectivoDispensado = 0,
                    NivelBajoEfectivo = 0,
                    RowUpdate = false
                },
                new Cajero
                {
                    IdCajero = 13,
                    IdAceptador_Billetes = 13,
                    IdAceptador_Monedas = 13,
                    IdDispensador = 13,
                    IdImpresora = 13,
                    IdMonitor = 13,
                    IdPC = 13,
                    IdScanner = 13,
                    IdTarjeta = 13,
                    IdUPS = 13,
                    IdToneleroA = 13,
                    IdToneleroB = 13,
                    IdCliente = 2,
                    IdSucursal = 5,
                    TipoCajero = "Apertura Frontal",
                    ModeloCajero = "EZ-PAY 01",
                    NSCajero = "Miditec20150312ger10213",
                    NombreCajero = "Cajero EMMTY",
                    StatusCajero = false,
                    NombreEnsamblador = "Gerardo Sanchez",
                    UbicacionCajero = "Ninguna",
                    ColorCajero = "Naranja",
                    ErrorCajero = "NoError",
                    FechaEnsambladoCajero = new DateTime(2015, 03, 21),
                    FechaEntregaCajero = new DateTime(2015, 03, 24),
                    FechaSalidaCajero = new DateTime(2015, 03, 23),
                    EfectivoActual = 0,
                    EfectivoInicial = 0,
                    EfectivoDispensado = 0,
                    NivelBajoEfectivo = 0,
                    RowUpdate = false
                },
                new Cajero
                {
                    IdCajero = 14,
                    IdAceptador_Billetes = 14,
                    IdAceptador_Monedas = 14,
                    IdDispensador = 14,
                    IdImpresora = 14,
                    IdMonitor = 14,
                    IdPC = 14,
                    IdScanner = 14,
                    IdTarjeta = 14,
                    IdUPS = 14,
                    IdToneleroA = 14,
                    IdToneleroB = 14,
                    IdCliente = 2,
                    IdSucursal = 6,
                    TipoCajero = "Apertura Frontal",
                    ModeloCajero = "EZ-PAY 01",
                    NSCajero = "Miditec20150312ger10214",
                    NombreCajero = "Cajero EMMTY",
                    StatusCajero = false,
                    NombreEnsamblador = "Gerardo Sanchez",
                    UbicacionCajero = "Ninguna",
                    ColorCajero = "Naranja",
                    ErrorCajero = "NoError",
                    FechaEnsambladoCajero = new DateTime(2015, 03, 21),
                    FechaEntregaCajero = new DateTime(2015, 03, 24),
                    FechaSalidaCajero = new DateTime(2015, 03, 23),
                    EfectivoActual = 0,
                    EfectivoInicial = 0,
                    EfectivoDispensado = 0,
                    NivelBajoEfectivo = 0,
                    RowUpdate = false
                },
                new Cajero
                {
                    IdCajero = 15,
                    IdAceptador_Billetes = 15,
                    IdAceptador_Monedas = 15,
                    IdDispensador = 15,
                    IdImpresora = 15,
                    IdMonitor = 15,
                    IdPC = 15,
                    IdScanner = 15,
                    IdTarjeta = 15,
                    IdUPS = 15,
                    IdToneleroA = 15,
                    IdToneleroB = 15,
                    IdCliente = 2,
                    IdSucursal = 6,
                    TipoCajero = "Apertura Frontal",
                    ModeloCajero = "EZ-PAY 01",
                    NSCajero = "Miditec20150312ger10215",
                    NombreCajero = "Cajero EMMTY",
                    StatusCajero = false,
                    NombreEnsamblador = "Gerardo Sanchez",
                    UbicacionCajero = "Ninguna",
                    ColorCajero = "Naranja",
                    ErrorCajero = "NoError",
                    FechaEnsambladoCajero = new DateTime(2015, 03, 21),
                    FechaEntregaCajero = new DateTime(2015, 03, 24),
                    FechaSalidaCajero = new DateTime(2015, 03, 23),
                    EfectivoActual = 0,
                    EfectivoInicial = 0,
                    EfectivoDispensado = 0,
                    NivelBajoEfectivo = 0,
                    RowUpdate = false
                });

            context.Roles.AddOrUpdate(r => r.Id,
                new IdentityRole
                {
                    Id = "A",
                    Name = "Admin"
                },
                new IdentityRole
                {
                    Id = "U",
                    Name = "User"
                },
                new IdentityRole
                {
                    Id = "ATM",
                    Name = "Atm"
                },
                new IdentityRole
                {
                    Id = "UA",
                    Name = "UserAdmin"
                });
        }
    }
}
