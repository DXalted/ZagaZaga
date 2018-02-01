using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZagaZaga.Models;

namespace ZagaZaga.Controllers
{
    public class Send_CheckController : Controller
    {
        private mvcEntities db = new mvcEntities();
        //
        // GET: /Send_Check/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(send_check sc)
        {
            if (ModelState.IsValid)
            {
                db.send_check.Add(sc);
                db.SaveChanges();
                ViewBag.Message = "Submitted";

            }

            return RedirectToAction("Index", "Admin_Dashboard");
        }



    }
}
