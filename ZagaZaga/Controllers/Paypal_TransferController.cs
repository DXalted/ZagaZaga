using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZagaZaga.Models;

namespace ZagaZaga.Controllers
{
    public class Paypal_TransferController : Controller
    {
        private mvcEntities db = new mvcEntities();
        //
        // GET: /Paypal_Transfer/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(paypal_transfer pt)
        {
            if (ModelState.IsValid)
            {
                db.paypal_transfer.Add(pt);
                db.SaveChanges();
                ViewBag.Message = "Submitted";

            }

            return RedirectToAction("Index", "Admin_Dashboard");
        }

    }
}
