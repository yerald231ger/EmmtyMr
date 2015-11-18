using System;
using AtmClient.Auth;
using AtmClient.Proxy;
using Microsoft.AspNet.SignalR.Client;

namespace AtmClient
{
    class Program
    {
        private static IHubProxy Proxy;

        static void Main(string[] args)
        {

            var authentication = new Authentication();
            do
            {
                Console.WriteLine("Loggin Process Started...");
            } while (!authentication.LoggIn());
            Console.WriteLine("Loggin Process Finalized...");
            
            var Client = new ClientHub(authentication);
            Proxy = Client.Proxy;
            Console.ReadLine();
        }
    }
    
}
