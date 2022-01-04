using BusinessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AracRepository : GenericRepository<Arac>
    {

        DataContext db = new DataContext();

        public List<Arac> aracListeleSirketeGore(int id)
        {
            return db.Aracs.Where(x => x.Sirketid == id).ToList();
        }
        public List<Arac> aracListe()
        {
            bool durum = false;
            return db.Aracs.Where(x => x.durum == durum).ToList();
        }

        public List<Arac> AracAdreseGoreListeleme(string il, string ilce, string mahalle)
        {
            return db.Aracs.Where(x => x.Sirket.SirketIl == il || x.Sirket.SirketIlce == ilce || x.Sirket.SirketMahalle == mahalle).ToList();
        }
        public List<Arac> AracViteseGoreListeleme(string vites)
        {
            return db.Aracs.Where(x => x.vitesTuru == vites).ToList();
        }
        public List<Arac> AracYakıtaGoreListeleme(string yakit)
        {
            return db.Aracs.Where(x => x.Yakiti == yakit).ToList();
        }
        public List<Arac> KoltukSayisinaGoreListeleme(int koltuk)
        {
            return db.Aracs.Where(x => x.KoltukSayisi == koltuk).ToList();
        }

        public List<Arac> AracModelineGoreListeleme(string aracAdi)
        {
            return db.Aracs.Where(x => x.AracAdi == aracAdi).ToList();
        }
        public List<Arac> AracFiyatinaGoreListeleme(decimal min, decimal max)
        {

            return db.Aracs.Where(x => x.GunlukKiralikFiyati > min && x.GunlukKiralikFiyati < max).ToList();
        }
        public List<Arac> azdanCogaSiralama()
        {

            return db.Aracs.OrderBy(x => x.GunlukKiralikFiyati).ToList();
        }
        public List<Arac> CoktanAzaSiralama()
        {

            return db.Aracs.OrderByDescending(X => X.GunlukKiralikFiyati).ToList();
        }
    }
}
