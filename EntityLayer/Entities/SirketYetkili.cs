using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    [Table("tbl_SirketYonetici")]
    public class SirketYetkili
    {
        [Key]
        public int SirketYoneticiID { get; set; }

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "YoneticiAdi")]
        [StringLength(50, ErrorMessage = "Max 50 karakter olmalidir.")]
        public string YoneticiAdi { get; set; }

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "YoneticiSoyadi")]
        [StringLength(50, ErrorMessage = "Max 50 karakter olmalidir.")]
        public string YoneticiSoyadi { get; set; }

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "YoneticiDogumTarihi")]
        public DateTime YoneticiDogumTarihi { get; set; }

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "YoneticiTel")]
        [StringLength(11, ErrorMessage = "Max 11 karakter olmalidir.")]
        public string YoneticiTel { get; set; }

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "YoneticiMail")]
        public string YoneticiMail { get; set; }

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "YoneticiKullaniciAdi")]
        public string YoneticiKullaniciAdi { get; set; }

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "Sifre")]
        public string Sifre { get; set; }
        public int Sirketid { get; set; }
        public virtual Sirket Sirket { get; set; }

    }
}
