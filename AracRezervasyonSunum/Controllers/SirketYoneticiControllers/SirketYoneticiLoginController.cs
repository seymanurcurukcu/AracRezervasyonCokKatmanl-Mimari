using BusinessLayer.Concrete;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AracRezervasyonSunum.Controllers.SirketYoneticiControllers
{
    public class SirketYoneticiLoginController : Controller
    {
        // GET: SirketYoneticiLogin
        DataContext db = new DataContext();
        SirketYetkiliRepository yetkiliRepository = new SirketYetkiliRepository();

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
     
        public ActionResult Login(SirketYetkili sirketYetkili)
        {
            var bilgi = db.SirketYetkilis.FirstOrDefault(x => x.YoneticiKullaniciAdi == sirketYetkili.YoneticiKullaniciAdi && x.Sifre == sirketYetkili.Sifre);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.YoneticiKullaniciAdi, false);
                Session["YoneticiKullaniciAdi"] = bilgi.YoneticiKullaniciAdi;
                Session["Sifre"] = bilgi.Sifre;
                Session["YoneticiAdi"] = bilgi.YoneticiAdi;
                Session["YoneticiSoyadi"] = bilgi.YoneticiSoyadi;
                Session["SirketYoneticiID"] = bilgi.SirketYoneticiID;
                Session["Sirketid"] = bilgi.Sirketid;
                return RedirectToAction("Index", "SirketYoneticiKullanici");
            }
            ViewBag.hata = "kullanıcı adınız veya şifreniz hatalı";
            return View(sirketYetkili);
        }

        public ActionResult cikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToActionPermanent("Login", "SirketYoneticiLogin");
        }


       
        public ActionResult SifremiUnuttum()
        {
            return View();
        }
        [HttpPost]
        

        public ActionResult SifremiUnuttum(SirketYetkili sy)
        {
           
            var bilgi = db.SirketYetkilis.FirstOrDefault(x => x.YoneticiKullaniciAdi == sy.YoneticiKullaniciAdi);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.YoneticiKullaniciAdi, false);
                Session["YoneticiKullaniciAdi"] = bilgi.YoneticiKullaniciAdi;
                return RedirectToActionPermanent("Guncelleme", "SirketYoneticiLogin");
               
            }
            ViewBag.hata = "kullanıcı adınız hatalı";
            return RedirectToActionPermanent("SifremiUnuttum", "SirketYoneticiLogin");


        }


        public ActionResult Guncelleme()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Guncelleme(SirketYetkili sy)
        {
            string YoneticiKullaniciAdi = (string)Session["YoneticiKullaniciAdi"];
            var bilgi = db.SirketYetkilis.FirstOrDefault(x => x.YoneticiKullaniciAdi == YoneticiKullaniciAdi);
            if (bilgi != null)
            {

                bilgi.Sifre = sy.Sifre;
                db.SaveChanges();
                return RedirectToActionPermanent("Login", "SirketYoneticiLogin");


            }
            ViewBag.hata = "Hata oldu";
            return RedirectToActionPermanent("SifremiUnuttum", "SirketYoneticiLogin");
        }



    }
}
