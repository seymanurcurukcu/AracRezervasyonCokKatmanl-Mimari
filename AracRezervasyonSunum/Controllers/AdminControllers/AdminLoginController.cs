

using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AracRezervasyonSunum.Controllers.AdminControllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        DataContext db = new DataContext();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var bilgiler = db.Admins.FirstOrDefault(x => x.AdminKullaniciAdi == admin.AdminKullaniciAdi && x.Sifre == admin.Sifre);
            if (bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.AdminKullaniciAdi, false);
                Session["AdminKullaniciAdi"] = bilgiler.AdminKullaniciAdi;
                Session["Sifre"] = bilgiler.Sifre;
                return RedirectToActionPermanent("Index", "AdminIsyeri");
            }
            ViewBag.hata = "kullanıcı adınız veya şifreniz hatalı";
            return View(admin);
        }
        public ActionResult cikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToActionPermanent("Index", "AdminIsyeri");
        }
    }
}