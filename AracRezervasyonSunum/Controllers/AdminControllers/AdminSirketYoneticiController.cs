using BusinessLayer.Concrete;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracRezervasyonSunum.Controllers.AdminControllers
{
    public class AdminSirketYoneticiController : Controller
    {
        SirketYetkiliRepository sirketYetkiliRepository = new SirketYetkiliRepository();
        DataContext db = new DataContext();
        // GET: AdminSirketYonetici
        public ActionResult Index()
        {
            return View(sirketYetkiliRepository.List());
        }

        public ActionResult Create()
        {
            List<SelectListItem> deger1 = (from i in db.Sirkets.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.SirketAdi,
                                               Value = i.SirketID.ToString()
                                           }).ToList();
            ViewBag.sirket = deger1;
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
       public ActionResult Create(SirketYetkili yetkili)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bir Hata Oluştu");
            }
            sirketYetkiliRepository.Insert(yetkili);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var delete = sirketYetkiliRepository.GetById(id);
            sirketYetkiliRepository.Delete(delete);
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            List<SelectListItem> deger1 = (from i in db.Sirkets.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.SirketAdi,
                                               Value = i.SirketID.ToString()
                                           }).ToList();
            ViewBag.sirket = deger1;
            var update= sirketYetkiliRepository.GetById(id);
            return View(update);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Update(SirketYetkili data)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bir Hata Oluştu");
            }
            var update = sirketYetkiliRepository.GetById(data.SirketYoneticiID);
            update.Sirketid = data.Sirketid;
            update.YoneticiAdi = data.YoneticiAdi;
            update.YoneticiSoyadi = data.YoneticiSoyadi;
            update.YoneticiDogumTarihi = data.YoneticiDogumTarihi;
            update.YoneticiTel = data.YoneticiTel;
            update.YoneticiMail = data.YoneticiMail;
            update.YoneticiKullaniciAdi = data.YoneticiKullaniciAdi;
            update.Sifre = data.Sifre;
            sirketYetkiliRepository.Update(update);
            return RedirectToAction("Index");
        }
    }
}