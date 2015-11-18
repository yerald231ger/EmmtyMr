using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EMMTY_GO_WEB.Hubs;
using EMMTY_GO_WEB.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;

namespace EMMTY_GO_WEB.Object
{
    public class AtmClientsBroadcaster
    {
        [SuppressMessage("ReSharper", "InconsistentNaming")] private static readonly Lazy<AtmClientsBroadcaster>
            _instance =
                new Lazy<AtmClientsBroadcaster>(
                    () => new AtmClientsBroadcaster(GlobalHost.ConnectionManager.GetHubContext<AtmMonitorHub>().Clients));

        private AtmClientsBroadcaster(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
            var listDbNotifier = DbNotifier.ListInstances;

            using (var db = new ApplicationDbContext())
            {
                var rooms = new List<ConversationRoom>();
                foreach (var c in listDbNotifier)
                {
                    var room = new ConversationRoom {RoomName = c.IdCondicional.ToString()};
                    db.Cajeros.Find(c.IdCondicional).EnabledNotification = true;
                    rooms.Add(room);
                }

                db.Rooms.AddOrUpdate(rooms.ToArray());
                db.SaveChanges();
            }

            foreach (var dbt in listDbNotifier)
            {
                dbt.OnNewChange += SendClientData;
            }
        }

        public void AddEventNotification(int id)
        {
            var dbt = DbNotifier.ListInstances.First(_dbt => _dbt.IdCondicional == id);
            dbt.OnNewChange -= SendClientData;
            dbt.OnNewChange += SendClientData;
            using (var db = new ApplicationDbContext())
            {
                db.Cajeros.Find(id).EnabledNotification = true;
                db.SaveChanges();
            }
        }

        public void DeleteEventNotification(int id)
        {
            var dbt = DbNotifier.ListInstances.First(_dbt => _dbt.IdCondicional == id);
            dbt.OnNewChange -= SendClientData;
            using (var db = new ApplicationDbContext())
            {
                db.Cajeros.Find(id).EnabledNotification = false;
                db.SaveChanges();
            }
        }

        private void SendClientData(object sender, SqlNotificationEventArgs arg)
        {
            var jsonCajero = (string) sender;
            var cajero = JsonConvert.DeserializeObject<Cajero>(jsonCajero);
            Clients.Group(cajero.IdCajero.ToString()).AtmData(jsonCajero);
        }
        
        public static AtmClientsBroadcaster Instance
        {
            get { return _instance.Value; }
        }

        private IHubConnectionContext<dynamic> Clients { get; }
    }

}