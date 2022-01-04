using OtelMvcProje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtelMvcProje.Controllers
{
    public class RezarvasyonController : Controller
    {
        MvcOtelProjeEntities3 db = new MvcOtelProjeEntities3();

        [Authorize]
        // GET: Rezarvasyon
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblRezarvasyon p)
        {
            var misafirmail = (string)Session["Mail"];
            var misafirid = db.TblYeniKayit.Where(x => x.Mail == misafirmail).Select(x=>x.ID).FirstOrDefault();
            p.Durum = 1;
            p.Misafir = misafirid;
            db.TblRezarvasyon.Add(p);
            db.SaveChanges();
            return RedirectToAction("Rezervasyonlarim", "Misafir");
        }
    }
}