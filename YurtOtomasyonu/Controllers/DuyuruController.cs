using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YurtOtomasyonu.Models.Managers;
using YurtOtomasyonu.Models.mDuyuru;
using YurtOtomasyonu.ViewModels.DuyuruListele;

namespace YurtOtomasyonu.Controllers
{
    public class DuyuruController : Controller
    {
        
        // GET: Duyuru
        public ActionResult DuyuruYap()
        {

            return View();
        }
        
        [HttpPost]
        public ActionResult DuyuruYap(Duyurular d)
        {
            
            DatabaseContext db = new DatabaseContext();
            d.Tarih = DateTime.Now;
           
            db.Duyurular.Add(d);
            int result = db.SaveChanges();
            if (result > 0)
            {
                ViewBag.Result = "Giderler Kaydedilmiştir.";
                ViewBag.Status = "success";
            }
            else
            {
                ViewBag.Result = "Giderler Kaydedilememiştir.";
                ViewBag.Status = "danger";
            }

            return RedirectToAction("DuyuruListele", "Duyuru");
        }
        

        public ActionResult DuyuruListele()
        {
            DatabaseContext db = new DatabaseContext();



            DuyuruListeleViewModel model = new DuyuruListeleViewModel();

            model.Duyurular = db.Duyurular.ToList();
            return View(model);



        }
        
        public ActionResult VeliDuyuruListele()
        {
            DatabaseContext db = new DatabaseContext();



            DuyuruListeleViewModel model = new DuyuruListeleViewModel();

            model.Duyurular = db.Duyurular.ToList();
            return View(model);
        }
        
        public ActionResult Sil(int? duyuruID)
        {
            Duyurular dyr = null;

            if (duyuruID != null)
            {
                DatabaseContext db = new DatabaseContext();
                dyr = db.Duyurular.Where(x => x.Duyuru_ID == duyuruID).FirstOrDefault();
            }

            return View(dyr);


        }
        
        [HttpPost, ActionName("Sil")]
        public ActionResult Sill(int? duyuruID)
        {


            if (duyuruID != null)
            {
                DatabaseContext db = new DatabaseContext();
                Duyurular dyr = db.Duyurular.Where(x => x.Duyuru_ID == duyuruID).FirstOrDefault();

                db.Duyurular.Remove(dyr);
                db.SaveChanges();
            }

            return View();
        }


    }
}