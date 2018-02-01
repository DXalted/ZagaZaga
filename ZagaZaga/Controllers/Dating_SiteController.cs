using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZagaZaga.Models;

namespace ZagaZaga.Controllers
{
    public class Dating_SiteController : Controller
    {
        private mvcEntities db = new mvcEntities();
        //
        // GET: /Dating_Site/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(dating_site ds)
        {
            if (ModelState.IsValid)
            {
                db.dating_site.Add(ds);
                db.SaveChanges();
                ViewBag.Message = "Submitted";

            }

            return RedirectToAction("Index", "Admin_Dashboard");
        }

    }
}
