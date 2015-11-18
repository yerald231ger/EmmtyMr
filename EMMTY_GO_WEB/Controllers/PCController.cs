using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using EMMTY_GO_WEB.Models;

namespace EMMTY_GO_WEB.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PCController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /PC/
        public async Task<ActionResult> Index()
        {
            return View(await db.PCes.ToListAsync());
        }

        // GET: /PC/Details/5
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pc = await db.PCes.FindAsync(id);
            if (pc == null)
            {
                return HttpNotFound();
            }
            return View(pc);
        }

        // GET: /PC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdPC,MarcaPC,ModeloPC,NombrePC,NSPC,OSPC,StatusPC,ErrorPC")] PC pc)
        {
            if (ModelState.IsValid)
            {
                db.PCes.Add(pc);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pc);
        }

        // GET: /PC/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PC pc = await db.PCes.FindAsync(id);
            if (pc == null)
            {
                return HttpNotFound();
            }
            return View(pc);
        }

        // POST: /PC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdPC,MarcaPC,ModeloPC,NombrePC,NSPC,OSPC,StatusPC,ErrorPC")] PC pc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pc).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pc);
        }

        // GET: /PC/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PC pc = await db.PCes.FindAsync(id);
            if (pc == null)
            {
                return HttpNotFound();
            }
            return View(pc);
        }

        // POST: /PC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PC pc = await db.PCes.FindAsync(id);
            db.PCes.Remove(pc);
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
