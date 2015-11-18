using AtmClient.Model;

namespace AtmClient.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AtmClient.Model.AtmTestDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AtmClient.Model.AtmTestDbContext";
        }

        protected override void Seed(AtmClient.Model.AtmTestDbContext context)
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

            var aceptadorBilletes = new AceptadorBilletes
            {
                Id = 1.ToString(),
                Error = "NoError",
                Status = false
            };

            context.AceptadoresBilletes.AddOrUpdate(c => c.Id, aceptadorBilletes);

            var aceptadorMonedas = new AceptadorMonedas
            {
                Id = 1.ToString(),
                Error = "NoError",
                Status = false
            };

            context.AceptadoresMonedas.AddOrUpdate(c => c.Id, aceptadorMonedas);

            var impresora = new Impresora
            {
                Id = 1.ToString(),
                Error = "NoError",
                Status = false
            };

            context.Impresoras.AddOrUpdate(c => c.Id, impresora);

            var scanner = new Scanner
            {
                Id = 1.ToString(),
                Error = "NoError",
                Status = false
            };

            context.Scanners.AddOrUpdate(c => c.Id, scanner);

            var toneleroA = new ToneleroA
            {
                Id = 1.ToString(),
                EfectivoActual = 5000,
                EfectivoInicial = 5000,
                EfectivoDispensado = 0,
                ValorDispensador = 1,
                Error = "NoError",
                Status = false
            };

            context.TonelerosA.AddOrUpdate(c => c.Id, toneleroA);

            var toneleroB = new ToneleroB
            {
                Id = 1.ToString(),
                EfectivoActual = 5000,
                EfectivoInicial = 5000,
                EfectivoDispensado = 0,
                ValorDispensador = 5,
                Error = "NoError",
                Status = false
            };

            context.TonelerosB.AddOrUpdate(c => c.Id, toneleroB);

            var dispensador = new Dispensador
            {
                Id = 1.ToString(),
                EfectivoActual = 5000,
                EfectivoInicial = 5000,
                EfectivoDispensado = 0,
                ValorDispensador = 50,
                Error = "NoError",
                Status = false
            };

            context.Dispensadores.AddOrUpdate(c => c.Id, dispensador);

            var tarjeta = new Tarjeta
            {
                Id = 1.ToString(),
                Error = "NoError",
                Status = false
            };

            context.Cajeros.AddOrUpdate(c => c.Id, new Cajero
            {
                Id = "Miditec20150312ger1021",
                Dispensador = dispensador,
                ToneleroA = toneleroA,
                ToneleroB = toneleroB,
                Scanner = scanner,
                Impresora = impresora,
                Tarjeta = tarjeta,
                AceptadorBilletes = aceptadorBilletes,
                AceptadorMonedas = aceptadorMonedas
            });
        }
    }
}
