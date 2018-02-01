using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZagaZaga.Models;

namespace ZagaZaga.Controllers
{
    public class Admin_DashboardController : Controller
    {
        private mvcEntities db = new mvcEntities();
        //
        // GET: /Admin_Dashboard/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult C_Check()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult C_Check(company_chk cc)
        {
            if (ModelState.IsValid)
            {
                db.company_chk.Add(cc);
                db.SaveChanges();
                ViewBag.Message = "Submitted";

            }

            return RedirectToAction("Index", "Admin_Dashboard");
        }


        public ActionResult P_Check()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult P_Check(personal_chk pc)
        {
            if (ModelState.IsValid)
            {
                db.personal_chk.Add(pc);
                db.SaveChanges();
                ViewBag.Message = "Submitted";

            }

            return RedirectToAction("Index", "Admin_Dashboard");
        }



    }
}
