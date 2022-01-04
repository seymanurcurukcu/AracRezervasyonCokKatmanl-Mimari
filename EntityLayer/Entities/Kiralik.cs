using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    [Table("tbl_KiralamaBilgisi")]
    public class Kiralik
    {
        [Key]
        public int KiralamaID { get; set; }
        public int MusteriID { get; set; }
        public int AracID { get; set; }
        public DateTime VerilisTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public int ilkKm { get; set; }
        public int SonKm { get; set; }
        public int AlınanÜcret { get; set; }

        public virtual Musteri Musteri { get; set; }

        public virtual Arac Arac { get; set; }

    }
}
