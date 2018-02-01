using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZagaZaga.Models;

namespace ZagaZaga.Controllers
{
    public class Admin_LoginController : Controller
    {
        private mvcEntities db = new mvcEntities();
        //
        // GET: /Admin_Login/

        public ActionResult Index()
        {
            

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(admin ad)
        {
            var admin = db.admin.Where(x => x.Username == ad.Username && x.Password == ad.Password).FirstOrDefault();
            if (admin != null)
            {

                //u.LoginErrorMessage = "login";
                Session["user_id"] = admin.id;
                Session["user_name"] = admin.Username;


                return RedirectToAction("Index", "Admin_Dashboard");

            }
            else
            {
                //ad.LoginErrorMessage = "Wrong Username Or Password";
                return RedirectToAction("Index", "Admin_Login");
            }
            return View(ad);
        }

    }
}
