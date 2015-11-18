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
    public class ToneleroBController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ToneleroB
        public async Task<ActionResult> Index()
        {
            return View(await db.TonelerosB.ToListAsync());
        }

        // GET: ToneleroB/Details/5
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var toneleroB = await db.TonelerosB.FindAsync(id);
            if (toneleroB == null)
            {
                return HttpNotFound();
            }
            return View(toneleroB);
        }

        // GET: ToneleroB/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToneleroB/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdToneleroB,NombreTonelero,ModeloTonelero,NSTonelero,StatusTonelero,TipoMoneda,EfectivoActualTonelero,EfectivoDispensadoTonelero,EfectivoInicialTonelero,ErrorTonelero,MarcaTonelero")] ToneleroB toneleroB)
        {
            if (ModelState.IsValid)
            {
                db.TonelerosB.Add(toneleroB);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(toneleroB);
        }

        // GET: ToneleroB/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToneleroB toneleroB = await db.TonelerosB.FindAsync(id);
            if (toneleroB == null)
            {
                return HttpNotFound();
            }
            return View(toneleroB);
        }

        // POST: ToneleroB/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdToneleroB,NombreTonelero,ModeloTonelero,NSTonelero,StatusTonelero,TipoMoneda,EfectivoActualTonelero,EfectivoDispensadoTonelero,EfectivoInicialTonelero,ErrorTonelero,MarcaTonelero")] ToneleroB toneleroB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toneleroB).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(toneleroB);
        }

        // GET: ToneleroB/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToneleroB toneleroB = await db.TonelerosB.FindAsync(id);
            if (toneleroB == null)
            {
                return HttpNotFound();
            }
            return View(toneleroB);
        }

        // POST: ToneleroB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ToneleroB toneleroB = await db.TonelerosB.FindAsync(id);
            db.TonelerosB.Remove(toneleroB);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin,User")]
        public JsonResult GetInfo(int? idTonelero)
        {
            var tonelero = db.TonelerosB.Find(idTonelero).ToSimpleTonelero<ToneleroB>();
            return Json(JsonConvert.SerializeObject(tonelero), JsonRequestBehavior.AllowGet);
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
