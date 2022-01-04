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
    public class KullaniciRepository: GenericRepository<Kullanici>
    {

        DataContext db = new DataContext();
        public List<Kullanici> kullaniciListeleSirketeGore(int id)
        {
            return db.Kullanicis.Where(x => x.SirketID == id).ToList();
        }
        

    }
}
