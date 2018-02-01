using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZagaZaga.Models;

namespace ZagaZaga.Controllers
{
    public class Phone_NumberController : Controller
    {
        private mvcEntities db = new mvcEntities();
        //
        // GET: /Phone_Number/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(phone_number pn)
        {
            if (ModelState.IsValid)
            {
                db.phone_number.Add(pn);
                db.SaveChanges();
                ViewBag.Message = "Submitted";

            }

            return RedirectToAction("Index", "Admin_Dashboard");
        }
    }
}
