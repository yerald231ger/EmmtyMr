using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EMMTY_GO_WEB.Models;
using Microsoft.AspNet.Identity;

namespace EMMTY_GO_WEB.Controllers
{
    [Authorize]
    public class ReportesXCajeroController : Controller
    {
        //----------------------------------------------------------------------

        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: /ReportesXCajero/
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Index()
        {
            var reportesxcajero = db.ReportesCajeros.Include(r => r.Cajeros).Include(r => r.Reportes);
            return View(await reportesxcajero.ToListAsync());
        }

        // GET: /ReportesXCajero/IndexRxC
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult> IndexRxC(int? id)
        {
            var reportesxcajero = db.ReportesCajeros.Where(c => c.IdCajero == id);
            return View(await reportesxcajero.ToListAsync());
        }

        //----------------------------------------------------------------------

        // GET: /ReportesXCajero/Details/5
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportesCajero reportesxcajero = await db.ReportesCajeros.FindAsync(id);
            if (reportesxcajero == null)
            {
                return HttpNotFound();
            }
            return View(reportesxcajero);
        }

        // GET: /ReportesXCajero/Details/5
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> DetailsRxC(int? id, int? IdCajero)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reporte reporte = await db.Reportes.FindAsync(id);
            if (reporte == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCajero = IdCajero;
            return View(reporte);
        }

        //----------------------------------------------------------------------

        // GET: /ReportesXCajero/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create(int? Id, string ns)
        {
            ViewBag.IdReporte = new SelectList(db.Reportes, "IdReporte", "NSReporte");

            if (Id == null)
            {
                ViewBag.IdCajero = new SelectList(db.Cajeros, "IdCajero", "NSCajero");
                return View("Create");
            }
            else
            {
                ViewBag.NSCajero = ns;
                ViewBag.IdCajero = Id;
                return View("CreateRelationRxC");
            }
        }

        // POST: /ReportesXCajero/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create([Bind(Include = "IdReporte,IdCajero,IdReporteXCajero")] ReportesCajero reportesxcajero, string FromCreateRelationRxC)
        {
            if (ModelState.IsValid)
            {
                db.ReportesCajeros.Add(reportesxcajero);
                await db.SaveChangesAsync();

                if (FromCreateRelationRxC.Equals("true"))
                    return RedirectToAction("IndexRxC", new { Id = reportesxcajero.IdCajero });
                else
                    return RedirectToAction("Index");
            }

            ViewBag.IdCajero = new SelectList(db.Cajeros, "IdCajero", "ColorCajero", reportesxcajero.IdCajero);
            ViewBag.IdReporte = new SelectList(db.Reportes, "IdReporte", "CorrectivoReporte", reportesxcajero.IdReporte);
            return View(reportesxcajero);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateRxC(int? id, string ns)
        {
            ViewBag.IdCajero = id;
            ViewBag.NSCajero = ns;
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRxC([Bind(Include = "FechaReporte,CorrectivoReporte,PreventivoReporte,TecnicoReporte,NombreReporte,NSReporte")] Reporte reporte, int IdCajero)
        {

            if (ModelState.IsValid)
            {
                db.Reportes.Add(reporte);
                db.SaveChanges();

                db.ReportesCajeros.Add(new ReportesCajero { IdReporte = reporte.IdReporte, IdCajero = IdCajero });
                db.SaveChanges();
                return RedirectToAction("IndexRxC", new { id = IdCajero });
            }

            return View(reporte);
        }

        //----------------------------------------------------------------------

        // GET: /ReportesXCajero/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportesCajero reportesxcajero = await db.ReportesCajeros.FindAsync(id);
            if (reportesxcajero == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCajero = new SelectList(db.Cajeros, "IdCajero", "ColorCajero", reportesxcajero.IdCajero);
            ViewBag.IdReporte = new SelectList(db.Reportes, "IdReporte", "CorrectivoReporte", reportesxcajero.IdReporte);
            return View(reportesxcajero);
        }

        // POST: /ReportesXCajero/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit([Bind(Include="IdReporte,IdCajero,IdReporteXCajero")] ReportesCajero reportesxcajero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportesxcajero).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdCajero = new SelectList(db.Cajeros, "IdCajero", "ColorCajero", reportesxcajero.IdCajero);
            ViewBag.IdReporte = new SelectList(db.Reportes, "IdReporte", "CorrectivoReporte", reportesxcajero.IdReporte);
            return View(reportesxcajero);
        }


        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> EditRxC(int? id, int? IdCajero)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reporte reporte = await db.Reportes.FindAsync(id);
            if (reporte == null)
            {
                return HttpNotFound();
            }

            ViewBag.IdCajero = IdCajero;
            return View(reporte);
        }

        // POST: /Reporte/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> EditRxC([Bind(Include = "IdReporte,FechaReporte,CorrectivoReporte,PreventivoReporte,TecnicoReporte,NombreReporte,NSReporte")] Reporte reporte,int? IdCajero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reporte).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("IndexRxC", new { id = IdCajero });
            }
            return View(reporte);
        }

        //----------------------------------------------------------------------

        // GET: /ReportesXCajero/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportesCajero reportesxcajero = await db.ReportesCajeros.FindAsync(id);
            if (reportesxcajero == null)
            {
                return HttpNotFound();
            }
            return View(reportesxcajero);
        }

        // POST: /ReportesXCajero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ReportesCajero reportesxcajero = await db.ReportesCajeros.FindAsync(id);
            db.ReportesCajeros.Remove(reportesxcajero);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: /ReportesXCajero/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteRxC(int? id, int? IdCajero)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reporte reporte = await db.Reportes.FindAsync(id);
            if (reporte == null)
            {
                return HttpNotFound();
            }
            return View(reporte);
        }

        // POST: /ReportesXCajero/Delete/5
        [HttpPost, ActionName("DeleteRxC")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteConfirmedRxC(int id, int idReporteXCajero, int IdCajero)
        {
            ReportesCajero reportesxcajero = await db.ReportesCajeros.FindAsync(idReporteXCajero);
            db.ReportesCajeros.Remove(reportesxcajero);
            await db.SaveChangesAsync();
            return RedirectToAction("IndexRxC", new { id = IdCajero });
        }
        
       

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
