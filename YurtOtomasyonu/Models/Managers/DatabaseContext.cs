using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace YurtOtomasyonu.Models.Managers
{
    public class DatabaseContext:DbContext
    {
        public DbSet<mOgrenci.Ogrenciler> Ogrenciler  { get; set; }
        public DbSet<mPersonel.Calisanlar> Calisanlar { get; set; }
        public DbSet<mDuyuru.Duyurular> Duyurular { get; set; } 
        public DbSet <mGiderler.Giderler> Giderler { get; set; }
        public DbSet <mDisiplin.Disiplin> Disiplin { get; set; }
        public DbSet <mOda.Oda> Oda { get; set; }
        public DbSet <mKullanici.Kullanicilar> Kullanici { get; set; }



        public DatabaseContext()
        {
            Database.SetInitializer(new VeritabaniOlusturucu());
        }
    }
    public class VeritabaniOlusturucu: DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            

        }
    }
}