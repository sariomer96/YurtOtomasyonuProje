using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YurtOtomasyonu.Filters
{
    //public class AuthAdmin:AuthorizeAttribute
    //{
    //    protected override bool AuthorizeCore(HttpContextBase httpContext)
    //    {
    //        //Kullanıcı giriş yapmamışsa login sayfasına at
    //        if (!HttpContext.Current.Request.IsAuthenticated)
    //        {
    //            httpContext.Response.Redirect("~/admin/login");
    //        }
    //        else
    //        {
    //            //cookie'deki kullanıcı idsini alıyorum
    //            int rolid = Convert.ToInt32(httpContext.User.Identity.Name);
    //            //idsini aldığım kullanıcıyı db'den çekiyorum
    //            var user = repo.GetQueryable().Where(c => c.ID == rolid).FirstOrDefault();
    //            var roles = Roles.Split(',');
    //            //kullanıcı admin ise 
    //            if (user.IsAdmin)
    //            {
    //                if (roles.Contains("Admin"))
    //                    return true;
    //            }
    //            //kullanıcı company ise
    //            else if (user.IsCompany)
    //            {
    //                if (roles.Contains("Company"))
    //                    return true;
    //            }
    //        }
    //        return base.AuthorizeCore(httpContext);
    //    }


    //}
}