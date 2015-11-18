using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using EMMTY_GO_WEB.Hubs;
using EMMTY_GO_WEB.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;

namespace EMMTY_GO_WEB.Object
{
    public class AtmsClientBroadcaster
    {
        private static readonly Lazy<AtmsClientBroadcaster> instance =
            new Lazy<AtmsClientBroadcaster>(
                () => new AtmsClientBroadcaster(GlobalHost.ConnectionManager.GetHubContext<AtmsMonitorHub>().Clients));

        public List<DbNotifier> ListDbNotifier { get; }

        private AtmsClientBroadcaster(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
            ListDbNotifier = DbNotifier.ListInstances;
            foreach (var dbt in ListDbNotifier)
            {
                dbt.OnNewChange += SendCashLevels;
            }
        }

        public void SendCashLevels(object sender, SqlNotificationEventArgs e)
        {
            var cajero = JsonConvert.DeserializeObject<Cajero>((string)sender);
            var userList = new List<string>();

            using (var db = new ApplicationDbContext())
            {
                    userList = db.Cajeros.Find(cajero.IdCajero).Users.Select(u => u.UserName).ToList();
                    var AdminList =
                        db.Users.Where(u => u.Roles.Select(r => r.RoleId).Contains("A"))
                            .ToList()
                            .Select(uu => uu.UserName);
                userList.AddRange(AdminList);
            }

            var cashLevels = JsonConvert.SerializeObject(new
            {
                cajero.IdCajero,
                cajero.EfectivoActual,
                cajero.NivelBajoEfectivo
            });

            Clients.Users(userList).CashLevels(cashLevels);
        }
        
        private IHubConnectionContext<dynamic> Clients { get; set; }

        public static AtmsClientBroadcaster Instance
        {
            get { return instance.Value; }
        }
    }
}
