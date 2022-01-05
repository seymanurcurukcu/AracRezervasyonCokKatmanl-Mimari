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
    public class SirketYoneticiMusteriListesiController : Controller
    {
        // GET: SirketYoneticiMusteriListesi
        MusteriRepository musteriRepository = new MusteriRepository();
        public ActionResult Index()
        {
            string Sirketid = Session["Sirketid"].ToString();
            int id = Convert.ToInt32(Sirketid);
            var sorgu = musteriRepository.musteriListeleSirketeGore(id);        
            return View(sorgu);

          


        }
    }
}