using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using EMMTY_GO_WEB.Models;

namespace EMMTY_GO_WEB.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReporteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Reporte/
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Index()
        {
            return View(await db.Reportes.ToListAsync());
        }

        // GET: /Reporte/Details/5
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> Details(int? id)
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

        // GET: /Reporte/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Reporte/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdReporte,FechaReporte,CorrectivoReporte,PreventivoReporte,TecnicoReporte,NombreReporte,NSReporte")] Reporte reporte)
        {
            if (ModelState.IsValid)
            {
                db.Reportes.Add(reporte);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(reporte);
        }

        // GET: /Reporte/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(int? id)
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

        // POST: /Reporte/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdReporte,FechaReporte,CorrectivoReporte,PreventivoReporte,TecnicoReporte,NombreReporte,NSReporte")] Reporte reporte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reporte).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(reporte);
        }

        // GET: /Reporte/Delete/5
        public async Task<ActionResult> Delete(int? id)
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

        // POST: /Reporte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Reporte reporte = await db.Reportes.FindAsync(id);
            db.Reportes.Remove(reporte);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
