using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZagaZaga.Models;

namespace ZagaZaga.Controllers
{
    public class Shipping_AccountController : Controller
    {
        private mvcEntities db = new mvcEntities();
        //
        // GET: /Shipping_Account/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(shipping_account sa)
        {
            if (ModelState.IsValid)
            {
                db.shipping_account.Add(sa);
                db.SaveChanges();
                ViewBag.Message = "Submitted";

            }

            return RedirectToAction("Index", "Admin_Dashboard");
        }

    }
}
