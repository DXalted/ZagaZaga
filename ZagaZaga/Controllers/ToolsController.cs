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
            return RedirectToAction("Index", "RDP");
        }

        public ActionResult Check_Sample()
        {
            if (Session["user_id"] == null) return RedirectToAction("Index", "User_Login");
            return View(db.check_sample.Where(c => !db.my_stuff.Select(b => b.ProductID).Contains(c.id)).ToList());
        }
        public ActionResult RDP()
        {
            if (Session["user_id"] == null) return RedirectToAction("Index", "User_Login");
            return View(db.rdp.Where(c => !db.my_stuff.Select(b => b.ProductID).Contains(c.id)).ToList());
        }
        public ActionResult Send_Check()
        {
            if (Session["user_id"] == null) return RedirectToAction("Index", "User_Login");
            return View(db.send_check.Where(c => !db.my_stuff.Select(b => b.ProductID).Contains(c.id)).ToList());
        }
        public ActionResult Phone_Number()
        {
            if (Session["user_id"] == null) return RedirectToAction("Index", "User_Login");
            return View(db.phone_number.Where(c => !db.my_stuff.Select(b => b.ProductID).Contains(c.id)).ToList());
        }
        public ActionResult Mass_Text()
        {
            if (Session["user_id"] == null) return RedirectToAction("Index", "User_Login");
            return View(db.mass_text.Where(c => !db.my_stuff.Select(b => b.ProductID).Contains(c.id)).ToList());
        }
        public ActionResult Mass_Email()
        {
            if (Session["user_id"] == null) return RedirectToAction("Index", "User_Login");
            return View(db.mass_email.Where(c => !db.my_stuff.Select(b => b.ProductID).Contains(c.id)).ToList());
        }
        public ActionResult Letter_Writeups()
        {
            if (Session["user_id"] == null) return RedirectToAction("Index", "User_Login");
            return View(db.letter_writeups.Where(c => !db.my_stuff.Select(b => b.ProductID).Contains(c.id)).ToList());
        }
        public ActionResult Leads()
        {
            if (Session["user_id"] == null) return RedirectToAction("Index", "User_Login");
            return View(db.leads.Where(c => !db.my_stuff.Select(b => b.ProductID).Contains(c.id)).ToList());
        }
        public ActionResult Google_Voice()
        {
            if (Session["user_id"] == null) return RedirectToAction("Index", "User_Login");
            return View(db.google_voice.Where(c => !db.my_stuff.Select(b => b.ProductID).Contains(c.id)).ToList());
        }
        public ActionResult EP()
        {
            if (Session["user_id"] == null) return RedirectToAction("Index", "User_Login");
            return View(db.ep.Where(c => !db.my_stuff.Select(b => b.ProductID).Contains(c.id)).ToList());
        }
        public ActionResult SSn()
        {
            if (Session["user_id"] == null) return RedirectToAction("Index", "User_Login");
            return View(db.ssn.Where(c => !db.my_stuff.Select(b => b.ProductID).Contains(c.id)).ToList());
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
            if (ProductCategory == "Check_Sample") { var ProductResult = db.check_sample.Where(x => x.id == ProductID).FirstOrDefault(); ProductPrice = Convert.ToDecimal(ProductResult.price); }
            if (ProductCategory == "Send_Check") { var ProductResult = db.send_check.Where(x => x.id == ProductID).FirstOrDefault(); ProductPrice = Convert.ToDecimal(ProductResult.price); }
            if (ProductCategory == "Phone_Number") { var ProductResult = db.phone_number.Where(x => x.id == ProductID).FirstOrDefault(); ProductPrice = Convert.ToDecimal(ProductResult.price); }
            if (ProductCategory == "Mass_Text") { var ProductResult = db.mass_text.Where(x => x.id == ProductID).FirstOrDefault(); ProductPrice = Convert.ToDecimal(ProductResult.price); }
            if (ProductCategory == "Mass_Email") { var ProductResult = db.mass_email.Where(x => x.id == ProductID).FirstOrDefault(); ProductPrice = Convert.ToDecimal(ProductResult.price); }
            if (ProductCategory == "Letter_Writeups") { var ProductResult = db.letter_writeups.Where(x => x.id == ProductID).FirstOrDefault(); ProductPrice = Convert.ToDecimal(ProductResult.price); }
            if (ProductCategory == "Leads") { var ProductResult = db.leads.Where(x => x.id == ProductID).FirstOrDefault(); ProductPrice = Convert.ToDecimal(ProductResult.price); }
            if (ProductCategory == "Google_Voice") { var ProductResult = db.google_voice.Where(x => x.id == ProductID).FirstOrDefault(); ProductPrice = Convert.ToDecimal(ProductResult.price); }
            if (ProductCategory == "EP") { var ProductResult = db.ep.Where(x => x.id == ProductID).FirstOrDefault(); ProductPrice = Convert.ToDecimal(ProductResult.price); }
            if (ProductCategory == "SSN") { var ProductResult = db.ssn.Where(x => x.id == ProductID).FirstOrDefault(); ProductPrice = Convert.ToDecimal(ProductResult.price); }

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

