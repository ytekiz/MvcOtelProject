using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelMvcProje.Models.Entity;

namespace OtelMvcProje.Controllers
{
    public class İletisimController : Controller
    {
        // GET: İletisim
        MvcOtelProjeEntities3 db = new MvcOtelProjeEntities3();
        public ActionResult Index()
        {
            var bilgiler = db.Tblİletisim.ToList();
            return View(bilgiler);
        }
        [HttpGet]
        public PartialViewResult MesajGonder()
        {
           
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult MesajGonder(TblMesaj p)
        {
            db.TblMesaj.Add(p);
            db.SaveChanges();
            return PartialView();
        }
    }
}