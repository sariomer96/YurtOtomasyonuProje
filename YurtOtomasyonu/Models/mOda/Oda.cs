using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using YurtOtomasyonu.Models.mOgrenci;

namespace YurtOtomasyonu.Models.mOda
{
    [Table("Oda")]
    public class Oda
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int oda_ID { get; set; }

        [Required]
       public int oda_NO { get; set; }

        public virtual List<Ogrenciler> Ogrenciler { get; set; }
    }
}