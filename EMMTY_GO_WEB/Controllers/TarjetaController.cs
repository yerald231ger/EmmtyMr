using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using EMMTY_GO_WEB.Models;
using EMMTY_GO_WEB.Object;
using Newtonsoft.Json;

namespace EMMTY_GO_WEB.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TarjetaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /tarjeta/
        public async Task<ActionResult> Index()
        {
            return View(await db.Tarjetas.ToListAsync());
        }

        // GET: /tarjeta/Details/5
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tarjeta = await db.Tarjetas.FindAsync(id);
            if (tarjeta == null)
            {
                return HttpNotFound();
            }
            return View(tarjeta);
        }

        // GET: /tarjeta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /tarjeta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdTarjeta,ModeloTarjeta,NSTarjeta,StatusTarjeta,ErrorTarjeta,MarcaTarjeta,NombreTarjeta")] Tarjeta tarjeta)
        {
            if (ModelState.IsValid)
            {
                db.Tarjetas.Add(tarjeta);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tarjeta);
        }

        // GET: /tarjeta/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarjeta tarjeta = await db.Tarjetas.FindAsync(id);
            if (tarjeta == null)
            {
                return HttpNotFound();
            }
            return View(tarjeta);
        }

        // POST: /tarjeta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdTarjeta,ModeloTarjeta,NSTarjeta,StatusTarjeta,ErrorTarjeta,MarcaTarjeta,NombreTarjeta")] Tarjeta tarjeta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarjeta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tarjeta);
        }

        // GET: /tarjeta/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarjeta tarjeta = await db.Tarjetas.FindAsync(id);
            if (tarjeta == null)
            {
                return HttpNotFound();
            }
            return View(tarjeta);
        }

        // POST: /tarjeta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tarjeta tarjeta = await db.Tarjetas.FindAsync(id);
            db.Tarjetas.Remove(tarjeta);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        #region JSONs_PartialViews_Methods

        //JSON
        [Authorize(Roles = "Admin,User")]
        public JsonResult GetInfo(int? idTarjeta)
        {
            var tarjeta = db.Tarjetas.Find(idTarjeta).ToSimpleTarjeta();
            return Json(JsonConvert.SerializeObject(tarjeta), JsonRequestBehavior.AllowGet);
        }

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
