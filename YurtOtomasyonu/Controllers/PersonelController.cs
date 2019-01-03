using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YurtOtomasyonu.Models.Managers;
using YurtOtomasyonu.Models.mPersonel;
using YurtOtomasyonu.ViewModels.PersonelListele;

namespace YurtOtomasyonu.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        public ActionResult Ekle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Calisanlar calisanlar)
        {
            DatabaseContext db = new DatabaseContext();
            db.Calisanlar.Add(calisanlar);
            int result = db.SaveChanges();
            if (result > 0)
            {
                ViewBag.Result = "Personel Kaydedilmiştir.";
                ViewBag.Status = "success";
            }
            else
            {
                ViewBag.Result = "Personel Kaydedilememiştir.";
                ViewBag.Status = "danger";
            }

            return View();
        }
        

        public ActionResult Sil(int? personelID)
        {
            Calisanlar calisan = null;

            if (personelID != null)
            {
                DatabaseContext db = new DatabaseContext();
                calisan = db.Calisanlar.Where(x => x.personel_ID == personelID).FirstOrDefault();
            }

            return View(calisan);
        }

        [HttpPost, ActionName("Sil")]
        public ActionResult SilOnay(int? personelID)
        {


            if (personelID != null)
            {
                DatabaseContext db = new DatabaseContext();
                Calisanlar calisan = db.Calisanlar.Where(x => x.personel_ID == personelID).FirstOrDefault();

                db.Calisanlar.Remove(calisan);
                db.SaveChanges();
            }

            return RedirectToAction("PersonelListele", "Personel");
        }

        public ActionResult PersonelListele()
        {
            DatabaseContext db = new DatabaseContext();



            PersonelListeleViewModel model = new PersonelListeleViewModel();

            model.Calisanlar = db.Calisanlar.ToList();
            

            return View(model);
        }
        public ActionResult BilgileriGuncelle(int? personelID)  
        {
            Calisanlar calisan = null;

            if (personelID != null)
            {
                DatabaseContext db = new DatabaseContext();
                calisan = db.Calisanlar.Where(x => x.personel_ID == personelID).FirstOrDefault();
            }


            return View(calisan);
        }


        [HttpPost]
        public ActionResult BilgileriGuncelle(Calisanlar model, int? personelID)
        {
            DatabaseContext db = new DatabaseContext();
            Calisanlar calisan = db.Calisanlar.Where(x => x.personel_ID == personelID).FirstOrDefault();

            if (calisan != null)
            {
                calisan.Adi = model.Adi;
                calisan.Soyadi = model.Soyadi;
                calisan.TC = model.TC;
                calisan.Maas = model.Maas;
                calisan.Telefon = model.Telefon;
                calisan.Unvan = model.Unvan;
                calisan.Adres = model.Adres;

                int sonuc = db.SaveChanges();

                if (sonuc > 0)
                {
                    ViewBag.Result = "Personel Güncellenmiştir.";
                    ViewBag.Status = "success";
                }
                else
                {
                    ViewBag.Result = "Personel Güncellenememiştir.";
                    ViewBag.Status = "danger";
                }

            }

            return View();
        }

    }
}