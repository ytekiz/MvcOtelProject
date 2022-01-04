﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OtelMvcProje.Models.Entity;

namespace OtelMvcProje.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        MvcOtelProjeEntities3 db = new MvcOtelProjeEntities3();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblYeniKayit p)
        {
            var bilgiler = db.TblYeniKayit.FirstOrDefault(x => x.Mail == p.Mail && x.Şifre == p.Şifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Mail,false);
                Session["Mail"]=bilgiler.Mail.ToString();
                return RedirectToAction("Index", "Misafir");
            }
            else
            {
                return RedirectToAction("Index");
            }
           
        }
    }
}