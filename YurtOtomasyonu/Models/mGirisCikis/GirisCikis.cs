using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YurtOtomasyonu.Models.mGirisCikis
{
    [Table("GirisCikis")]
    public class GirisCikis
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        public DateTime YurtGiris { get; set; }


        public DateTime YurtCikis { get; set; }

        public DateTime YemekhaneGiris { get; set; }

        public DateTime YemekhaneCikis { get; set; }

        public DateTime EtutGiris  { get; set; }


        public DateTime EtutCikis { get; set; }

        public virtual mOgrenci.Ogrenciler Ogrenciler { get; set; }
    }
}