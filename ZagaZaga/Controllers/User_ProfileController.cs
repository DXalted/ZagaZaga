using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZagaZaga.Models;

namespace ZagaZaga.Controllers
{
    public class User_ProfileController : Controller
    {
        private mvcEntities db = new mvcEntities();
        //
        // GET: /User_Profile/

        public ActionResult Index()
        {
            int u_id = Convert.ToInt32(Session["user_id"]);
            var usr = db.user.Where(x => x.id == u_id);
            if (usr != null)
            {
                ViewBag.usr = usr.ToList();
            }
            
            
            return View();
        }


        
        //public ActionResult Index(user u)
        //{


        //    int id = Convert.ToInt32(Session["user_id"]);
        //    var userdetails = db.user.Where(x => x.id == id).FirstOrDefault();
        //    if (userdetails != null)
        //    {

        //        userdetails.userpass = u.confpass;
        //        userdetails.icq_yim = u.icq_yim;


        //            db.Entry(userdetails).State = EntityState.Modified;
        //            //db.user.Add(userdetails);
        //            db.SaveChanges();




        //            ViewBag.Message = "Become VIP";
            

        //    }
        


        //    int u_id = Convert.ToInt32(Session["user_id"]);
        //    var usr = db.user.Where(x => x.id == u_id);
        //    if (usr != null)
        //    {
        //        ViewBag.usr = usr.ToList();
        //    }


        //    return View();
        //}
        }
}
