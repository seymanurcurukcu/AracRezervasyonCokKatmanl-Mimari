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
    public class MusteriRepository : GenericRepository<Musteri>
    {
        public List <Musteri> musteriListeleSirketeGore(int id)
        {
            DataContext db = new DataContext();
            var query = from kiralik in db.Kiraliks
                        join arac in db.Aracs
                        on kiralik.AracID equals arac.AracID 
                        join musteri in db.Musteris
                        on kiralik.MusteriID equals musteri.MusteriID
                        where arac.Sirketid == id
                        select musteri;
            return query.ToList();

                

        }

    }
}
