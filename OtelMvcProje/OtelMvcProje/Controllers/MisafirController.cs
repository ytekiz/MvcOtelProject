using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OtelMvcProje.Models.Entity;

namespace OtelMvcProje.Controllers
{
    [Authorize]
    public class MisafirController : Controller
    {
        // GET: Misafir
        MvcOtelProjeEntities3 cb = new MvcOtelProjeEntities3();
        public ActionResult Index()
        {
            var misafirmail = (string)Session["Mail"];
            var misafirbilgi = cb.TblYeniKayit.Where(x => x.Mail == misafirmail).FirstOrDefault();
            return View(misafirbilgi);
        }

        public ActionResult Rezervasyonlarim()
        {
            var misafirmail = (string)Session["Mail"];
            //ViewBag.a = misafirmail;
            var misafirid = cb.TblYeniKayit.Where(x => x.Mail == misafirmail).Select(y => y.ID).FirstOrDefault();
            var degerler = cb.TblRezarvasyon.Where(x => x.Misafir == misafirid).ToList();
            return View(degerler);
        }
        public ActionResult MisafirBilgiGüncelle(TblYeniKayit p)
        {
            var misafir = cb.TblYeniKayit.Find(p.ID);
            misafir.AdSoyad = p.AdSoyad;
            misafir.Şifre= p.Şifre;
            misafir.Telefon = p.Telefon;
            misafir.Mail = p.Mail;
            cb.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "AnaSayfa");
        }
        public ActionResult GelenMesajlar()
        {
            var misafirmail = (string)Session["Mail"];
            var mesajlar = cb.TblMesaj2.Where(x => x.Alici==misafirmail).ToList();
            return View(mesajlar);
        }
        public ActionResult GidenMesajlar()
        {
            var misafirmail = (string)Session["Mail"];
            var mesajlar = cb.TblMesaj2.Where(x => x.Gonderen == misafirmail).ToList();
            return View(mesajlar);
        }
        public ActionResult MesajDetay(int id)
        {
            
            var mesaj = cb.TblMesaj2.Where(x => x.MesajID == id).FirstOrDefault();
            return View(mesaj);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(TblMesaj2 p)
        {
            var misafirmail = (string)Session["Mail"];
            p.Gonderen = misafirmail;
            p.Alici = "Admin";
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            cb.TblMesaj2.Add(p);
            cb.SaveChanges();
            return RedirectToAction("GidenMesajlar");
        }
    }
}