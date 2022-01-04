using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracRezervasyonSunum.Controllers.AdminControllers
{
    public class MusteriListesiController : Controller
    {
        // GET: MusteriListesi
        MusteriRepository musteriReposity = new MusteriRepository();
        public ActionResult Index()
        {
            return View(musteriReposity.List());
        }
    }
}