using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using YurtOtomasyonu.Models.mKullanici;

namespace YurtOtomasyonu.Models.mRole
{
    [Table("Roller")]
    public class Roller
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(30)]
        public string Rol { get; set; }

        public virtual Kullanicilar Kullanici { get; set; }


    }
}