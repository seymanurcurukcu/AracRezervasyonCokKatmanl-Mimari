using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    [Table("tbl_Araclar")]
    public class Arac
    {
        [Key]
        public int AracID { get; set; }
        public int Sirketid { get; set; }

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "AracAdi")]
        [StringLength(50, ErrorMessage = "Max 50 karakter olmalidir.")]
        public string AracAdi { get; set; }

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "Modeli")]
        [StringLength(50, ErrorMessage = "Max 50 karakter olmalidir.")]
        public string Modeli { get; set; }

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "EhliyetYasi")]
        public int EhliyetYasi { get; set; }

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "MinimumYasSiniri")]
        public int MinimumYasSiniri { get; set; }

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "GunlukSinirKm")]
        public int GunlukSinirKm { get; set; }

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "AracınKendiAnlikKm")]
        public int AracınKendiAnlikKm { get; set; }

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "Airbag")]
        public int Airbag { get; set; }

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "BagajHacmi")]
        public int BagajHacmi { get; set; }

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "KoltukSayisi")]
        public int KoltukSayisi { get; set; }

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "GunlukKiralikFiyati")]
        public decimal GunlukKiralikFiyati { get; set; }

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "Yakiti")]
        [StringLength(50, ErrorMessage = "Max 50 karakter olmalidir.")]
        public string Yakiti { get; set; }

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "vitesTuru")]
        [StringLength(50, ErrorMessage = "Max 50 karakter olmalidir.")]
        public string vitesTuru { get; set; }

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "durum")]
        public int durum { get; set; }
        public string resim { get; set; }

        public virtual Sirket Sirket { get; set; }

        public virtual ICollection<Kiralik> Kiraliks { get; set; } = new HashSet<Kiralik>();
    }
}
