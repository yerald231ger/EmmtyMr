using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EMMTY_GO_WEB.Models;
using EMMTY_GO_WEB.Object;
using Newtonsoft.Json;

namespace EMMTY_GO_WEB.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ScannerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Scanner/
        public async Task<ActionResult> Index()
        {
            return View(await db.Scanners.ToListAsync());
        }

        // GET: /Scanner/Details/5
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var scanner = await db.Scanners.FindAsync(id);
            if (scanner == null)
            {
                return HttpNotFound();
            }
            return View(scanner);
        }

        // GET: /Scanner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Scanner/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="IdScanner,MarcaScanner,ModeloScanner,NombreScanner,NSScanner,StatusScanner,ErrorScanner")] Scanner scanner)
        {
            if (ModelState.IsValid)
            {
                db.Scanners.Add(scanner);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(scanner);
        }

        // GET: /Scanner/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scanner scanner = await db.Scanners.FindAsync(id);
            if (scanner == null)
            {
                return HttpNotFound();
            }
            return View(scanner);
        }

        // POST: /Scanner/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="IdScanner,MarcaScanner,ModeloScanner,NombreScanner,NSScanner,StatusScanner,ErrorScanner")] Scanner scanner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scanner).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(scanner);
        }

        // GET: /Scanner/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scanner scanner = await db.Scanners.FindAsync(id);
            if (scanner == null)
            {
                return HttpNotFound();
            }
            return View(scanner);
        }

        // POST: /Scanner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Scanner scanner = await db.Scanners.FindAsync(id);
            db.Scanners.Remove(scanner);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #region JSONs_PartialViews_Methods

        //JSON
        [Authorize(Roles = "Admin,User")]
        public JsonResult GetInfo(int? idScanner)
        {
            var scanner = db.Scanners.Find(idScanner).ToSimpleScanner();
            return Json(JsonConvert.SerializeObject(scanner), JsonRequestBehavior.AllowGet);
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
