using BusinessLayer.Concrete;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracRezervasyonSunum.Controllers.KullaniciControllers
{
    public class KullaniciMusteriTakibiController : Controller
    {
        // GET: KullaniciMusteriListesi
        MusteriRepository musteriRepository = new MusteriRepository();
        KiralikRepository kiralikRepository = new KiralikRepository();
        AracRepository aracRepository = new AracRepository();
        public ActionResult Index()
        {
            string Sirketid = Session["Sirketid"].ToString();
            int id = Convert.ToInt32(Sirketid);
            DataContext db = new DataContext();
            var query = from kiralik in db.Kiraliks
                        join arac in db.Aracs
                        on kiralik.AracID equals arac.AracID
                        join musteri in db.Musteris
                        on kiralik.MusteriID equals musteri.MusteriID
                        where arac.durum == 2 && arac.Sirketid == id
                        select new MusteriAracKiralama { AracMak = arac, KiralikMak = kiralik, MusteriMak = musteri };

            return View(query.ToList());


        }
        public ActionResult Sonlandır(int id)
        {
            var son = kiralikRepository.GetById(id);
            return View(son);

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Sonlandır(Kiralik p)
        {
            if (ModelState.IsValid)
            {
                var sonArac = aracRepository.GetById(p.AracID);
                var kiralikSon = kiralikRepository.GetById(p.KiralamaID);
                sonArac.durum = 0;
                sonArac.AracınKendiAnlikKm = p.SonKm;
                kiralikSon.SonKm = p.SonKm;
                aracRepository.Update(sonArac);
                kiralikRepository.Update(kiralikSon);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Bir Hata Oluştu");
            return View();

        }
    }
}