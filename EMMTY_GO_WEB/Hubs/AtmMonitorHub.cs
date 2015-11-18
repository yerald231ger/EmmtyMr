using System;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using EMMTY_GO_WEB.Models;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EMMTY_GO_WEB.Object;
using Microsoft.AspNet.Identity;

namespace EMMTY_GO_WEB.Hubs
{
    [Authorize]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public class AtmMonitorHub : Hub
    {
        private ApplicationDbContext _db;

        // ReSharper disable once NotAccessedField.Local
        private readonly AtmClientsBroadcaster _atmClientsBroadcaster;

        // ReSharper disable once UnusedMember.Global
        public AtmMonitorHub() : this(AtmClientsBroadcaster.Instance)
        {
        }

        public AtmMonitorHub(AtmClientsBroadcaster atmClientsBroadcaster)
        {
            _atmClientsBroadcaster = atmClientsBroadcaster;
        }

        [Authorize(Roles = "User,Admin")]
        // ReSharper disable once UnusedMember.Global
        public void RegisterNotification(string idCajero)
        {
            AddToRoom(idCajero);
        }

        [Authorize(Roles = "User,Admin")]
        // ReSharper disable once UnusedMember.Global
        public void UnRegisterNotification(string idCajero)
        {
            RemoveFromRoom(idCajero);
        }

        public void EnabledNotifications(int id, bool enable)
        {
            var status = "";
            if (enable)
            {
                _atmClientsBroadcaster.AddEventNotification(id);
                status = "Enabled";
            }
            else
            {
                _atmClientsBroadcaster.DeleteEventNotification(id);
                status = "Disabled";
            }

            Clients.Caller.NotificationStatus(status);
        }

        private void AddToRoom(string roomName)
        {
            using (var db = new ApplicationDbContext())
            {
                // Retrieve room.
                var room = db.Rooms.Find(roomName);

                if (room == null) return;

                var userId = Context.User.Identity.GetUserId();
                var user = db.Users.First(u => u.Id == userId);

                room.Users.Add(user);
                db.SaveChanges();
                Groups.Add(Context.ConnectionId, roomName);
            }
        }

        private void RemoveFromRoom(string roomName)
        {
            using (var db = new ApplicationDbContext())
            {
                // Retrieve room.
                var room = db.Rooms.Find(roomName);

                if (room == null) return;

                var userId = Context.User.Identity.GetUserId();
                var user = db.Users.First(u => u.Id == userId);

                room.Users.Remove(user);
                db.SaveChanges();

                Groups.Remove(Context.ConnectionId, roomName);
            }
        }

        public override async Task OnConnected()
        {
            var id = Context.User.Identity.GetUserId();
            using (_db = new ApplicationDbContext())
            {
                var user = await _db.Users
                    .Include(u => u.Connections)
                    .SingleOrDefaultAsync(u => u.Id == id);

                user.Connections.Add(new Connection
                {
                    ConnectionID = Context.ConnectionId,
                    UserAgent = Context.Request.Headers["User-Agent"],
                    Connected = true,
                    ConnectionDate = DateTime.Now
                });
                user.IsConnected = true;

                await _db.SaveChangesAsync();
            }
        }

        public override async Task OnDisconnected(bool stopCalled)
        {
            using (_db = new ApplicationDbContext())
            {
                var connection = await _db.Connections.FindAsync(Context.ConnectionId);
                connection.Connected = false;

                await _db.SaveChangesAsync();
            }
        }

        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }
    }
}