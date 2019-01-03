using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YurtOtomasyonu.Models.mDisiplin
{
    [Table("Disiplin")]
    public class Disiplin
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int disiplin_ID { get; set; }

        [StringLength(55), Required]
        public string konu { get; set; }

        [StringLength(400),Required]
         public string aciklama { get; set; }
        [Required]
        public DateTime Tarih { get; set; }

        public virtual mOgrenci.Ogrenciler Ogrenciler { get; set; }

    }
}