using BusinessLayer.Concrete;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracRezervasyonSunum.Controllers.AdminControllers
{
    public class AdminIsyeriController : Controller
    {
        // GET: AdminIsyeri
        SirketRepository sirketRepository = new SirketRepository();
        public ActionResult Index()
        {
            return View(sirketRepository.List());
        }

        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Sirket p)
        {
            if (ModelState.IsValid)
            {
                sirketRepository.Insert(p);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Bir Hata Oluştu");
            return View();
        }
        public ActionResult Delete(int id)
        {
            var delete = sirketRepository.GetById(id);
            sirketRepository.Delete(delete);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            var update = sirketRepository.GetById(id);
            return View(update);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Update(Sirket p)
        {
            if (ModelState.IsValid)
            {
                var update = sirketRepository.GetById(p.SirketID);
                update.SirketAdi = p.SirketAdi;
                update.SirketIl = p.SirketIl;
                update.SirketIlce = p.SirketIlce;
                update.SirketMahalle = p.SirketMahalle;
                update.AracSayisi = p.AracSayisi;
                update.SirketPuani = p.SirketPuani;
                sirketRepository.Update(update);
                return RedirectToAction("Index");   
            }
            ModelState.AddModelError("", "Bir Hata Oluştu");
            return View();

        }

    }
}