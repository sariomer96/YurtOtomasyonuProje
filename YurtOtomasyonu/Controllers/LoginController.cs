using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YurtOtomasyonu.Models.Managers;
using YurtOtomasyonu.Models.mKullanici;

namespace YurtOtomasyonu.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Kullanicilar kullanici)
        {

            DatabaseContext db = new DatabaseContext();

            Kullanicilar result = db.Kullanici.Where(x => x.UserName == kullanici.UserName).FirstOrDefault();

            
            if (db.Kullanici.Any(x => x.UserName == kullanici.UserName) && db.Kullanici.Any(x => x.Password == kullanici.Password))
            {
                if (result.isAdmin)
                {
                    return RedirectToAction("Home", "Anasayfa");
                }
                else
                {
                    return RedirectToAction("VeliAnasayfa", "Anasayfa");
                }

            }
           
            else
            {
                return View();
            }



        }
    

}
}