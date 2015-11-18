using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using EMMTY_GO_WEB.Models;
using EMMTY_GO_WEB.Object;
using Newtonsoft.Json;

namespace EMMTY_GO_WEB.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Aceptador_BilletesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Aceptador_Billetes/
        public async Task<ActionResult> Index()
        {
            return View(await db.Aceptadores_Billetes.ToListAsync());
        }

        // GET: /Aceptador_Billetes/Details/5
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var aceptadorBilletes = await db.Aceptadores_Billetes.FindAsync(id);
            if (aceptadorBilletes == null)
            {
                return HttpNotFound();
            }
            return View(aceptadorBilletes);
        }

        // GET: /Aceptador_Billetes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Aceptador_Billetes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="IdAceptador_Billetes,ModeloAceptador_Billetes,NombreAceptador_Billetes,NSAceptador_Billetes,StatusAceptador_Billetes,ErrorAceptador_Billetes,MarcaAceptador_Billetes")] Aceptador_Billetes aceptador_billetes)
        {
            if (ModelState.IsValid)
            {
                db.Aceptadores_Billetes.Add(aceptador_billetes);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(aceptador_billetes);
        }

        // GET: /Aceptador_Billetes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var aceptadorBilletes = await db.Aceptadores_Billetes.FindAsync(id);
            if (aceptadorBilletes == null)
            {
                return HttpNotFound();
            }
            return View(aceptadorBilletes);
        }

        // POST: /Aceptador_Billetes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="IdAceptador_Billetes,ModeloAceptador_Billetes,NombreAceptador_Billetes,NSAceptador_Billetes,StatusAceptador_Billetes,ErrorAceptador_Billetes,MarcaAceptador_Billetes")] Aceptador_Billetes aceptador_billetes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aceptador_billetes).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(aceptador_billetes);
        }

        // GET: /Aceptador_Billetes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var aceptadorBilletes = await db.Aceptadores_Billetes.FindAsync(id);
            if (aceptadorBilletes == null)
            {
                return HttpNotFound();
            }
            return View(aceptadorBilletes);
        }

        // POST: /Aceptador_Billetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var aceptadorBilletes = await db.Aceptadores_Billetes.FindAsync(id);
            db.Aceptadores_Billetes.Remove(aceptadorBilletes);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        #region JSON_PartialViews_Methods
        //JSONs
        [Authorize(Roles = "Admin,User")]
        public JsonResult GetInfo(int? idAceptadorBilletes) 
        {
            var aceptadorBilletes = db.Aceptadores_Billetes.Find(idAceptadorBilletes).ToSipleAceptador_Billetes();
            return Json(JsonConvert.SerializeObject(aceptadorBilletes), JsonRequestBehavior.AllowGet);
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
