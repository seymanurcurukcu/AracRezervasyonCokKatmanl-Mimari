using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    [Table("tbl_Admin")]
    public class Admin
    {
        [Key]

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "MusteriKullaniciAdi")]
        public string AdminKullaniciAdi { get; set; }
        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "Sifre")]
        public string Sifre { get; set; }
    }
}
