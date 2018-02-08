using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZagaZaga.Models;

namespace ZagaZaga.Controllers
{
    public class Snd_CheckController : Controller
    {
        private mvcEntities db = new mvcEntities();
        //
        // GET: /Snd_Check/

        public ActionResult personal_chk()
        {
            var p_chk = db.personal_chk.Where(x => x.id != 000);
            ViewBag.pc = p_chk.ToList();
            ViewBag.message = "";
            return View(p_chk.ToList());
        }

        public ActionResult company_chk()
        {
            var c_chk = db.company_chk.Where(x => x.id != 000);
            ViewBag.cc = c_chk.ToList();
            ViewBag.message = "";
            return View(c_chk.ToList());
        }

        [HttpPost]
        public ActionResult personal_chk(check_req model, int PID)
        {

            int UserID = Convert.ToInt32(Session["user_id"]);
            string sUserID = UserID.ToString();
            //var ProductResult = new object();

            decimal UserAmount = Convert.ToDecimal(Session["user_amount"]);

            var ProductResult = db.personal_chk.Where(x => x.id == PID).FirstOrDefault();
             decimal ProductPrice = Convert.ToDecimal(ProductResult.price); 

            //if (ProductResult != null)
            {
                if (UserAmount > ProductPrice)
                {
                    my_stuff obj = new my_stuff();
                    obj.UserID = UserID;
                    obj.ProductID = ProductResult.id;
                    obj.ProductType = "PC";
                    obj.BuyDate = DateTime.Now;
                    db.my_stuff.Add(obj);
                    db.SaveChanges();

                    model.check_type = "PC";
                    model.p_id = ProductResult.id;
                    model.u_id = UserID;
                    model.u_name = Session["user_name"].ToString();
                    model.amount = Convert.ToInt32(ProductResult.amount);
                    model.price = Convert.ToInt32(ProductResult.price);

                    db.check_req.Add(model);
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

                    //return JsonConvert.SerializeObject(obj);

                    ViewBag.message = "You have successfully buy this product";
                }
                else
                {
                    my_stuff obj = new my_stuff();
                    obj.UserID = 0;
                    ViewBag.message = "Oops! Something went wrong while Purchasing product";
                }
            }

            var p_chk = db.personal_chk.Where(x => x.id != 000);
            ViewBag.pc = p_chk.ToList();
            return View("personal_chk", p_chk.ToList());
        }

        [HttpPost]
        public ActionResult company_chk(check_req model, int PID)
        {

            int UserID = Convert.ToInt32(Session["user_id"]);
            string sUserID = UserID.ToString();
            //var ProductResult = new object();

            decimal UserAmount = Convert.ToDecimal(Session["user_amount"]);

            var ProductResult = db.company_chk.Where(x => x.id == PID).FirstOrDefault();
            decimal ProductPrice = Convert.ToDecimal(ProductResult.price);

            //if (ProductResult != null)
            {
                if (UserAmount > ProductPrice)
                {
                    my_stuff obj = new my_stuff();
                    obj.UserID = UserID;
                    obj.ProductID = ProductResult.id;
                    obj.ProductType = "CC";
                    obj.BuyDate = DateTime.Now;
                    db.my_stuff.Add(obj);
                    db.SaveChanges();

                    model.check_type = "CC";
                    model.p_id = ProductResult.id;
                    model.u_id = UserID;
                    model.u_name = Session["user_name"].ToString();
                    model.amount = Convert.ToInt32(ProductResult.amount);
                    model.price = Convert.ToInt32(ProductResult.price);

                    db.check_req.Add(model);
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

                    //return JsonConvert.SerializeObject(obj);

                    ViewBag.message = "You have successfully buy this product";
                }
                else
                {
                    my_stuff obj = new my_stuff();
                    obj.UserID = 0;
                    ViewBag.message = "Oops! Something went wrong while Purchasing product";
                }
            }

            var c_chk = db.company_chk.Where(x => x.id != 000);
            ViewBag.cc = c_chk.ToList();
            return View("company_chk", c_chk.ToList());
        }
        
    }
}
