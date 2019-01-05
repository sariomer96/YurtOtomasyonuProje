using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YurtOtomasyonu.Controllers
{
    [Authorize]
    public class BorcController : Controller
    {
        // GET: Borc
        
        public ActionResult Listele()
        {
            return View();
        }
       
        public ActionResult Guncelle()
        {
            return View();
        }

    }
}