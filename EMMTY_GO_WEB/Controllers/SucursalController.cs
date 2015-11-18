using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using EMMTY_GO_WEB.Models;

namespace EMMTY_GO_WEB.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SucursalController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Sucursal/
        public async Task<ActionResult> Index()
        {
            return View(await db.Sucursales.ToListAsync());
        }

        // GET: /Sucursal/Details/5
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursal sucursal = await db.Sucursales.FindAsync(id);
            if (sucursal == null)
            {
                return HttpNotFound();
            }
            return View(sucursal);
        }

        // GET: /Sucursal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Sucursal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="IdSucursal,SupervisorCajero,EmpresaSucursal,TelefonoSucursal,GerenteSucursal,DireccionSucursal,NombreSucursal")] Sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                db.Sucursales.Add(sucursal);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sucursal);
        }

        // GET: /Sucursal/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursal sucursal = await db.Sucursales.FindAsync(id);
            if (sucursal == null)
            {
                return HttpNotFound();
            }
            return View(sucursal);
        }

        // POST: /Sucursal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="IdSucursal,SupervisorCajero,EmpresaSucursal,TelefonoSucursal,GerenteSucursal,DireccionSucursal,NombreSucursal")] Sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sucursal).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sucursal);
        }

        // GET: /Sucursal/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursal sucursal = await db.Sucursales.FindAsync(id);
            if (sucursal == null)
            {
                return HttpNotFound();
            }
            return View(sucursal);
        }

        // POST: /Sucursal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Sucursal sucursal = await db.Sucursales.FindAsync(id);
            db.Sucursales.Remove(sucursal);
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
