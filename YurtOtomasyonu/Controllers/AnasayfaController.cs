using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace YurtOtomasyonu.Controllers
{
    [Authorize]
    public class AnasayfaController : Controller
    {
        
        // GET: Anasayfa
        public ActionResult Home()

        {


            
            return View();
        }
        [HttpPost]
        public ActionResult Home(HttpPostedFileBase photo)
        {
            var fileName = Path.GetFileName(photo.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
            photo.SaveAs(path);
            ViewBag.fileName = photo.FileName;
            ViewBag.Path = path;
            
            return View();
        }
        [Authorize]
        public ActionResult VeliAnasayfa()
        {
            return View();
        }

       
    }
}