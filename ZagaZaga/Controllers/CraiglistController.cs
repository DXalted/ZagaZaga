using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZagaZaga.Models;

namespace ZagaZaga.Controllers
{
    public class CraiglistController : Controller
    {
        private mvcEntities db = new mvcEntities();
        //
        // GET: /Craiglist/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(craigslist c)
        {
            if (ModelState.IsValid)
            {
                db.craigslist.Add(c);
                db.SaveChanges();
                ViewBag.Message = "Submitted";

            }

            return RedirectToAction("Index", "Admin_Dashboard");
        }
    }
}
