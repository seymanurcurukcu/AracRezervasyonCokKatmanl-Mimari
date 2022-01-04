using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    [Table("tbl_Kullanicilar")]
    public class Kullanici
    {
        [Key]
        public int KullaniciID { get; set; }

        public int SirketID { get; set; }

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "KullaniciIsmi")]
        [StringLength(50, ErrorMessage = "Max 50 karakter olmalidir.")]
        public string KullaniciIsmi { get; set; }
        
        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "KullaniciSoyismi")]
        [StringLength(50, ErrorMessage = "Max 50 karakter olmalidir.")]
        public string KullaniciSoyismi { get; set; }
        
        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "KullaniciAdres")]
        [StringLength(250, ErrorMessage = "Max 250 karakter olmalidir.")]
        public string KullaniciAdres { get; set; }
       
        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "KullaniciTel")]
        [StringLength(11, ErrorMessage = "Max 11 karakter olmalidir.")]
        public string KullaniciTel { get; set; }
       
        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "KullaniciMail")]
        public string KullaniciMail { get; set; }
       
        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "KullaniciAdi")]
        public string KullaniciAdi { get; set; }
       
        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "Sifre")]
        public string Sifre { get; set; }

        public virtual Sirket Sirket { get; set; }
        
    }
}
