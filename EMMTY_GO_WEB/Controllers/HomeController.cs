using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web.Mvc;
using EMMTY_GO_WEB.Models;
using Microsoft.AspNet.Identity;

namespace EMMTY_GO_WEB.Controllers
{

    public class HomeController : Controller
    {
        [SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Local")] 
        private ApplicationDbContext _db = new ApplicationDbContext();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [Authorize]
        public JsonResult CashLevelsLow() 
        {
            var listCajeros = new List<object>();

            if (User.IsInRole("Admin"))
            {
                var cajeros = _db.Cajeros.Where(c => c.EfectivoActual <= c.NivelBajoEfectivo).ToList();
                var ncajeros = cajeros.Count();

                foreach (var c in cajeros) 
                {
                    listCajeros.Add(new {c.NSCajero, c.EfectivoActual, c.IdCajero});
                }

                return Json(new { NCajeros = ncajeros, Cajeros = listCajeros }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var cajeros = _db.Users.Find(User.Identity.GetUserId()).Cajeros.Where(c => c.EfectivoActual <= c.NivelBajoEfectivo).ToList();
                var ncajeros = cajeros.Count();

                foreach (var c in cajeros)
                {
                    listCajeros.Add(new { c.NSCajero, c.EfectivoActual, c.IdCajero });
                }

                return Json(new { NCajeros = ncajeros, Cajeros = listCajeros }, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize]
        public JsonResult ComponenetsError()
        {
            var listCajeros = new List<object>();

            if (User.IsInRole("Admin"))
            {
                var cajeros = _db.Cajeros.Where(c => c.StatusCajero);
                var ncajeros = cajeros.Count();

                foreach (var c in cajeros)
                {
                    listCajeros.Add(new {c.NSCajero, c.StatusCajero, c.IdCajero });
                }

                return Json(new { NCajeros = ncajeros, Cajeros = listCajeros }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var cajeros = _db.Users.Find(User.Identity.GetUserId()).Cajeros.Where(c => c.StatusCajero).ToList();
                var ncajeros = cajeros.Count();

                foreach (var c in cajeros)
                {
                    listCajeros.Add(new { c.NSCajero, c.StatusCajero, c.IdCajero });
                }

                return Json(new { NCajeros = ncajeros, Cajeros = listCajeros }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}