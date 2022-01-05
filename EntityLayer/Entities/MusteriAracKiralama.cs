using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    class MusteriAracKiralama
    {
        public Arac AracMak { get; set; }
        public Musteri MusteriMak { get; set; }
        public Kiralik KiralikMak { get; set; }
    }
}
