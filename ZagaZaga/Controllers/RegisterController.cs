using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZagaZaga.Models;

namespace ZagaZaga.Controllers
{
    public class RegisterController : Controller
    {
        private mvcEntities db = new mvcEntities();
        //
        // GET: /Register/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(user u)
        {



            //object data_q = db.user.Where(x => x.email == u.email || x.username == u.username);

            //if (!data_q.Equals(null))
            //{
            //    ViewBag.Message = "Registered already";
                
            //    ViewBag.data = data_q;
            //    return View();
            //}



            if (ModelState.IsValid)
            {
                db.user.Add(u);
                db.SaveChanges();
                ViewBag.Message = "Registered Successfully";
                
            }

            return RedirectToAction("Index","User_Login");
        }

    }
}
