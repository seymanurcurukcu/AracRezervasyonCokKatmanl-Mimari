using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracRezervasyonSunum.Controllers.SirketYoneticiControllers
{
    public class SirketYoneticiAracListesiController : Controller
    {
        // GET: SirketYoneticiAracListesi
        AracRepository aracRepository = new AracRepository();
        public ActionResult Index()
        {
            string Sirketid = Session["Sirketid"].ToString();
            int id = Convert.ToInt32(Sirketid);
            var sorgu = aracRepository.aracListeleSirketeGore(id);
            return View(sorgu);
        }
    }
}