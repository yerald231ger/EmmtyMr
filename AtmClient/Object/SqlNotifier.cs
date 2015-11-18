using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using AtmClient.Model;
using AtmClient.Proxy;

namespace AtmClient.Object
{
    class SqlNotifier
    {
        private readonly List<string> _queries;
        private string _query;
        
        private SqlNotifier() { }

        public SqlNotifier(params string[] queries)
        {
            _queries = queries.ToList();
        }

        public void RegisterQueries()
        {
            Print.SubTitle("Registering Querties...");
            foreach (var sqlNotifier in _queries.Select(query => new SqlNotifier {_query = query}))
            {
                sqlNotifier.RegisterQuery();
            }
            Print.NewLine("Ok");
        }

        private void RegisterQuery()
        {
            using (var connection = new SqlConnection(AtmClientApp.AppConfig.ElementAt(12).Value))
            {
                using (var command = new SqlCommand(_query, connection))
                {
                    command.Notification = null;
                    var dependencyObj = new SqlDependency(command);
                    dependencyObj.OnChange += DependencyObj_OnChange;
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    using (command.ExecuteReader())
                    {
                    }
                }
            }
        }

        private void DependencyObj_OnChange(object sender, SqlNotificationEventArgs e)
        {

            if (e.Info == SqlNotificationInfo.Invalid || e.Info == SqlNotificationInfo.Error ||
                e.Type == SqlNotificationType.Subscribe)
            {
                Print.Error(e.Info.ToString(), e.Source.ToString(), e.Type.ToString());
                Scan.ContinueExit("Press enter to Exit to the Application");
            }
            using (var db = new AtmTestDbContext())
            {
                var id = _query.Substring(_query.LastIndexOf('=') + 1).Trim();
                if (_query.Contains("Dispensadores"))
                {
                    var com = db.Dispensadores.Find(id);

                    ClientHub.HubProxy.Invoke("DispensadorData", com.EfectivoActual, com.EfectivoDispensado, com.EfectivoInicial, com.Status, com.Error, com.Cajero.First().NsCajero);
                    Print.NewLine($"DataSent: Dispensador-> {com.EfectivoActual},{com.EfectivoDispensado},{com.EfectivoInicial},{com.Status},{com.Error},{com.Cajero.First().NsCajero}");
                }
                else if (_query.Contains("TonelerosA"))
                {
                    var com = db.TonelerosA.Find(id);

                    ClientHub.HubProxy.Invoke("ToneleroAData", com.EfectivoActual, com.EfectivoDispensado, com.EfectivoInicial, com.Status, com.Error, com.Cajero.First().NsCajero);
                    Print.NewLine($"DataSent: ToneleroA-> {com.EfectivoActual},{com.EfectivoDispensado},{com.EfectivoInicial},{com.Status},{com.Error},{com.Cajero.First().NsCajero}");
                }
                else if (_query.Contains("TonelerosB"))
                {
                    var com = db.TonelerosB.Find(id);

                    ClientHub.HubProxy.Invoke("ToneleroBData", com.EfectivoActual, com.EfectivoDispensado, com.EfectivoInicial, com.Status, com.Error, com.Cajero.First().NsCajero);
                    Print.NewLine($"DataSent: ToneleroB-> {com.EfectivoActual},{com.EfectivoDispensado},{com.EfectivoInicial},{com.Status},{com.Error},{com.Cajero.First().NsCajero}");
                }
                else if (_query.Contains("Impresoras"))
                {
                    var com = db.Impresoras.Find(id);

                    ClientHub.HubProxy.Invoke("ImpresoraData", com.Papel, com.Status, com.Error, com.Cajero.First().NsCajero);
                    Print.NewLine($"DataSent: Impresora-> {com.Papel},{com.Status},{com.Error},{com.Cajero.First().NsCajero}");
                }
                else if (_query.Contains("Scanners"))
                {
                    var com = db.Scanners.Find(id);

                    ClientHub.HubProxy.Invoke("ScannerData", com.Status, com.Error, com.Cajero.First().NsCajero);
                    Print.NewLine($"DataSent: Scanner-> {com.Status},{com.Error},{com.Cajero.First().NsCajero}");
                }
                else if (_query.Contains("Tarjetas"))
                {
                    var com = db.Tarjetas.Find(id);

                    ClientHub.HubProxy.Invoke("TarjetaData", com.Status, com.Error, com.Cajero.First().NsCajero);
                    Print.NewLine($"DataSent: Tarjeta-> {com.Status},{com.Error},{com.Cajero.First().NsCajero}");
                }
                else if (_query.Contains("AceptadoresBilletes"))
                {
                    var com = db.AceptadoresBilletes.Find(id);

                    ClientHub.HubProxy.Invoke("AceptadorBilletesData", com.Status, com.Error, com.Cajero.First().NsCajero);
                    Print.NewLine($"DataSent: Billetero-> {com.Status},{com.Error},{com.Cajero.First().NsCajero}");
                }
                else if (_query.Contains("AceptadoresMonedas"))
                {
                    var com = db.AceptadoresMonedas.Find(id);

                    ClientHub.HubProxy.Invoke("AceptadorMonedasData", com.Status, com.Error, com.Cajero.First().NsCajero);
                    Print.NewLine($"DataSent: Moneder-> {com.Status},{com.Error},{com.Cajero.First().NsCajero}");
                }
            }

            RegisterQuery();
        }

        public void TestQueries()
        {
            Print.SubTitle("The Queries test has started");
            foreach (var query in _queries)
            {
                var next = false;
                Console.Write("\r");
                Print.Higlight($"Query: {query}");
                using (var connection = new SqlConnection(AtmClientApp.AppConfig.ElementAt(12).Value))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Notification = null;
                        var dependencyObj = new SqlDependency(command);
                        dependencyObj.OnChange += ((sender, args) =>
                        {
                            if (args.Info == SqlNotificationInfo.Invalid || args.Info == SqlNotificationInfo.Error ||
                                args.Type == SqlNotificationType.Subscribe)
                            {
                                Console.Write("\r");
                                Print.Error($"The query has or is: {args.Info} {args.Type}");
                                Scan.ContinueExit("Press enter to Exit to the Application");
                            }
                            Console.Write("\r");
                            Print.NewLine(
                                $"{nameof(args.Type)}: {args.Type}; {nameof(args.Info)}: {args.Info}; {nameof(args.Source)}: {args.Source}");
                            next = true;
                        });
                        if (connection.State == ConnectionState.Closed)
                            connection.Open();
                        using (command.ExecuteReader())
                        {
                        }
                    }
                }
                Print.Line("You can test the query now... ");
                while (!next)
                {
                }
            }
            Print.Higlight("Queries test... OK");
        }


    }
}
