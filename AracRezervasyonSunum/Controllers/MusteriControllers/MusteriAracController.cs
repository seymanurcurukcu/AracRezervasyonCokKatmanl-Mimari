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
        KiralikRepository kiralikRepository = new KiralikRepository();
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

        public ActionResult Kirala(int id)
        {
            var Arac = aracRepository.GetById(id);
            ViewBag.AracFiyati = Arac.GunlukKiralikFiyati;
            ViewBag.AracID = id;
            return View();
        }

        [HttpPost]
        public ActionResult Kirala(Kiralik k)
        {

            if (ModelState.IsValid)
            {
                var Arac = aracRepository.GetById(k.AracID);
                Arac.durum = 1;
                aracRepository.Update(Arac);
                decimal kiralamaFiyati = Arac.GunlukKiralikFiyati;
                string musteriID = Session["MusteriID"].ToString();
                int id = Convert.ToInt32(musteriID);
                k.MusteriID = id;
                k.ilkKm = Arac.AracınKendiAnlikKm;
                kiralikRepository.Insert(k);
                var tarih1 = k.VerilisTarihi;
                var tarih2 = k.BitisTarihi;
                TimeSpan kalan_sure = (tarih2 - tarih1);
                double days = kalan_sure.TotalDays;
                k.AlınanÜcret = (int)(days * (double)(kiralamaFiyati));
                kiralikRepository.Update(k);

                return RedirectToAction("Rezervasyon");
            }
            ModelState.AddModelError("", "Bir Hata Oluştu");
            return View();

        }

        public ActionResult Rezervasyon()
        {
            string musteriID = Session["MusteriID"].ToString();
            int id = Convert.ToInt32(musteriID);
            var sirala = aracRepository.MusteriyeGoreListeleme(id);
            return View(sirala);
        }



    }
}
