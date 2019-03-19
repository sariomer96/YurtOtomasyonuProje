using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YurtOtomasyonu.Models.Managers;
using YurtOtomasyonu.ViewModels.GirisCikisListele;
using YurtOtomasyonu.ViewModels.OgrenciListele;

namespace YurtOtomasyonu.Controllers
{
    public class GirisCikisController : Controller
    {
        // GET: GirisCikis
        public ActionResult veliGirisCikis()
        {

            DatabaseContext db = new DatabaseContext();



            GirisCikisListeleViewModel model = new GirisCikisListeleViewModel();

            model.GirisCikislar = db.GirisCikislar.ToList();
            return View(model);
        }
    }
}