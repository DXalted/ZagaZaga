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

        public ActionResult ssn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ssn(ssn ss)
        {
            if (ModelState.IsValid)
            {
                db.ssn.Add(ss);
                db.SaveChanges();
                ViewBag.Message = "Submitted";

            }

            return RedirectToAction("Index", "Admin_Dashboard");
        }


        public ActionResult ep()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ep(ep epp)
        {
            if (ModelState.IsValid)
            {
                db.ep.Add(epp);
                db.SaveChanges();
                ViewBag.Message = "Submitted";

            }

            return RedirectToAction("Index", "Admin_Dashboard");
        }

        public ActionResult Bulk()
        {
            return View();
        }

        public ActionResult Orders()
        {
            return View(db.my_stuff.ToList());
        }
    }
}
