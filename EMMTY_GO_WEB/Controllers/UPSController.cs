using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using EMMTY_GO_WEB.Models;

namespace EMMTY_GO_WEB.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UPSController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /UPS/
        public async Task<ActionResult> Index()
        {
            return View(await db.UPSes.ToListAsync());
        }

        // GET: /UPS/Details/5
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UPS ups = await db.UPSes.FindAsync(id);
            if (ups == null)
            {
                return HttpNotFound();
            }
            return View(ups);
        }

        // GET: /UPS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /UPS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="IdUPS,MarcaUPS,ModeloUPS,NombreUPS,NSUPS,StatusUPS,ErrorUPS")] UPS ups)
        {
            if (ModelState.IsValid)
            {
                db.UPSes.Add(ups);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ups);
        }

        // GET: /UPS/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UPS ups = await db.UPSes.FindAsync(id);
            if (ups == null)
            {
                return HttpNotFound();
            }
            return View(ups);
        }

        // POST: /UPS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="IdUPS,MarcaUPS,ModeloUPS,NombreUPS,NSUPS,StatusUPS,ErrorUPS")] UPS ups)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ups).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ups);
        }

        // GET: /UPS/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UPS ups = await db.UPSes.FindAsync(id);
            if (ups == null)
            {
                return HttpNotFound();
            }
            return View(ups);
        }

        // POST: /UPS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UPS ups = await db.UPSes.FindAsync(id);
            db.UPSes.Remove(ups);
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
