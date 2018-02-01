using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZagaZaga.Models;

namespace ZagaZaga.Controllers
{
    public class LeadsController : Controller
    {
        private mvcEntities db = new mvcEntities();
        //
        // GET: /Leads/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(leads l)
        {
            if (ModelState.IsValid)
            {
                db.leads.Add(l);
                db.SaveChanges();
                ViewBag.Message = "Submitted";

            }

            return RedirectToAction("Index", "Admin_Dashboard");
        }

    }
}
