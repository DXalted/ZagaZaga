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
    public class User_LoginController : Controller
    {
        private mvcEntities db = new mvcEntities();
        //
        // GET: /User_Login/

        public ActionResult Index()
        {
            if (Session["user_id"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(user u)
        {
            var userdetails = db.user.Where(x => x.username == u.username && x.userpass == u.userpass).FirstOrDefault();
            if (userdetails != null)
            {
                string USerID = userdetails.id.ToString();
                var amount = db.amount.Where(x => x.u_id == USerID).FirstOrDefault();
                if (amount != null)
                {
                    Session["user_amount"] = amount.amount1;
                }
                else
                {
                    Session["user_amount"] = "0";
                }
                Session["user_id"] = userdetails.id;
                Session["user_name"] = userdetails.username;
                Session["user_type"] = userdetails.type;

                ViewBag.Message = "Login Successfully";
                return RedirectToAction("Index", "Home");

                //if (Session["user_type"] == "VIP" || Session["user_type"] == "vip")
                //{

                //}
            }
            else
            {
                ViewBag.Message = "Wrong Username Or Password";
                return RedirectToAction("Index", "User_Login");
            }
            return View(u);
        }
        public string VIP(string UserID)
        {
            int id = Convert.ToInt32(Session["user_id"]);
            string sUserID = id.ToString();
            var userdetails = db.user.Where(x => x.id == id).FirstOrDefault();
            if (userdetails != null)
            {
                if (userdetails.type != "vip" || userdetails.type != "VIP")
                {
                    var amount = db.amount.Where(x => x.u_id == sUserID).FirstOrDefault();
                    if (amount != null)
                    {
                        if (Convert.ToDecimal(amount.amount1) >= 100)
                        {
                            amount.amount1 = (Convert.ToDecimal(amount.amount1) - 100).ToString();
                            db.Entry(amount).State = EntityState.Modified;
                            db.SaveChanges();

                            userdetails.type = "VIP";
                            userdetails.date = DateTime.Now.ToString();
                            db.Entry(userdetails).State = EntityState.Modified;
                            db.SaveChanges();
                            var amount2 = db.amount.Where(x => x.u_id == sUserID).FirstOrDefault();
                            if (amount2 != null) Session["user_amount"] = amount2.amount1;
                            return JsonConvert.SerializeObject("You have successfully become a VIP member");
                        }
                        else
                        {
                            return JsonConvert.SerializeObject("Oops! It's look like you dont have enough amount");
                        }
                    }
                    else
                    {
                        return JsonConvert.SerializeObject("Oops! It's look like you dont have enough amount");
                    }
                }
                else
                {
                    return JsonConvert.SerializeObject("You Are Already A Vip Member");
                }
            }
            return "";
        }

    }
}
