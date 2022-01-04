using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelMvcProje.Models.Entity;


namespace OtelMvcProje.Controllers
{
    public class DefaultController : Controller
    {
        MvcOtelProjeEntities3 db = new MvcOtelProjeEntities3();
        // GET: Default
        public ActionResult Index()
        {
           
            return View();
        }
       
        public ActionResult Hakkimda()
        {
            var veriler = db.TblHakkimda.ToList();
            return View(veriler);
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialSosyalMedya()
        {
            return PartialView();
        }
        public PartialViewResult Ekibimiz()
        {
            var ekiplistesi = db.TblEkibimiz.ToList();
            return PartialView(ekiplistesi);
        }
        public PartialViewResult İstatistik()
        {
            return PartialView();
        }
        public PartialViewResult Referansalarım()
        {
            return PartialView();
        }
    }
}