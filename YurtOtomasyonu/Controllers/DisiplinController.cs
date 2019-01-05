using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YurtOtomasyonu.Models.Managers;
using YurtOtomasyonu.Models.mDisiplin;
using YurtOtomasyonu.Models.mOgrenci;
using YurtOtomasyonu.ViewModels.DisiplinListele;

namespace YurtOtomasyonu.Controllers
{
    [Authorize]
    public class DisiplinController : Controller
    {
        
        // GET: Disiplin
        public ActionResult Ekle()
        {
            DatabaseContext db = new DatabaseContext();
            List<Ogrenciler> ogrenciler = db.Ogrenciler.ToList();
            List<SelectListItem> ogrencilerList = new List<SelectListItem>();

            foreach(Ogrenciler ogrenci in ogrenciler )
            {
                SelectListItem item = new SelectListItem();
                item.Text=ogrenci.Adi+" "+ ogrenci.Soyadi;
                item.Value = ogrenci.Ogrenci_ID.ToString();
                ogrencilerList.Add(item);
            }
            
            TempData["ogrenciler"] = ogrencilerList;
            ViewBag.ogrenciler = ogrencilerList;
            return View();
        }
        [HttpPost]
        

        public ActionResult Ekle(Disiplin disiplin)
        {
            DatabaseContext db = new DatabaseContext();
            disiplin.Tarih = DateTime.Now;
            Ogrenciler ogrenci = db.Ogrenciler.Where(x => x.Ogrenci_ID == disiplin.Ogrenciler.Ogrenci_ID).FirstOrDefault();
            if(ogrenci !=null)
            {
                disiplin.Ogrenciler = ogrenci;
                db.Disiplin.Add(disiplin);
                int sonuc = db.SaveChanges();

                if (sonuc > 0)
                {
                    ViewBag.Result = "Disiplin Kaydedilmiştir.";
                    ViewBag.Status = "success";
                }
                else
                {
                    ViewBag.Result = "Disiplin Kaydedilememiştir.";
                    ViewBag.Status = "danger";
                }

            }
            
            
           

            ViewBag.ogrenciler = TempData["ogrenciler"];
            return RedirectToAction("DisiplinListele", "Disiplin");
        }
        
        public ActionResult DisiplinListele()
        {
            DatabaseContext db = new DatabaseContext();



            DisiplinListeleViewModel model = new DisiplinListeleViewModel();

            model.Disiplin = db.Disiplin.ToList();
            return View(model);
            
        }
      

        public ActionResult DisiplinSil(int? disiplinID)
        {
            Disiplin dsp = null;

            if (disiplinID != null)
            {
                DatabaseContext db = new DatabaseContext();
                dsp= db.Disiplin.Where(x => x.disiplin_ID == disiplinID).FirstOrDefault();
            }

            return View(dsp);
        }
        

        [HttpPost, ActionName("DisiplinSil")]
        public ActionResult SilOnay(int? disiplinID)
        {


            if (disiplinID != null)
            {
                DatabaseContext db = new DatabaseContext();
                Disiplin dsp = db.Disiplin.Where(x => x.disiplin_ID == disiplinID).FirstOrDefault();

                db.Disiplin.Remove(dsp);
                db.SaveChanges();
            }

            return RedirectToAction("DisiplinListele", "Disiplin");
        }

    }
}