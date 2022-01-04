using BusinessLayer.Concrete;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AracRezervasyonSunum.Controllers.MusteriControllers
{
    public class MusteriAracController : Controller
    {
        // GET: MusteriArac

        AracRepository aracRepository = new AracRepository();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AracListesi(string il, string ilce, string mahalle, string vites, string yakit, string koltuk, string Aracadi, string fiyatMin, string fiyatMax, string AzdanCogaSirala, string CoktanAzaSirala)
        {

            var sirala = aracRepository.aracListe();
            if (!string.IsNullOrEmpty(il))
            {
                sirala = aracRepository.AracAdreseGoreListeleme(il, ilce, mahalle);
            }
            if (!(string.IsNullOrEmpty(vites)))
            {
                sirala = aracRepository.AracViteseGoreListeleme(vites);
            }
            if (!(string.IsNullOrEmpty(yakit)))
            {
                sirala = aracRepository.AracYakıtaGoreListeleme(yakit);
            }
            if (!(string.IsNullOrEmpty(koltuk)))
            {
                var Koltuk = Convert.ToInt32(koltuk);
                sirala = aracRepository.KoltukSayisinaGoreListeleme(Koltuk);
            }
            if (!string.IsNullOrEmpty(Aracadi))
            {
                sirala = aracRepository.AracModelineGoreListeleme(Aracadi);
            }
            if (!string.IsNullOrEmpty(fiyatMin))
            {
                var FiyatMin = Convert.ToDecimal(fiyatMin);
                var FiyatMax = Convert.ToDecimal(fiyatMax);
                sirala = aracRepository.AracFiyatinaGoreListeleme(FiyatMin, FiyatMax);
            }
            if (!string.IsNullOrEmpty(AzdanCogaSirala))
            {

                sirala = aracRepository.azdanCogaSiralama();
            }
            if (!string.IsNullOrEmpty(CoktanAzaSirala))
            {

                sirala = aracRepository.CoktanAzaSiralama();
            }

            return View(sirala);
        }



    }
}
