using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZagaZaga.Models;

namespace ZagaZaga.Controllers
{
    public class ToolsController : Controller
    {
        private mvcEntities db = new mvcEntities();
        //
        // GET: /Tools/

        public ActionResult Index()
        {

            var check_sample = db.check_sample.Where(x => x.id != 0);
            ViewBag.cs = check_sample.ToList();

            var google_voice = db.google_voice.Where(x => x.id != 0);
            ViewBag.google = google_voice.ToList();

            var leads = db.leads.Where(x => x.id != 0);
            ViewBag.lead = leads.ToList();

            var letter = db.letter_writeups.Where(x => x.id != 0);
            ViewBag.let = letter.ToList();

            var mass_email = db.mass_email.Where(x => x.id != 0);
            ViewBag.me = mass_email.ToList();

            var mass_text = db.mass_text.Where(x => x.id != 0);
            ViewBag.mt = mass_text.ToList();


            var phone_no = db.phone_number.Where(x => x.id != 0);
            ViewBag.phone = phone_no.ToList();

            var rdp = db.rdp.Where(x => x.id != 0);
            ViewBag.rdp = rdp.ToList();

            var send_check = db.send_check.Where(x => x.id != 0);
            ViewBag.sc = send_check.ToList();

            return View();
        }

        [HttpPost]
        public string BuyItem(int ProductID, string ProductCategory)
        {

            int UserID = Convert.ToInt32(Session["user_id"]);
            string sUserID = UserID.ToString();
            //var ProductResult = new object();
            decimal ProductPrice = 0;
            decimal UserAmount = Convert.ToDecimal(Session["user_amount"]);

            if (ProductCategory == "RDP") { var ProductResult = db.rdp.Where(x => x.id == ProductID).FirstOrDefault(); ProductPrice = Convert.ToDecimal(ProductResult.price); }

            //if (ProductResult != null)
            {
                if (UserAmount > ProductPrice)
                {
                    my_stuff obj = new my_stuff();
                    obj.UserID = UserID;
                    obj.ProductID = ProductID;
                    obj.ProductType = ProductCategory;
                    obj.BuyDate = DateTime.Now;
                    db.my_stuff.Add(obj);
                    db.SaveChanges();

                    var amount = db.amount.Where(x => x.u_id == sUserID).FirstOrDefault();

                    if (amount != null)
                    {
                        amount.amount1 = (Convert.ToDecimal(amount.amount1) - ProductPrice).ToString();
                        db.Entry(amount).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                    var amount2 = db.amount.Where(x => x.u_id == sUserID).FirstOrDefault();
                    if (amount2 != null) Session["user_amount"] = amount2.amount1;

                    return JsonConvert.SerializeObject(obj);
                }
                else
                {
                    my_stuff obj = new my_stuff();
                    obj.UserID = 0;
                    return JsonConvert.SerializeObject(obj);
                }
            }
        }
    }
}

