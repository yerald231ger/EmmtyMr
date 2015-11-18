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
    public class ImpresoraController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Impresora/
        public async Task<ActionResult> Index()
        {
            return View(await db.Impresoras.ToListAsync());
        }

        // GET: /Impresora/Details/5
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var impresora = await db.Impresoras.FindAsync(id);
            if (impresora == null)
            {
                return HttpNotFound();
            }
            return View(impresora);
        }

        // GET: /Impresora/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Impresora/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="IdImpresora,NSImpresora,NombreImpresora,ModeloImpresora,StatusImpresora,PapelImpresora,ErrorImpresora,MarcaImpresora")] Impresora impresora)
        {
            if (ModelState.IsValid)
            {
                db.Impresoras.Add(impresora);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(impresora);
        }

        // GET: /Impresora/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Impresora impresora = await db.Impresoras.FindAsync(id);
            if (impresora == null)
            {
                return HttpNotFound();
            }
            return View(impresora);
        }

        // POST: /Impresora/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="IdImpresora,NSImpresora,NombreImpresora,ModeloImpresora,StatusImpresora,PapelImpresora,ErrorImpresora,MarcaImpresora")] Impresora impresora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(impresora).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(impresora);
        }

        // GET: /Impresora/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Impresora impresora = await db.Impresoras.FindAsync(id);
            if (impresora == null)
            {
                return HttpNotFound();
            }
            return View(impresora);
        }

        // POST: /Impresora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Impresora impresora = await db.Impresoras.FindAsync(id);
            db.Impresoras.Remove(impresora);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        #region JSONs_PartialViews_Methods

        //JSON
        [Authorize(Roles = "Admin,User")]
        public JsonResult GetInfo(int? idImpresora)
        {
            var impresora = db.Impresoras.Find(idImpresora).ToSimpleImpresora();
            return Json(JsonConvert.SerializeObject(impresora), JsonRequestBehavior.AllowGet);
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
