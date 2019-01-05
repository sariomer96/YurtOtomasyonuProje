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

            
            if (db.Kullanici.Any(x => x.UserName == kullanici.UserName) && db.Kullanici.Any(x => x.Password == kullanici.Password))
            {

                
                    return RedirectToAction("Home", "Anasayfa");
                


            }
            else if (db.Kullanici.Any(x => x.UserName != kullanici.UserName))
            {
                return View();
            }
            else
            {
                return View();
            }



        }
    

}
}