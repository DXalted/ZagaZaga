using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZagaZaga.Models;

namespace ZagaZaga.Controllers
{
    public class Check_SampleController : Controller
    {
        private mvcEntities db = new mvcEntities();
        //
        // GET: /Check_Sample/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(check_sample cs)
        {
            if (ModelState.IsValid)
            {
                db.check_sample.Add(cs);
                db.SaveChanges();
                ViewBag.Message = "Submitted";

            }

            return RedirectToAction("Index", "Admin_Dashboard");
        }

    }
}
