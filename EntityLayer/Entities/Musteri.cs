using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityLayer.Entities
{
    [Table("tbl_Musteriler")]
    public class Musteri
    {
        [Key]
        public int MusteriID { get; set; }
        [Required(ErrorMessage ="Bos gecilmez")]
        [Display(Name ="MusteriAd")]
        [StringLength(50,ErrorMessage ="Max 50 karakter olmalidir.")]
        public string MusteriAd { get; set; }
        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "MusteriSoyad")]
        [StringLength(50, ErrorMessage = "Max 50 karakter olmalidir.")]
        public string MusteriSoyad { get; set; }
        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "MusteriTCKimlikNo")]
        [StringLength(11, ErrorMessage = "Max 11 karakter olmalidir.")]
        public string MusteriTCKimlikNo { get; set; }
        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "MusteriAdres")]
        [StringLength(250, ErrorMessage = "Max 250 karakter olmalidir.")]
        public string MusteriAdres { get; set; }
        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "MusteriDogumTarihi")]
        public DateTime MusteriDogumTarihi { get; set; }
        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "MusteriTel")]
        [StringLength(11, ErrorMessage = "Max 11 karakter olmalidir.")]
        public string MusteriTel { get; set; }
        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "MusteriMail")]
   
        public string MusteriMail { get; set; }
        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "MusteriKullaniciAdi")]
        public string MusteriKullaniciAdi { get; set; }
        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "Sifre")]
        public string Sifre { get; set; }

        public virtual ICollection<Kiralik> Kiraliks { get; set; } = new HashSet<Kiralik>();
    }
}
