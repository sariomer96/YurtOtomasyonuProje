using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YurtOtomasyonu.Models.Managers;
using YurtOtomasyonu.Models.mKullanici;
using YurtOtomasyonu.Models.mOgrenci;
using YurtOtomasyonu.ViewModels.OgrenciListele;
using YurtOtomasyonu;
namespace YurtOtomasyonu.Controllers
{
    
    public class OgrenciController : Controller
    {
       
       
        // GET: Ogrenci Kaydet
        public ActionResult Kaydet()
        {
            
            
            return View();
        }
        [HttpPost]
     public ActionResult Kaydet(Ogrenciler ogrenciler)
        {
            Kart krt = new Kart();

           

            DatabaseContext db = new DatabaseContext();
            //krt.KartGetir();
            

            if (db.Kullanici.Any(x => x.UserName == ogrenciler.UserName))
            {
                ViewBag.Duplicate = "Kullanici zaten var.";
                return View("Kaydet", ogrenciler);
            }
           

            db.Ogrenciler.Add(ogrenciler);
            
            int result = db.SaveChanges();
            if (result > 0)
            {
                ViewBag.Result = "Öğrenci Kaydedilmiştir.";
                ViewBag.Status = "success";
            }
            else
            {
                ViewBag.Result = "Öğrenci Kaydedilememiştir.";
                ViewBag.Status = "danger";
            }

            return RedirectToAction("OgrListele", "Ogrenci");
        }
        public ActionResult OgrListele()
        {

            DatabaseContext db = new DatabaseContext();


            
            OgrenciListeleViewModel model = new OgrenciListeleViewModel();

            model.Ogrenciler = db.Ogrenciler.ToList();
            return View(model);
        }
      
    public ActionResult Listele()
        {
            return View();
        }

        public ActionResult Sil(int? ogrenciID)
        {
            Ogrenciler ogr = null;

            if(ogrenciID != null)
            {
                DatabaseContext db = new DatabaseContext();
                ogr = db.Ogrenciler.Where(x => x.Ogrenci_ID == ogrenciID).FirstOrDefault();
            }

            return View(ogr);
        }

        [HttpPost,ActionName("Sil")]
        public ActionResult SilOnay(int? ogrenciID)
        {
            

            if (ogrenciID != null)
            {
                DatabaseContext db = new DatabaseContext();
                Ogrenciler ogr = db.Ogrenciler.Where(x => x.Ogrenci_ID == ogrenciID).FirstOrDefault();

                db.Ogrenciler.Remove(ogr);
                db.SaveChanges();
            }

            return RedirectToAction("OgrListele", "Ogrenci");
        }

        public ActionResult BilgileriGuncelle(int? ogrenciID)
        {
            Ogrenciler ogr = null;

            if(ogrenciID != null)
            {
                DatabaseContext db = new DatabaseContext();
                ogr = db.Ogrenciler.Where(x => x.Ogrenci_ID == ogrenciID).FirstOrDefault();
            }


            return View(ogr);
        }
        [HttpPost]
        public ActionResult BilgileriGuncelle(Ogrenciler model, int? ogrenciID)
        {
            DatabaseContext db = new DatabaseContext();
            Ogrenciler ogr = db.Ogrenciler.Where(x => x.Ogrenci_ID == ogrenciID).FirstOrDefault();

            if(ogr != null)
            {
                ogr.Adi = model.Adi;
                ogr.Soyadi = model.Soyadi;
                ogr.TC = model.TC;
                ogr.Kacini_Sinif = model.Kacini_Sinif;
                ogr.Telefon = model.Telefon;
                ogr.Veli_Tel = model.Veli_Tel;
                ogr.Adres = model.Adres;

                int sonuc = db.SaveChanges();

                if (sonuc > 0)
                {
                    ViewBag.Result = "Öğrenci Güncellenmiştir.";
                    ViewBag.Status = "success";
                }
                else
                {
                    ViewBag.Result = "Öğrenci Güncellenememiştir.";
                    ViewBag.Status = "danger";
                }

            }

            return View();
        }


        public ActionResult VeliOgrenciBilgileriGuncelle(int? ogrenciID)
        {
            Ogrenciler ogr = null;

            if (ogrenciID != null)
            {
                DatabaseContext db = new DatabaseContext();
                ogr = db.Ogrenciler.Where(x => x.Ogrenci_ID == ogrenciID).FirstOrDefault();
            }


            return View(ogr);
        }

        [HttpPost]
        public ActionResult VeliOgrenciBilgileriGuncelle(Ogrenciler model, int? ogrenciID)
        {
            DatabaseContext db = new DatabaseContext();
            Ogrenciler ogr = db.Ogrenciler.Where(x => x.Ogrenci_ID == ogrenciID).FirstOrDefault();

            if (ogr != null)
            {
                ogr.Adi = model.Adi;
                ogr.Soyadi = model.Soyadi;
                ogr.TC = model.TC;
                ogr.Kacini_Sinif = model.Kacini_Sinif;
                ogr.Telefon = model.Telefon;
                ogr.Veli_Tel = model.Veli_Tel;
                ogr.Adres = model.Adres;

                int sonuc = db.SaveChanges();

                if (sonuc > 0)
                {
                    ViewBag.Result = "Öğrenci Güncellenmiştir.";
                    ViewBag.Status = "success";
                }
                else
                {
                    ViewBag.Result = "Öğrenci Güncellenememiştir.";
                    ViewBag.Status = "danger";
                }

            }

            return View();

        }





    }
}