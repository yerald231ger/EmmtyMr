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
    public class Aceptador_MonedasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Aceptador_Monedas/
        public async Task<ActionResult> Index()
        {
            return View(await db.Aceptadores_Monedas.ToListAsync());
        }

        // GET: /Aceptador_Monedas/Details/5
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var aceptadorMonedas = await db.Aceptadores_Monedas.FindAsync(id);
            if (aceptadorMonedas == null)
            {
                return HttpNotFound();
            }
            return View(aceptadorMonedas);
        }

        // GET: /Aceptador_Monedas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Aceptador_Monedas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="IdAceptador_Monedas,ModeloAceptador_Monedas,NombreAceptador_Monedas,NSAceptador_Monedas,StatusAceptador_Monedas,ErrorAceptador_Monedas,MarcaAceptador_Monedas")] Aceptador_Monedas aceptador_monedas)
        {
            if (ModelState.IsValid)
            {
                db.Aceptadores_Monedas.Add(aceptador_monedas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(aceptador_monedas);
        }

        // GET: /Aceptador_Monedas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aceptador_Monedas aceptador_monedas = await db.Aceptadores_Monedas.FindAsync(id);
            if (aceptador_monedas == null)
            {
                return HttpNotFound();
            }
            return View(aceptador_monedas);
        }

        // POST: /Aceptador_Monedas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="IdAceptador_Monedas,ModeloAceptador_Monedas,NombreAceptador_Monedas,NSAceptador_Monedas,StatusAceptador_Monedas,ErrorAceptador_Monedas,MarcaAceptador_Monedas")] Aceptador_Monedas aceptador_monedas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aceptador_monedas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(aceptador_monedas);
        }

        // GET: /Aceptador_Monedas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aceptador_Monedas aceptadorMonedas = await db.Aceptadores_Monedas.FindAsync(id);
            if (aceptadorMonedas == null)
            {
                return HttpNotFound();
            }
            return View(aceptadorMonedas);
        }

        // POST: /Aceptador_Monedas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var aceptadorMonedas = await db.Aceptadores_Monedas.FindAsync(id);
            db.Aceptadores_Monedas.Remove(aceptadorMonedas);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        #region JSON_PartialViews_Methods
        //JSON
        [Authorize(Roles = "Admin,User")]
        public JsonResult GetInfo(int? idAceptadorMonedas)
        {
            var aceptadorMonedas = db.Aceptadores_Monedas.Find(idAceptadorMonedas).ToSimpleAceptadorMonedas();
            return Json(JsonConvert.SerializeObject(aceptadorMonedas), JsonRequestBehavior.AllowGet);
        }
        //----------
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
