using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZagaZaga.Models;

namespace ZagaZaga.Controllers
{
    public class HomeController : Controller
    {
        private mvcEntities db = new mvcEntities();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if (Session["user_id"] == null)
            {
                return RedirectToAction("Index", "User_Login");
            }

            var news = db.news.Where(x => x.id != 000);
            ViewBag.newss = news.ToList();
            
            return View();
        }

        public ActionResult Accounts()
        {
            var bank_account = db.bank_account.Where(x => x.id != 000);
            ViewBag.bank = bank_account.ToList();

            var shipping_account = db.shipping_account.Where(x => x.id != 0);
            ViewBag.ship = shipping_account.ToList();

            var craiglist = db.craigslist.Where(x => x.id != 0);
            ViewBag.crg = craiglist.ToList();

            var dating_site = db.dating_site.Where(x => x.id != 0);
            ViewBag.date = dating_site.ToList();

            return View();
        }

        public ActionResult Transfers()
        {
            var paypal_transfer = db.paypal_transfer.Where(x => x.id != 0);
            ViewBag.pay = paypal_transfer.ToList();

            var bank_transfer = db.bank_transfer.Where(x => x.id != 0);
            ViewBag.bt = bank_transfer.ToList();

            var credit_card = db.credit_card.Where(x => x.id != 0);
            ViewBag.cc = credit_card.ToList();



            return View();
        }

        public ActionResult Suggest()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Suggest(suggest sg)
        {
            if (ModelState.IsValid)
            {
                db.suggest.Add(sg);
                db.SaveChanges();
                ViewBag.Message = "Submitted";

            }
            return View();
        }

    }
}
