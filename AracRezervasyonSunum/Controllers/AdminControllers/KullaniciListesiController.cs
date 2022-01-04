using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracRezervasyonSunum.Controllers.AdminControllers
{
    public class KullaniciListesiController : Controller
    {
        KullaniciRepository kullaniciReposity = new KullaniciRepository();
        // GET: KullaniciListesi
        public ActionResult Index()
        {
            return View(kullaniciReposity.List());
        }
    }
}