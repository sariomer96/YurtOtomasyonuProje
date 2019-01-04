using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using YurtOtomasyonu.Models.mOda;

namespace YurtOtomasyonu.Models.mOgrenci
{
    [Table("Ogrenciler")]
    public class Ogrenciler:mKullanici.Kullanicilar
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Ogrenci_ID { get; set; }
        [StringLength(20),Required]
        public string Adi { get; set; }

        [StringLength(20),Required]
        public string Soyadi { get; set; }

        [StringLength(11),Required]
        public string TC { get; set; }

        [StringLength(11), Required]
        public string Telefon { get; set; }
        [StringLength(11), Required]
        public string Veli_Tel { get; set; }
        [StringLength(2),Required]
        public string Kacini_Sinif { get; set; }
        [StringLength(250)]
        public string Adres { get; set; }

        [StringLength(20)]
        public string KartID { get; set; }
        


        public virtual Oda oda { get; set; }


        public virtual List<mDisiplin.Disiplin> Disiplin { get; set; }


    }
}