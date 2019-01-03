using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YurtOtomasyonu.Models.mDuyuru
{
    [Table("Duyurular")]
    public class Duyurular
    {


        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Duyuru_ID { get; set; }

        [StringLength(500),Required]
        public string Duyuru { get; set; }
        [Required]
        public DateTime Tarih { get; set; }
        [Required]
        public string Konu { get; set; }


    }
}