using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
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
        public ActionResult Suggest(string product, string web, string info, string amount, string price)
        {
            if (ModelState.IsValid)
            {
                suggest s = new suggest();
                s.product = product;
                s.web = web;
                s.info = info;
                s.amount = amount;
                s.price = price;
                s.username = Session["user_name"].ToString();
                s.email = Session["user_email"].ToString();


                db.suggest.Add(s);
                db.SaveChanges();
                ViewBag.Message = "Submitted";

            }
            var news = db.news.Where(x => x.id != 000);
            ViewBag.newss = news.ToList();
            return View("Index");
        }

        [HttpPost]
        public ActionResult Contact(string subject, string message)
        {
            if (ModelState.IsValid)
            {
                contact c = new contact();
               
                c.u_name = Session["user_name"].ToString();
                c.u_email = Session["user_email"].ToString();
                c.subject = subject;
                c.message = message;


                db.contact.Add(c);
                db.SaveChanges();
                ViewBag.Message = "Submitted";

            }
            var news = db.news.Where(x => x.id != 000);
            ViewBag.newss = news.ToList();
            return View("Index");
        }
        public ActionResult mystuff()
        {
            if (Session["user_id"] == null)
            {
                return RedirectToAction("Index", "User_Login");
            }

            var ID = new SqlParameter("@UserID", Convert.ToInt32(Session["user_id"]));
            return View(db.Database.SqlQuery<my_buy_stuff>("getMyStuff @UserID", ID).ToList());
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Index", "User_Login");
        }

        public ActionResult View_More()
        {
            return View();
        }
    }
}
