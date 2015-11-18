using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using EMMTY_GO_WEB.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;

namespace EMMTY_GO_WEB.Hubs
{
    [Authorize(Roles = "Atm")]
    public class AtmDataHub : Hub
    {
        public override Task OnConnected()
        {
            Clients.Caller.AtmConnected("Hello from the Server, Atm: " + Context.User.Identity.Name);
            using (var db = new ApplicationDbContext())
            {
                var userId = Context.User.Identity.GetUserId();
                var cajero = db.Cajeros.First(c => c.AtmUserId == userId);
                var user = db.Users.First(u => u.Id == userId);

                user.IsConnected = true;
                cajero.Online = true;
                cajero.RowUpdate = true;
                db.SaveChanges();
            }
            return base.OnConnected();
        }

        public override Task OnReconnected()
        {
            Clients.Caller.AtmReconnected("Reconnected to Server, Atm: " + Context.User.Identity.Name);
            return base.OnReconnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            using (var db = new ApplicationDbContext())
            {
                var userId = Context.User.Identity.GetUserId();
                var cajero = db.Cajeros.First(c => c.AtmUserId == userId);
                var user = db.Users.First(u => u.Id == userId);

                user.IsConnected = false;
                cajero.Online = false;
                cajero.RowUpdate = true;
                db.SaveChanges();
            }
            Clients.Caller.AtmDesconnected("GoodBye From the Server, Atm: " + Context.User.Identity.Name);
            return base.OnDisconnected(stopCalled);
        }

        #region ATM Remote Methods
        
        public void AceptadorMonedasData(bool status, string error, string nsCajero)
        {
            using (var db = new ApplicationDbContext())
            {
                var com = db.Aceptadores_Monedas.FirstOrDefault(a => a.Cajeros.FirstOrDefault().NSCajero == nsCajero);
                if (com == null) return;

                com.ErrorAceptador_Monedas = error;
                com.StatusAceptador_Monedas = status;
                db.Aceptadores_Monedas.AddOrUpdate(com);

                db.SaveChanges();

                Clients.Caller.AceptadorMonedasCallback("Monedero-> " + com.StatusAceptador_Monedas + "," +
                                                        com.ErrorAceptador_Monedas);
            }
        }
        
        public void AceptadorBilletesData(bool status, string error, string nsCajero)
        {
            using (var db = new ApplicationDbContext())
            {
                var com = db.Aceptadores_Billetes.FirstOrDefault(a => a.Cajeros.FirstOrDefault().NSCajero == nsCajero);
                if (com == null) return;

                com.ErrorAceptador_Billetes = error;
                com.StatusAceptador_Billetes = status;
                db.Aceptadores_Billetes.AddOrUpdate(com);

                db.SaveChanges();
                Clients.Caller.AceptadorBilletesCallback("Billetero-> " + com.StatusAceptador_Billetes + "," +
                                                        com.ErrorAceptador_Billetes);
            }
        }
        
        public void ToneleroAData(int efectivoActual, int efectivoDispensado, int efectivoInicial, bool status,
            string error, string nsCajero)
        {
            using (var db = new ApplicationDbContext())
            {
                var cajero = db.Cajeros.First(c => c.NSCajero == nsCajero);
                if (cajero == null) return;
                var ta = cajero.ToneleroA;
                var tb = cajero.ToneleroB;
                var d = cajero.Dispensador;

                cajero.EfectivoActual = efectivoActual + tb.EfectivoActualTonelero + d.EfectivoActualDispensador;
                cajero.EfectivoDispensado = efectivoDispensado + tb.EfectivoDispensadoTonelero + d.EfectivoDispensadoDispensador;
                cajero.EfectivoInicial = efectivoInicial + tb.EfectivoInicialTonelero + d.EfectivoInicialDispensador;

                ta.ErrorTonelero = error;
                ta.StatusTonelero = status; 
                ta.EfectivoInicialTonelero = efectivoInicial;
                ta.EfectivoActualTonelero = efectivoActual;
                ta.EfectivoDispensadoTonelero = efectivoDispensado;

                db.Cajeros.AddOrUpdate(cajero);
                db.TonelerosA.AddOrUpdate(ta);
                db.SaveChanges();
                Clients.Caller.ToneleroACallback("ToneleroA-> " + ta.EfectivoActualTonelero + "," +
                                                 ta.EfectivoDispensadoTonelero + "," + 
                                                 ta.EfectivoInicialTonelero + "," +
                                                 ta.StatusTonelero + "," +
                                                 ta.ErrorTonelero);
            }
        }
        
        public void ToneleroBData(int efectivoActual, int efectivoDispensado, int efectivoInicial, bool status,
            string error, string nsCajero)
        {
            using (var db = new ApplicationDbContext())
            {
                var cajero = db.Cajeros.First(c => c.NSCajero == nsCajero);
                if(cajero ==  null)return;

                var ta = cajero.ToneleroA;
                var tb = cajero.ToneleroB;
                var d = cajero.Dispensador;
                
                cajero.EfectivoActual = ta.EfectivoActualTonelero + efectivoActual + d.EfectivoActualDispensador;
                cajero.EfectivoDispensado = ta.EfectivoDispensadoTonelero + efectivoDispensado + d.EfectivoDispensadoDispensador;
                cajero.EfectivoInicial = ta.EfectivoInicialTonelero + efectivoInicial + d.EfectivoInicialDispensador;

                tb.ErrorTonelero = error;
                tb.StatusTonelero = status;
                tb.EfectivoInicialTonelero = efectivoInicial;
                tb.EfectivoActualTonelero = efectivoActual;
                tb.EfectivoDispensadoTonelero = efectivoDispensado;

                db.Cajeros.AddOrUpdate(cajero);
                db.TonelerosB.AddOrUpdate(tb);
                db.SaveChanges();
                Clients.Caller.ToneleroBCallback("ToneleroB-> " + tb.EfectivoActualTonelero + "," +
                                                 tb.EfectivoDispensadoTonelero + "," +
                                                 tb.EfectivoInicialTonelero + "," +
                                                 tb.StatusTonelero + "," +
                                                 tb.ErrorTonelero);
            }
        }
        
        public void DispensadorData(int efectivoActual, int efectivoDispensado, int efectivoInicial, bool status,
            string error, string nsCajero)
        {
            using (var db = new ApplicationDbContext())
            {
                var cajero = db.Cajeros.First(c => c.NSCajero == nsCajero);
                var ta = cajero.ToneleroA;
                var tb = cajero.ToneleroB;
                var d = cajero.Dispensador;

                cajero.EfectivoActual = ta.EfectivoActualTonelero + tb.EfectivoActualTonelero + efectivoActual;
                cajero.EfectivoDispensado = ta.EfectivoDispensadoTonelero + tb.EfectivoDispensadoTonelero + efectivoDispensado;
                cajero.EfectivoInicial = ta.EfectivoInicialTonelero + tb.EfectivoInicialTonelero + efectivoInicial;

                d.ErrorDispensador = error;
                d.StatusDispensador = status;
                d.EfectivoInicialDispensador = efectivoInicial;
                d.EfectivoActualDispensador = efectivoActual;
                d.EfectivoDispensadoDispensador = efectivoDispensado;

                db.Cajeros.AddOrUpdate(cajero);
                db.TonelerosA.AddOrUpdate(ta);
                db.SaveChanges();
                Clients.Caller.DispensadorCallback("Dispensador-> : " + d.EfectivoActualDispensador + "," +
                                                 d.EfectivoDispensadoDispensador + "," +
                                                 d.EfectivoInicialDispensador + "," +
                                                 d.StatusDispensador + "," +
                                                 d.ErrorDispensador);
            }
        }
        
        public void ImpresoraData(bool papel, bool status, string error, string nsCajero)
        {
            using (var db = new ApplicationDbContext())
            {
                var com = db.Impresoras.FirstOrDefault(a => a.Cajeros.FirstOrDefault().NSCajero == nsCajero);
                if (com == null) return;
                com.ErrorImpresora = error;
                com.StatusImpresora = status;
                com.PapelImpresora = papel;
                db.Impresoras.AddOrUpdate(com);

                db.SaveChanges();
                Clients.Caller.ImpresoraCallback("Billetero-> "+ com.PapelImpresora + "," + com.StatusImpresora + "," +
                                                 com.ErrorImpresora);
            }
        }
        
        public void ScannerData(bool status, string error, string nsCajero)
        {
            using (var db = new ApplicationDbContext())
            {
                var com = db.Scanners.FirstOrDefault(a => a.Cajeros.FirstOrDefault().NSCajero == nsCajero);
                if (com == null) return;
                com.ErrorScanner = error;
                com.StatusScanner = status;
                db.Scanners.AddOrUpdate(com);

                db.SaveChanges();
                Clients.Caller.ScannerCallback("Scanner-> " + com.StatusScanner + "," +
                                               com.ErrorScanner);
            }
        }
        
        public void TarjetaData(bool status, string error, string nsCajero)
        {
            using (var db = new ApplicationDbContext())
            {
                var com = db.Tarjetas.FirstOrDefault(a => a.Cajeros.FirstOrDefault().NSCajero == nsCajero);
                if (com == null) return;
                com.ErrorTarjeta = error;
                com.StatusTarjeta = status;
                db.Tarjetas.AddOrUpdate(com);

                db.SaveChanges();
                Clients.Caller.TarjetaCallback("Tarjeta-> " + com.StatusTarjeta + "," +
                                               com.ErrorTarjeta);
            }
        }

        #endregion
    }
}
