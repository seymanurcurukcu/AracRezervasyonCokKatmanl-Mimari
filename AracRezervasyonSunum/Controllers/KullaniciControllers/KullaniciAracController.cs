using BusinessLayer.Concrete;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracRezervasyonSunum.Controllers.KullaniciControllers
{
    public class KullaniciAracController : Controller
    {
        // GET: KullaniciArac
        AracRepository aracReposity = new AracRepository();
        KullaniciRepository kullaniciReposity = new KullaniciRepository();
        public ActionResult Index()
        {
            string Sirketid = Session["SirketID"].ToString();
            int id = Convert.ToInt32(Sirketid);
            var sorgu = aracReposity.aracListeSirketeGore(id);
            return View(sorgu);
        }

        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Arac p, HttpPostedFileBase File)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bir Hata Oluştu");
            }

            string path = Path.Combine("~/Content/Image/" + File.FileName);
            File.SaveAs(Server.MapPath(path));
            p.resim = File.FileName.ToString();
            aracReposity.Insert(p);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var delete = aracReposity.GetById(id);
            aracReposity.Delete(delete);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            var update = aracReposity.GetById(id);
            return View(update);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Update(Arac p, HttpPostedFileBase File)
        {
            var update = aracReposity.GetById(p.AracID);
            if (ModelState.IsValid)
            {
                if (File == null)
                {
                    update.AracAdi = p.AracAdi;
                    update.Modeli = p.Modeli;
                    update.EhliyetYasi = p.EhliyetYasi;
                    update.MinimumYasSiniri = p.MinimumYasSiniri;
                    update.GunlukSinirKm = p.GunlukSinirKm;
                    update.AracınKendiAnlikKm = p.AracınKendiAnlikKm;
                    update.Airbag = p.Airbag;
                    update.BagajHacmi = p.BagajHacmi;
                    update.KoltukSayisi = p.KoltukSayisi;
                    update.GunlukKiralikFiyati = p.GunlukKiralikFiyati;
                    update.Yakiti = p.Yakiti;
                    update.vitesTuru = p.vitesTuru;
                    update.durum = p.durum;
                    aracReposity.Update(update);
                    return RedirectToAction("Index");
                }
                else
                {
                    update.AracAdi = p.AracAdi;
                    update.Modeli = p.Modeli;
                    update.EhliyetYasi = p.EhliyetYasi;
                    update.MinimumYasSiniri = p.MinimumYasSiniri;
                    update.GunlukSinirKm = p.GunlukSinirKm;
                    update.AracınKendiAnlikKm = p.AracınKendiAnlikKm;
                    update.Airbag = p.Airbag;
                    update.BagajHacmi = p.BagajHacmi;
                    update.KoltukSayisi = p.KoltukSayisi;
                    update.GunlukKiralikFiyati = p.GunlukKiralikFiyati;
                    update.Yakiti = p.Yakiti;
                    update.vitesTuru = p.vitesTuru;
                    update.durum = p.durum;
                    update.resim = File.FileName.ToString();
                    aracReposity.Update(update);
                    return RedirectToAction("Index");
                }
            }

            return View(update);
        }
    }
}