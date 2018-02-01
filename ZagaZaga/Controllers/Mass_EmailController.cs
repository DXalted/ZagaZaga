using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZagaZaga.Models;

namespace ZagaZaga.Controllers
{
    public class Mass_EmailController : Controller
    {
        private mvcEntities db = new mvcEntities();
        //
        // GET: /Mass_Email/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(mass_email me)
        {
            if (ModelState.IsValid)
            {
                db.mass_email.Add(me);
                db.SaveChanges();
                ViewBag.Message = "Submitted";

            }

            return RedirectToAction("Index", "Admin_Dashboard");
        }
    }
}
