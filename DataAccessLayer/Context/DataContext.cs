using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class DataContext:DbContext
    {
 
        public DbSet<Admin> Admins{ get; set; }
        public DbSet<Arac> Aracs { get; set; }
        public DbSet<Kiralik> Kiraliks { get; set; }
        public DbSet<Kullanici> Kullanicis { get; set; }
        public DbSet<Musteri> Musteris { get; set; }
        public DbSet<Sirket> Sirkets { get; set; }
        public DbSet<SirketYetkili> SirketYetkilis { get; set; }

        public DataContext()
        {

        }
    }
}
