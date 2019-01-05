using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YurtOtomasyonu.Controllers
{
    public class AnasayfaController : Controller
    {
        
        // GET: Anasayfa
        public ActionResult Home()
        {
            return View();
        }
        [Authorize]
        public ActionResult VeliAnasayfa()
        {
            return View();
        }
    }
}