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
    public class ToneleroController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Tonelero/
        public async Task<ActionResult> Index()
        {
            return View(await db.TonelerosA.ToListAsync());
        }

        // GET: /Tonelero/Details/5
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToneleroA tonelero = await db.TonelerosA.FindAsync(id);
            if (tonelero == null)
            {
                return HttpNotFound();
            }
            return View(tonelero);
        }

        // GET: /Tonelero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Tonelero/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdToneleroA,NombreTonelero,ModeloTonelero,NSTonelero,StatusTonelero,TipoMoneda,EfectivoActualTonelero,EfectivoDispensadoTonelero,EfectivoInicialTonelero,ErrorTonelero,MarcaTonelero")] ToneleroA tonelero)
        {
            if (ModelState.IsValid)
            {
                db.TonelerosA.Add(tonelero);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tonelero);
        }

        // GET: /Tonelero/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToneleroA tonelero = await db.TonelerosA.FindAsync(id);
            if (tonelero == null)
            {
                return HttpNotFound();
            }
            return View(tonelero);
        }

        // POST: /Tonelero/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdToneleroA,NombreTonelero,ModeloTonelero,NSTonelero,StatusTonelero,TipoMoneda,EfectivoActualTonelero,EfectivoDispensadoTonelero,EfectivoInicialTonelero,ErrorTonelero,MarcaTonelero")] ToneleroA tonelero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tonelero).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tonelero);
        }

        // GET: /Tonelero/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToneleroA tonelero = await db.TonelerosA.FindAsync(id);
            if (tonelero == null)
            {
                return HttpNotFound();
            }
            return View(tonelero);
        }

        // POST: /Tonelero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ToneleroA tonelero = await db.TonelerosA.FindAsync(id);
            db.TonelerosA.Remove(tonelero);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #region JSONs_PartialViews_Methods

        //JSON
        [Authorize(Roles = "Admin,User")]
        public JsonResult GetInfo(int? idTonelero)
        {
            var tonelero = db.TonelerosA.Find(idTonelero).ToSimpleTonelero<ToneleroA>();
            return Json(JsonConvert.SerializeObject(tonelero), JsonRequestBehavior.AllowGet);
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
