using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracRezervasyonSunum.Controllers.AdminControllers
{
    public class AracListesiController : Controller
    {
        // GET: AracListesi
        AracRepository aracReposity = new AracRepository();
        public ActionResult Index()
        {
            return View(aracReposity.List());
        }
    }
}