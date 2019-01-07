using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using YurtOtomasyonu.Models.mRole;

namespace YurtOtomasyonu.Models.mKullanici
{
    [Table("Kullanicilar")]
    public class Kullanicilar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(20)]
        public string UserName { get; set; }
        [StringLength(20)]
        public string Password { get; set; }
        [StringLength(20)]
        public string Email { get; set; }

        public bool isAdmin { get; set; }

        
        public virtual List<Roller> Roller { get; set; }
    }
}