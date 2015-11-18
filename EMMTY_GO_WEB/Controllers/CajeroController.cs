using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using EMMTY_GO_WEB.Models;
using EMMTY_GO_WEB.Object;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EMMTY_GO_WEB.Controllers
{
    [Authorize]
    public class CajeroController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public CajeroController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        private CajeroController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }

        private UserManager<ApplicationUser> UserManager { get; }

        // GET: /Cajero/
        [Authorize(Roles = "Admin,User")]
        public ActionResult Index()
        {
            return
                View(User.IsInRole("Admin")
                    ? db.Cajeros.ToList()
                    : UserManager.FindById(User.Identity.GetUserId()).Cajeros);
        }

        // GET: /Cajero/Details/5
        [Authorize(Roles = "Admin,User")]
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return
                View(User.IsInRole("Admin")
                    ? db.Cajeros.First(c => c.IdCajero == id)
                    : UserManager.FindById(User.Identity.GetUserId()).Cajeros.First(c => c.IdCajero == id));
        }

        // GET: /Cajero/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            try
            {
                ViewBag.IdAceptador_Billetes = new SelectList(db.Aceptadores_Billetes, "IdAceptador_Billetes",
                    "NSAceptador_Billetes", db.Aceptadores_Billetes.ToList().Last().IdAceptador_Billetes);
                ViewBag.IdAceptador_Monedas = new SelectList(db.Aceptadores_Monedas, "IdAceptador_Monedas",
                    "NSAceptador_Monedas", db.Aceptadores_Billetes.ToList().Last().IdAceptador_Billetes);
                ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "IdCliente",
                    db.Clientes.ToList().Last().IdCliente);
                ViewBag.IdDispensador = new SelectList(db.Dispensadores, "IdDispensador", "NSDispensador",
                    db.Dispensadores.ToList().Last().IdDispensador);
                ViewBag.IdImpresora = new SelectList(db.Impresoras, "IdImpresora", "NSImpresora",
                    db.Impresoras.ToList().Last().IdImpresora);
                ViewBag.IdMonitor = new SelectList(db.Monitores, "IdMonitor", "NSMonitor",
                    db.Monitores.ToList().Last().IdMonitor);
                ViewBag.IdPC = new SelectList(db.PCes, "IdPC", "NSPC", db.PCes.ToList().Last().IdPC);
                ViewBag.IdScanner = new SelectList(db.Scanners, "IdScanner", "NSScanner",
                    db.Scanners.ToList().Last().IdScanner);
                ViewBag.IdSucursal = new SelectList(db.Sucursales, "IdSucursal", "IdSucursal",
                    db.Sucursales.ToList().Last().IdSucursal);
                ViewBag.IdTarjeta = new SelectList(db.Tarjetas, "IdTarjeta", "NSTarjeta",
                    db.Tarjetas.ToList().Last().IdTarjeta);
                ViewBag.IdUPS = new SelectList(db.UPSes, "IdUPS", "NSUPS", db.UPSes.ToList().Last().IdUPS);
                ViewBag.IdToneleroA = new SelectList(db.TonelerosA, "IdToneleroA", "NSTonelero",
                    db.TonelerosA.ToList().Last().IdToneleroA);
                ViewBag.IdToneleroB = new SelectList(db.TonelerosB, "IdToneleroB", "NSTonelero",
                    db.TonelerosB.ToList().Last().IdToneleroB);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View();
        }

        // POST: /Cajero/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create(
            [Bind(
                Include =
                    "ColorCajero,FechaEntregaCajero,FechaSalidaCajero,FechaEnsambladoCajero,NivelBajoEfectivo,IdCajero,NSCajero,NombreCajero,NombreEnsamblador,UbicacionCajero,ErrorCajero,IdAceptador_Billetes,IdDispensador,IdCliente,IdPC,IdImpresora,IdAceptador_Monedas,IdTarjeta,IdUPS,IdScanner,IdMonitor,IdToneleroA,IdToneleroB,IdSucursal,StatusCajero,ModeloCajero,TipoCajero"
                )] Cajero cajero)
        {
            if (ModelState.IsValid)
            {
                cajero = db.Cajeros.Add(cajero);
                cajero.EnabledNotification = true;
                await db.SaveChangesAsync();
                db.Rooms.Add(new ConversationRoom {RoomName = cajero.IdCajero.ToString()});
                DbNotifier.AddDbNotifier(cajero.IdCajero).OnNewChange += AtmsClientBroadcaster.Instance.SendCashLevels;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdAceptador_Billetes = new SelectList(db.Aceptadores_Billetes, "IdAceptador_Billetes",
               "NSAceptador_Billetes", db.Aceptadores_Billetes.ToList().Last().IdAceptador_Billetes);
            ViewBag.IdAceptador_Monedas = new SelectList(db.Aceptadores_Monedas, "IdAceptador_Monedas",
                "NSAceptador_Monedas", db.Aceptadores_Billetes.ToList().Last().IdAceptador_Billetes);
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "IdCliente", db.Clientes.ToList().Last().IdCliente);
            ViewBag.IdDispensador = new SelectList(db.Dispensadores, "IdDispensador", "NSDispensador", db.Dispensadores.ToList().Last().IdDispensador);
            ViewBag.IdImpresora = new SelectList(db.Impresoras, "IdImpresora", "NSImpresora", db.Impresoras.ToList().Last().IdImpresora);
            ViewBag.IdMonitor = new SelectList(db.Monitores, "IdMonitor", "NSMonitor", db.Monitores.ToList().Last().IdMonitor);
            ViewBag.IdPC = new SelectList(db.PCes, "IdPC", "NSPC", db.PCes.ToList().Last().IdPC);
            ViewBag.IdScanner = new SelectList(db.Scanners, "IdScanner", "NSScanner", db.Scanners.ToList().Last().IdScanner);
            ViewBag.IdSucursal = new SelectList(db.Sucursales, "IdSucursal", "IdSucursal", db.Sucursales.ToList().Last().IdSucursal);
            ViewBag.IdTarjeta = new SelectList(db.Tarjetas, "IdTarjeta", "NSTarjeta", db.Tarjetas.ToList().Last().IdTarjeta);
            ViewBag.IdUPS = new SelectList(db.UPSes, "IdUPS", "NSUPS", db.UPSes.ToList().Last().IdUPS);
            ViewBag.IdToneleroA = new SelectList(db.TonelerosA, "IdToneleroA", "NSTonelero", db.TonelerosA.ToList().Last().IdToneleroA);
            ViewBag.IdToneleroB = new SelectList(db.TonelerosB, "IdToneleroB", "NSTonelero", db.TonelerosB.ToList().Last().IdToneleroB);
            return View(cajero);
        }

        // GET: /Cajero/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cajero = await db.Cajeros.FindAsync(id);
            if (cajero == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAceptador_Billetes = new SelectList(db.Aceptadores_Billetes, "IdAceptador_Billetes",
                "NSAceptador_Billetes", cajero.IdAceptador_Billetes);
            ViewBag.IdAceptador_Monedas = new SelectList(db.Aceptadores_Monedas, "IdAceptador_Monedas",
                "NSAceptador_Monedas", cajero.IdAceptador_Monedas);
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "IdCliente", cajero.IdCliente);
            ViewBag.IdDispensador = new SelectList(db.Dispensadores, "IdDispensador", "NSDispensador",
                cajero.IdDispensador);
            ViewBag.IdImpresora = new SelectList(db.Impresoras, "IdImpresora", "NSImpresora", cajero.IdImpresora);
            ViewBag.IdMonitor = new SelectList(db.Monitores, "IdMonitor", "NSMonitor", cajero.IdMonitor);
            ViewBag.IdPC = new SelectList(db.PCes, "IdPC", "NSPC", cajero.IdPC);
            ViewBag.IdScanner = new SelectList(db.Scanners, "IdScanner", "NSScanner", cajero.IdScanner);
            ViewBag.IdSucursal = new SelectList(db.Sucursales, "IdSucursal", "IdSucursal", cajero.IdSucursal);
            ViewBag.IdTarjeta = new SelectList(db.Tarjetas, "IdTarjeta", "NSTarjeta", cajero.IdTarjeta);
            ViewBag.IdUPS = new SelectList(db.UPSes, "IdUPS", "NSUPS", cajero.IdUPS);
            ViewBag.IdToneleroA = new SelectList(db.TonelerosA, "IdToneleroA", "NSTonelero", cajero.IdToneleroA);
            ViewBag.IdToneleroB = new SelectList(db.TonelerosB, "IdToneleroB", "NSTonelero", cajero.IdToneleroB);
            return View(cajero);
        }

        // POST: /Cajero/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(
            [Bind(
                Include =
                    "ColorCajero,FechaEntregaCajero,FechaSalidaCajero,FechaEnsambladoCajero,NivelBajoEfectivo,IdCajero,NSCajero,NombreCajero,NombreEnsamblador,UbicacionCajero,ErrorCajero,IdAceptador_Billetes,IdDispensador,IdToneleroA,IdToneleroB,IdCliente,IdPC,IdImpresora,IdAceptador_Monedas,IdTarjeta,IdUPS,IdScanner,IdMonitor,IdSucursal,StatusCajero,ModeloCajero,AtmUserId,TipoCajero"
                )] Cajero cajero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cajero).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdAceptador_Billetes = new SelectList(db.Aceptadores_Billetes, "IdAceptador_Billetes",
                "NSAceptador_Billetes", cajero.IdAceptador_Billetes);
            ViewBag.IdAceptador_Monedas = new SelectList(db.Aceptadores_Monedas, "IdAceptador_Monedas",
                "NSAceptador_Monedas", cajero.IdAceptador_Monedas);
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "IdCliente", cajero.IdCliente);
            ViewBag.IdDispensador = new SelectList(db.Dispensadores, "IdDispensador", "NSDispensador",
                cajero.IdDispensador);
            ViewBag.IdImpresora = new SelectList(db.Impresoras, "IdImpresora", "NSImpresora", cajero.IdImpresora);
            ViewBag.IdMonitor = new SelectList(db.Monitores, "IdMonitor", "NSMonitor", cajero.IdMonitor);
            ViewBag.IdPC = new SelectList(db.PCes, "IdPC", "NSPC", cajero.IdPC);
            ViewBag.IdScanner = new SelectList(db.Scanners, "IdScanner", "NSScanner", cajero.IdScanner);
            ViewBag.IdSucursal = new SelectList(db.Sucursales, "IdSucursal", "IdSucursal", cajero.IdSucursal);
            ViewBag.IdTarjeta = new SelectList(db.Tarjetas, "IdTarjeta", "NSTarjeta", cajero.IdTarjeta);
            ViewBag.IdUPS = new SelectList(db.UPSes, "IdUPS", "NSUPS", cajero.IdUPS);
            ViewBag.IdToneleroA = new SelectList(db.TonelerosA, "IdToneleroA", "NSTonelero", cajero.IdToneleroA);
            ViewBag.IdToneleroB = new SelectList(db.TonelerosB, "IdToneleroB", "NSTonelero", cajero.IdToneleroB);
            return View(cajero);
        }

        // GET: /Cajero/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var cajero = await db.Cajeros.FindAsync(id);
            if (cajero == null)
                return HttpNotFound();

            return View(cajero);
        }

        // POST: /Cajero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var cajero = await db.Cajeros.FindAsync(id);
            db.Cajeros.Remove(cajero);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        #region JSON_PartialViews

        //JSONs and partial views------------------------

        public JsonResult GetComponentsErrors(int? IdCajero)
        {
            var cajero = db.Cajeros.Find(IdCajero);
            return Json(
                new
                {
                    cajero.Aceptador_Billetes.ErrorAceptador_Billetes,
                    cajero.Aceptador_Monedas.ErrorAceptador_Monedas,
                    cajero.Dispensador.ErrorDispensador,
                    cajero.Impresora.ErrorImpresora,
                    cajero.Scanner.ErrorScanner,
                    cajero.Monitor.ErrorMonitor,
                    cajero.Tarjeta.ErrorTarjeta
                }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCashLevel(int? IdCajero)
        {
            if (User.IsInRole("Admin"))
            {
                var cajero = db.Cajeros.First(c => c.IdCajero == IdCajero);
                return Json(new {CashLevel = cajero.EfectivoActual, MinCashLevel = cajero.NivelBajoEfectivo},
                    JsonRequestBehavior.AllowGet);
            }

            var cajeroCliente =
                UserManager.FindById(User.Identity.GetUserId()).Cajeros.First(c => c.IdCajero == IdCajero);
            return Json(new {CashLevel = cajeroCliente.EfectivoActual, MinCashLevel = cajeroCliente.NivelBajoEfectivo},
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCashLevels(int? IdCajero)
        {
            if (User.IsInRole("Admin"))
            {
                var cajero = db.Cajeros.First(c => c.IdCajero == IdCajero);
                return Json(
                    new
                    {
                        cajero.EfectivoActual,
                        cajero.EfectivoDispensado,
                        cajero.EfectivoInicial,
                        cajero.NivelBajoEfectivo
                    }, JsonRequestBehavior.AllowGet);
            }
            var cajeroCliente =
                UserManager.FindById(User.Identity.GetUserId()).Cajeros.First(c => c.IdCajero == IdCajero);
            return Json(
                new
                {
                    cajeroCliente.EfectivoActual,
                    cajeroCliente.EfectivoDispensado,
                    cajeroCliente.EfectivoInicial,
                    cajeroCliente.NivelBajoEfectivo
                }, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult FindCajero(string NSCajero)
        {
            if (User.IsInRole("Admin"))
            {
                var cajero = db.Cajeros.Where(c => c.NSCajero.Contains(NSCajero));
                return PartialView(cajero.ToList());
            }
            var cajerosCliente =
                UserManager.FindById(User.Identity.GetUserId()).Cajeros.Where(c => c.NSCajero.Contains(NSCajero));
            return PartialView(cajerosCliente.ToList());
        }

        //------------------------------------------------------------------

        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
