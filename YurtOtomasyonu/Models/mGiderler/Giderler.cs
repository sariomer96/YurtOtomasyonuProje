using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YurtOtomasyonu.Models.mGiderler
{
    [Table("Giderler")]
    public class Giderler
    {
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int gider_ID { get; set; }
            [StringLength(10),Required]
        public string elektrik { get; set; }

        [StringLength(10),Required]
        public string su { get; set; }

        [StringLength(10),Required]
        public string dogalgaz { get; set; }

        [StringLength(10),Required]
       public string yemekhane { get; set; }

        [StringLength(10),Required]
        public string calisan_maas { get; set; }
        [Required]
        public DateTime tarih { get; set; }


    }
}