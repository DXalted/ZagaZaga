using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZagaZaga.Models;

namespace ZagaZaga.Controllers
{
    public class Credit_CardController : Controller
    {
        private mvcEntities db = new mvcEntities();
        //
        // GET: /Credit_Card/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(credit_card cc)
        {
            if (ModelState.IsValid)
            {
                db.credit_card.Add(cc);
                db.SaveChanges();
                ViewBag.Message = "Submitted";

            }

            return RedirectToAction("Index", "Admin_Dashboard");
        }

    }
}
