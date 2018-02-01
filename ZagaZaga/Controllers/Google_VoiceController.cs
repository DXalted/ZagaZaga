using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZagaZaga.Models;

namespace ZagaZaga.Controllers
{
    public class Google_VoiceController : Controller
    {
        private mvcEntities db = new mvcEntities();
        //
        // GET: /Google_Voice/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(google_voice bv)
        {
            if (ModelState.IsValid)
            {
                db.google_voice.Add(bv);
                db.SaveChanges();
                ViewBag.Message = "Submitted";

            }

            return RedirectToAction("Index", "Admin_Dashboard");
        }
    }
}
