using BusinessLayer.Concrete;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AracRezervasyonSunum.Controllers.MusteriControllers
{
    public class MusteriLoginController : Controller
    {
        // GET: MusteriLogin

        DataContext db = new DataContext();
        MusteriRepository musteriReposity = new MusteriRepository();
       
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(Musteri musteri)
        {
            var bilgiler = db.Musteris.FirstOrDefault(x => x.MusteriKullaniciAdi == musteri.MusteriKullaniciAdi && x.Sifre == musteri.Sifre);


            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MusteriKullaniciAdi, false);
                Session["MusteriKullaniciAdi"] = bilgiler.MusteriKullaniciAdi.ToString();
                Session["MusteriID"] = bilgiler.MusteriID.ToString();
                Session["Sifre"] = bilgiler.Sifre.ToString();
                return RedirectToActionPermanent("AracListesi", "MusteriArac");
            }
            ViewBag.hata = "kullanıcı adınız veya şifreniz hatalı";

            return View();
        }
        public ActionResult KayitOl()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult KayitOl(Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                musteriReposity.Insert(musteri);
                return RedirectToAction("Login");
            }
            ModelState.AddModelError("", "Bir Hata Oluştu");
            return View();
        }


    }
}

