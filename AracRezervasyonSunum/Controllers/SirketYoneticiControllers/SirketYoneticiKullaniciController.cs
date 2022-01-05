using BusinessLayer.Concrete;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracRezervasyonSunum.Controllers.SirketYoneticiControllers
{
    public class SirketYoneticiKullaniciController : Controller
    {
        // GET: SirketYoneticiKullanici
        KullaniciRepository kullaniciRepository = new KullaniciRepository();
       
        public ActionResult Index()
        {
            
            string Sirketid = Session["Sirketid"].ToString();
            int id = Convert.ToInt32(Sirketid);
            var sorgu = kullaniciRepository.kullaniciListeleSirketeGore(id);
            return View(sorgu);
                       
        }

        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                string Sirketid = Session["Sirketid"].ToString();
                int id = Convert.ToInt32(Sirketid);
                kullanici.SirketID = id;
                kullaniciRepository.Insert(kullanici);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Bir Hata Oluştu");
            return View();
        }
        public ActionResult Delete(int id)
        {
            var delete = kullaniciRepository.GetById(id);
            kullaniciRepository.Delete(delete);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            
            var update = kullaniciRepository.GetById(id);
            return View(update);
           
           
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Update(Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                var update = kullaniciRepository.GetById(kullanici.KullaniciID);
                update.KullaniciAdi = kullanici.KullaniciAdi;
                update.KullaniciAdres = kullanici.KullaniciAdres;
                update.KullaniciIsmi = kullanici.KullaniciIsmi;
                update.KullaniciMail = kullanici.KullaniciMail;
                update.KullaniciSoyismi =kullanici.KullaniciSoyismi;
                update.KullaniciTel = kullanici.KullaniciTel;
                update.Sifre=kullanici.Sifre;
                kullaniciRepository.Update(update);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Bir Hata Oluştu");
            return View();

        }

    }
}