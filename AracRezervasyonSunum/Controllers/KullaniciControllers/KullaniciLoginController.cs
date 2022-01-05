using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AracRezervasyonSunum.Controllers.KullaniciControllers
{
    public class KullaniciLoginController : Controller
    {
        // GET: KullaniciLogin
        DataContext db = new DataContext();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Kullanici kullanici)
        {
            var bilgiler = db.Kullanicis.FirstOrDefault(x => x.KullaniciAdi == kullanici.KullaniciAdi && x.Sifre == kullanici.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAdi, false);
                Session["KullaniciAdi"] = bilgiler.KullaniciAdi;
                Session["Kullaniciisim"] = bilgiler.KullaniciIsmi;
                Session["KullaniciSoyisim"] = bilgiler.KullaniciSoyismi;
                Session["Sifre"] = bilgiler.Sifre;
                Session["KullaniciID"] = bilgiler.KullaniciID;
                Session["SirketID"] = bilgiler.SirketID;
                return RedirectToActionPermanent("Index", "KullaniciArac", kullanici);
            }
            ViewBag.hata = "kullanıcı adınız veya şifreniz hatalı";
            return View(kullanici);
        }
        public ActionResult cikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToActionPermanent("Index", "KullaniciArac");
        }
    }
}