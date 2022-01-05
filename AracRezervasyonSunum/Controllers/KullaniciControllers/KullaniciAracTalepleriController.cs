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
    public class KullaniciAracTalepleriController : Controller
    {
        // GET: KullaniciAracTalepleri
        AracRepository aracReposity = new AracRepository();
        KiralikRepository kiralikRepository = new KiralikRepository();
        //List<Arac> aracs = new List<Arac>();
        //List<Musteri> musteris = new List<Musteri>();
        //List<Kiralik> kiraliks = new List<Kiralik>();
        public ActionResult Index()
        {
            //string Sirketid = Session["Sirketid"].ToString();
            //int id = Convert.ToInt32(Sirketid);
            //var sorgu = musteriRepository.musteriListeleSirketeGore(id);
            //return View(sorgu);
            string Sirketid = Session["Sirketid"].ToString();
            int id = Convert.ToInt32(Sirketid);
            DataContext db = new DataContext();
            var query = from kiralik in db.Kiraliks
                        join arac in db.Aracs
                        on kiralik.AracID equals arac.AracID
                        join musteri in db.Musteris
                        on kiralik.MusteriID equals musteri.MusteriID
                        where arac.durum == 1 && arac.Sirketid == id
                        select new MusteriAracKiralama { AracMak = arac, KiralikMak = kiralik, MusteriMak = musteri };

            return View(query.ToList());
        }

        public ActionResult Onayla(int id)
        {
            var onayla = aracReposity.GetById(id);
            onayla.durum = 2;
            aracReposity.Update(onayla);
            return RedirectToAction("Index");
        }
        public ActionResult Reddet(int id)
        {
            var kiralaSil = kiralikRepository.GetById(id);
            kiralikRepository.Delete(kiralaSil);
            var reddet = aracReposity.GetById(kiralaSil.AracID);
            reddet.durum = 0;
            aracReposity.Update(reddet);
            return RedirectToAction("Index");
        }
    }
}