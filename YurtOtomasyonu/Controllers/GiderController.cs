using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YurtOtomasyonu.Models.Managers;
using YurtOtomasyonu.Models.mGiderler;
using YurtOtomasyonu.ViewModels.GiderListele;

namespace YurtOtomasyonu.Controllers
{
    [Authorize]
    public class GiderController : Controller
    {
        // GET: Gider
        
        public ActionResult Ekle()
        {
            
            return View();

        }
             [HttpPost]
        
        public ActionResult Ekle(Giderler giderler)
        {

            DatabaseContext db = new DatabaseContext();
            giderler.tarih = DateTime.Now;
            db.Giderler.Add(giderler);
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
            

            return View();
        }
        
        public ActionResult Listele()
        {

            DatabaseContext db = new DatabaseContext();



            GiderListViewModel model = new GiderListViewModel();

            model.Giderler = db.Giderler.ToList();
            return View(model);
        }
        
        public ActionResult Guncelle() { 
        

            return View();
        }

    }
}