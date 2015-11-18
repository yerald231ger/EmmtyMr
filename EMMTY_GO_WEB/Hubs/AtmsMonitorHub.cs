using System.Collections.Generic;
using System.Linq;
using EMMTY_GO_WEB.Models;
using EMMTY_GO_WEB.Object;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;

namespace EMMTY_GO_WEB.Hubs
{
    [Authorize]
    public class AtmsMonitorHub : Hub
    {
        // ReSharper disable once NotAccessedField.Local
        private readonly AtmsClientBroadcaster _atmClientsBroadcaster;

        // ReSharper disable once UnusedMember.Global
        public AtmsMonitorHub() : this(AtmsClientBroadcaster.Instance)
        {
        }

        private AtmsMonitorHub(AtmsClientBroadcaster atmClientsBroadcaster)
        {
            _atmClientsBroadcaster = atmClientsBroadcaster;
        }

        public void GetCashLevels(int[] idsCajeros, string userId)
        {
            var atmsCashLevels = new List<object>();
            using (var db = new ApplicationDbContext())
            {
                if (Context.User.IsInRole("Admin"))
                {
                    foreach (var idCajero in idsCajeros)
                    {
                        var cajero = db.Cajeros.Find(idCajero);
                        atmsCashLevels.Add(new
                        {
                            cajero.IdCajero,
                            cajero.EfectivoActual,
                            cajero.NivelBajoEfectivo
                        });
                    }
                }
                else
                {
                    foreach (var idCajero in idsCajeros)
                    {
                        var cajero = db.Users.Find(userId).Cajeros.First(cc => cc.IdCajero == idCajero);
                        atmsCashLevels.Add(new
                        {
                            cajero.IdCajero,
                            cajero.EfectivoActual,
                            cajero.NivelBajoEfectivo
                        });
                    }
                }
            }
            Clients.Caller.PopulateCashLevels(JsonConvert.SerializeObject(atmsCashLevels));
        }

    }
}
