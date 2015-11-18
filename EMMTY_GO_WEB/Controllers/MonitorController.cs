using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using EMMTY_GO_WEB.Models;

namespace EMMTY_GO_WEB.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MonitorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Monitor/
        public async Task<ActionResult> Index()
        {
            return View(await db.Monitores.ToListAsync());
        }

        // GET: /Monitor/Details/5
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var monitor = await db.Monitores.FindAsync(id);
            if (monitor == null)
            {
                return HttpNotFound();
            }
            return View(monitor);
        }

        // GET: /Monitor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Monitor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdMonitor,MarcaMonitor,ModeloMonitor,NombreMonitor,NSMonitor,StatusMonitor,ErrorMonitor")] Monitor monitor)
        {
            if (!ModelState.IsValid) return View(monitor);
            db.Monitores.Add(monitor);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: /Monitor/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var monitor = await db.Monitores.FindAsync(id);
            if (monitor == null)
            {
                return HttpNotFound();
            }
            return View(monitor);
        }

        // POST: /Monitor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdMonitor,MarcaMonitor,ModeloMonitor,NombreMonitor,NSMonitor,StatusMonitor,ErrorMonitor")] Monitor monitor)
        {
            if (!ModelState.IsValid) return View(monitor);
            db.Entry(monitor).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: /Monitor/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var monitor = await db.Monitores.FindAsync(id);
            if (monitor == null)
            {
                return HttpNotFound();
            }
            return View(monitor);
        }

        // POST: /Monitor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var monitor = await db.Monitores.FindAsync(id);
            db.Monitores.Remove(monitor);
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
