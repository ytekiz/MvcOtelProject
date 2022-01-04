using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelMvcProje.Models.Entity;

namespace OtelMvcProje.Controllers
{
    public class KayitController : Controller
    {
        MvcOtelProjeEntities3 db = new MvcOtelProjeEntities3();
        // GET: Kayit
        [HttpGet]
        public ActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(TblYeniKayit p)
        {
            db.TblYeniKayit.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}