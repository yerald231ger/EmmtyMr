using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using AtmClient.Auth;
using AtmClient.Model;
using AtmClient.Object;
using AtmClient.Proxy;
using Timer = System.Timers.Timer;

namespace AtmClient
{
    internal class AtmClientApp
    {
        public static readonly Dictionary<string, string> AppConfig = new Dictionary<string, string>
        {
            {"/Test", ConfigurationManager.AppSettings["/Test"] ?? "Not Found"},
            {"/Auth", ConfigurationManager.AppSettings["/Auth"] ?? "Not Found"},
            {"/SignalR", ConfigurationManager.AppSettings["/SignalR"] ?? "Not Found"},
            {"AuthCookieName", ConfigurationManager.AppSettings["AuthCookieName"] ?? "Not Found"},
            {"QueryAceptadorBilletes", ConfigurationManager.AppSettings["QueryAceptadorBilletes"] ?? "Not Found"},
            {"QueryAceptadorMonedas", ConfigurationManager.AppSettings["QueryAceptadorMonedas"] ?? "Not Found"},
            {"QueryDispensador", ConfigurationManager.AppSettings["QueryDispensador"] ?? "Not Found"},
            {"QueryScanner", ConfigurationManager.AppSettings["QueryScanner"] ?? "Not Found"},
            {"QueryImpresora", ConfigurationManager.AppSettings["QueryImpresora"] ?? "Not Found"},
            {"QueryToneleroA", ConfigurationManager.AppSettings["QueryToneleroA"] ?? "Not Found"},
            {"QueryToneleroB", ConfigurationManager.AppSettings["QueryToneleroB"] ?? "Not Found"},
            {"QueryCajero", ConfigurationManager.AppSettings["QueryCajero"] ?? "Not Found"},
            {
                "SqlDependency",
                ConfigurationManager.ConnectionStrings["AtmStatusDbConnectionString"].ConnectionString ?? "Not Found"
            },
            {"QueryTarjeta", ConfigurationManager.AppSettings["QueryTarjeta"] ?? "Not Found"},
            {"Username", ConfigurationManager.AppSettings["Username"] ?? "Not Found"},
            {"Password", ConfigurationManager.AppSettings["Password"] ?? "Not Found"},
            {"AutomaticLoggin", ConfigurationManager.AppSettings["AutomaticLoggin"] ?? "Not Found"},
            {"HubName", ConfigurationManager.AppSettings["HubName"] ?? "Not Found"},
            {"NsCajero", ConfigurationManager.AppSettings["NsCajero"] ?? "Not Found"}
        };

        private ClientHub Client { get; set; }

        private static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            using (var db = new AtmTestDbContext())
            {
                try
                {
                    Print.Title("Inicializando");
                    Print.NewLine("Generando/Actualizando Base de datos");
                    db.Cajeros.First();
                }
                catch(Exception)
                {
                }
            }
            var app = new AtmClientApp();
            Print.Title("Runnig AtmClientApp");
          
             while (true)
             {
             }
        }
        
        private AtmClientApp()
        {
            Print.SubTitle("Loading App Configurations");
            var warning = false;
            var error = false;
            var automaticLoggin = bool.Parse(AppConfig.ElementAt(16).Value);
            foreach (var key in AppConfig.Keys)
            {
                if (AppConfig[key] == "Not Found" && ( key == "/Test"))
                {
                    Print.Warning($"{key}: {AppConfig[key]}");
                    warning = true;
                }
                else if (AppConfig[key] == "Not Found" && (key != "/Test"))
                {
                    Print.Error($"{key}: {AppConfig[key]}");
                    error = true;
                }
                else
                    Print.NewLine($"{key}: {AppConfig[key]}");
            }

            
            if(error)
            {
                Scan.ContinueExit("Somethings Keys where not found, Press enter to Exit Application?...");
            }else if (warning)
            {
                Print.Higlight("The '/Test' Key Was Not Found, Press enter to continue?...");
            }

            Print.SubTitle("Starting SqlDependency");
           
            try
            {
                SqlDependency.Start(AppConfig.ElementAt(12).Value);
                Print.NewLine("SqlDependency Started");
            }
            catch (ArgumentException e)
            {
                Print.Error(e.Message);
                Print.Warning("Verify that ConnectionString value isn´t empty");
                Scan.ContinueExit("Press Enter to Close Application");
            }
            catch (Exception e)
            {
                Print.Error(e.Message);
                Print.Warning("Verify that ConnectionString contains corrects; Server, Database, Password, and User id values");
                Scan.ContinueExit("Press Enter to Close Application");
            }

            var notifier = new SqlNotifier(AppConfig.Where(q => q.Key.Contains("Query")).Select(k => k.Value).ToArray());

            if (!automaticLoggin)
            {
                Print.Higlight("Do you want to do the Querie's Test?");
                if (Scan.ReadDecision())
                    notifier.TestQueries();
            }

            var auth = new Authentication();

            if (!automaticLoggin)
            {
                auth.Test();
                var success = auth.LoggIn();
                while (!success)
                {
                    Print.Higlight("Restart Loggin?...");
                    success = Scan.ReadDecision();
                    if (success)
                        success = auth.LoggIn();
                    else
                        Environment.Exit(0);
                }
            }
            else
            {
                var success = auth.LoggIn(AppConfig.ElementAt(14).Value, AppConfig.ElementAt(15).Value);
                if (!success)
                    Scan.ContinueExit();
            }

            Client = new ClientHub(auth);
            notifier.RegisterQueries();

            Print.NewLine("Clear Console Bufer in 5 sec.");
            var timer = ProgresAwaiter.StartCount();
            Thread.Sleep(5000);
            ProgresAwaiter.Stop(timer);
            Console.Clear();
        }
    }

    #region object

    internal static class Print
    {
        public static void Title(string obj)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($">> <{obj.ToUpper()}>");
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }

        public static void SubTitle(string obj)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($">> <{obj}>");
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }

        public static void NewLine<T>(params T[] obj)
        {
            foreach (var s in obj)
                Console.WriteLine($" > {s}");
        }

        public static void Error(WebException e)
        {
            Error(e.Status.ToString(), e.Message, e.InnerException.Message, e.StackTrace);
        }

        public static void Error<T>(params T[] obj)
        {
            foreach (var s in obj)
            {
                Console.Write(" > ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{s}");
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
        }

        public static void Success<T>(params T[] obj)
        {
            foreach (var s in obj)
            {
                Console.Write(" > ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{s}");
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
        }

        public static void Warning<T>(params T[] obj)
        {
            foreach (var s in obj)
            {
                Console.Write(" > ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{s}");
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
        }
        
        public static void Higlight<T>(params T[] obj)
        {
            foreach (var s in obj)
            {
                Console.Write(" > ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"{s}");
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
        }

        public static void Line()
        {
                Console.Write($" > ");
        }
        public static void Line<T>(params T[] obj)
        {
            Console.Write(" > ");
            foreach (var s in obj)
                Console.Write(s);
        }
    }

    internal static class Scan
    {
        public static void Continue()
        {
            Print.Line();
            Console.ReadLine();
        }

        public static void Continue(string msg)
        {
            Print.Higlight(msg);
            Print.Line();
            Console.ReadLine();
        }

        public static void ContinueExit()
        {
            Print.Line();
            Console.ReadLine();
            Environment.Exit(0);
        }

        public static void ContinueExit(string msg)
        {
            Print.Higlight(msg);
            Print.Line();
            Console.ReadLine();
            Environment.Exit(0);
        }

        public static bool ReadDecision()
        {
            bool repeat;
            string line;
            do
            {
                Print.Line();
                line = Console.ReadLine().ToLowerInvariant();

                if ((line != "yes") && (line != "no"))
                {
                    Print.Higlight("Please Write 'yes' or 'no'");
                    repeat = true;
                }
                else
                {
                    repeat = false;
                }
            } while (repeat);
            return line == "yes";
        }
    }

    internal class ProgresAwaiter
    {
        private Timer _timer;

        public static Timer StartDot()
        {
            var pa = new ProgresAwaiter {_timer = new Timer(250)};
            pa._timer.Elapsed += delegate
            {
                Console.Write(".");
            };
            pa._timer.Start();
            return pa._timer;
        }

        public static Timer StartCount()
        {
            var pa = new ProgresAwaiter
            {
                _timer = new Timer(1),
            };

            var _stopwatch = new Stopwatch();
            pa._timer.Elapsed += delegate
            {
                Console.Write($" \r > {_stopwatch.Elapsed.Seconds}:{_stopwatch.Elapsed.Milliseconds}");
            };
            pa._timer.Disposed += delegate {
                _stopwatch.Stop();
            };
            pa._timer.Start();
            _stopwatch.Start();
            return pa._timer;
        }

        public static void Stop(Timer timer)
        {
            timer.Stop();
            timer.Dispose();
        }
        public static void StopL(Timer timer)
        {
            timer.Stop();
            timer.Dispose();
            Console.WriteLine();
            GC.Collect();
        }

    }

    #endregion
}
