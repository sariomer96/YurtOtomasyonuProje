using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace YurtOtomasyonu.Models.mPersonel
{
    [Table("Calisanlar")]
    public class Calisanlar:mKullanici.Kullanicilar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int personel_ID { get; set; }
        [StringLength(25), Required]
        public string Adi { get; set; }

        [StringLength(20), Required]
        public string Soyadi { get; set; }

        [StringLength(11), Required]
        public string TC { get; set; }

        [StringLength(11), Required]
        public string Telefon { get; set; }
        
        

        [StringLength(250)]
        public string Adres { get; set; }

        [Required]
        public int Maas { get; set; }

        [StringLength(30), Required]
        public string Unvan { get; set; }
    }
}