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
    public class DispensadorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Dispensador/
        public async Task<ActionResult> Index()
        {
            return View(await db.Dispensadores.ToListAsync());
        }

        // GET: /Dispensador/Details/5
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var dispensador = await db.Dispensadores.FindAsync(id);
            if (dispensador == null)
            {
                return HttpNotFound();
            }
            return View(dispensador);
        }

        // GET: /Dispensador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Dispensador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="IdDispensador,EfectivoActualDispensador,EfectivoDispensadoDispensador,EfectivoInicialDispensador,ModeloDispensador,NSDispensador,StatusDispensador,TipoBillete,ErrorDispensador,MarcaDispensador,NombreDispensador")] Dispensador dispensador)
        {
            if (ModelState.IsValid)
            {
                db.Dispensadores.Add(dispensador);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(dispensador);
        }

        // GET: /Dispensador/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispensador dispensador = await db.Dispensadores.FindAsync(id);
            if (dispensador == null)
            {
                return HttpNotFound();
            }
            return View(dispensador);
        }

        // POST: /Dispensador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="IdDispensador,EfectivoActualDispensador,EfectivoDispensadoDispensador,EfectivoInicialDispensador,ModeloDispensador,NSDispensador,StatusDispensador,TipoBillete,ErrorDispensador,MarcaDispensador,NombreDispensador")] Dispensador dispensador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dispensador).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dispensador);
        }

        // GET: /Dispensador/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispensador dispensador = await db.Dispensadores.FindAsync(id);
            if (dispensador == null)
            {
                return HttpNotFound();
            }
            return View(dispensador);
        }

        // POST: /Dispensador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Dispensador dispensador = await db.Dispensadores.FindAsync(id);
            db.Dispensadores.Remove(dispensador);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        #region JSONs_PartialViews_Methods

        //JSON
        [Authorize(Roles = "Admin,User")]
        public JsonResult GetInfo(int? idDispensador)
        {
            var dispensador = db.Dispensadores.Find(idDispensador).ToSimpleDispensador();
            return Json(JsonConvert.SerializeObject(dispensador), JsonRequestBehavior.AllowGet);
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
