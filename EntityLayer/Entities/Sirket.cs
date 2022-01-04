using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    [Table("tbl_Sirketler")]
    public class Sirket
    {
        [Key]
        public int SirketID { get; set; }

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "SirketAdi")]
        [StringLength(50, ErrorMessage = "Max 50 karakter olmalidir.")]
        public string SirketAdi { get; set; }

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "SirketIl")]
        [StringLength(100, ErrorMessage = "Max 100 karakter olmalidir.")]
        public string SirketIl { get; set; }

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "SirketIlce")]
        [StringLength(100, ErrorMessage = "Max 100 karakter olmalidir.")]
        public string SirketIlce { get; set; }

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "SirketMahalle")]
        [StringLength(100, ErrorMessage = "Max 100 karakter olmalidir.")]
        public string SirketMahalle { get; set; }

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "AracSayisi")]
        public int AracSayisi { get; set; }

        [Required(ErrorMessage = "Bos gecilmez")]
        [Display(Name = "SirketPuani")]
        public int SirketPuani { get; set; }

        public virtual ICollection<Arac> Aracs { get; set; } = new HashSet<Arac>();
        public virtual ICollection<Kullanici> Kullanicis { get; set; } = new HashSet<Kullanici>();

        public virtual ICollection<SirketYetkili> SirketYetkilis { get; set; } = new HashSet<SirketYetkili>();
    }
}
