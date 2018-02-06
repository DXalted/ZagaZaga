using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZagaZaga.Models;

namespace ZagaZaga.Controllers
{
    public class Bank_AccountController : Controller
    {
        private mvcEntities db = new mvcEntities();
        //
        // GET: /Bank_Account/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(bank_account ba)
        {
            if (ModelState.IsValid)
            {
                db.bank_account.Add(ba);
                db.SaveChanges();
                ViewBag.Message = "Submitted";

            }

            return RedirectToAction("Index", "Admin_Dashboard");
        }


        









    }
}
