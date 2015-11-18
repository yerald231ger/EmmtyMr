using System;
using System.Linq;
using System.Net;
using AtmClient.Auth;
using Microsoft.AspNet.SignalR.Client;
using Timer = System.Timers.Timer;

namespace AtmClient.Proxy
{
    internal class ClientHub
    {
        public HubConnection HubConnection { get; set; }
        public static IHubProxy HubProxy { private set; get; }
        private static Timer _timer;

        public ClientHub(Authentication auth)
        {
            Print.SubTitle("Client Connection Proccess");
            Print.NewLine("Setting-Up Credentials and Cookies");
            var connection = new HubConnection(AtmClientApp.AppConfig.ElementAt(2).Value)
            {
                CookieContainer = new CookieContainer(),
                Credentials = new NetworkCredential(auth.UserName, auth.Password)
            };
            connection.CookieContainer.Add(auth.AuthCookie);

            Print.NewLine("Creating the Hub");
            HubProxy = connection.CreateHubProxy(AtmClientApp.AppConfig.ElementAt(17).Value);
            Print.NewLine("Registering Methods");
            HubProxy.On<string>("AtmConnected", (AtmConnected));
            HubProxy.On<string>("AtmDesconnected", (AtmDesconnected));
            HubProxy.On<string>("AtmReconnected", (AtmReconnected));
            HubProxy.On<string>("AceptadorMonedasCallback", (AceptadorMonedasCallback));
            HubProxy.On<string>("AceptadorBilletesCallback", (AceptadorBilletesCallback));
            HubProxy.On<string>("ToneleroACallback", (ToneleroACallback));
            HubProxy.On<string>("ToneleroBCallback", (ToneleroBCallback));
            HubProxy.On<string>("DispensadorCallback", (DispensadorCallback));
            HubProxy.On<string>("TarjetaCallback", (TarjetaCallback));
            HubProxy.On<string>("ScannerCallback", (ScannerCallback));
            HubProxy.On<string>("ImpresoraCallback", (ImpresoraCallback));

            Print.Line("Connecting");
            _timer = ProgresAwaiter.StartDot();
            try
            {
                connection.Start().Wait();
            }
            catch (Exception)
            {
                ProgresAwaiter.Stop(_timer);
                Console.WriteLine();
                Print.Error("Verifica que el nombre del Hub sea Correcto o el servidor este en linea");
                Scan.ContinueExit("Enter to exit");
            }
            Print.Success("ATM Online");

        }

        private static void AtmConnected(string data)
        {
            ProgresAwaiter.StopL(_timer);
            Print.Higlight($"Connected: {data}");
        }

        private static void AtmDesconnected(string data)
        {
            Print.Higlight($"Desconnected: {data}");
        }

        private static void AtmReconnected(string data)
        {
            Print.Higlight($"Reconnected: {data}");
        }

        private static void AceptadorMonedasCallback(string data)
        {
            Print.Higlight($"DataReceived: {data}");
        }

        private static void AceptadorBilletesCallback(string data)
        {
            Print.Higlight($"DataReceived: {data}");
        }

        private static void ToneleroACallback(string data)
        {
            Print.Higlight($"DataReceived: {data}");
        }

        private static void ToneleroBCallback(string data)
        {
            Print.Higlight($"DataReceived: {data}");
        }

        private static void DispensadorCallback(string data)
        {
            Print.Higlight($"DataReceived: {data}");
        }

        private static void TarjetaCallback(string data)
        {
            Print.Higlight($"DataReceived: {data}");
        }

        private static void ScannerCallback(string data)
        {
            Print.Higlight($"DataReceived: {data}");
        }

        private static void ImpresoraCallback(string data)
        {
            Print.Higlight($"DataReceived: {data}");
        }
    }
}
