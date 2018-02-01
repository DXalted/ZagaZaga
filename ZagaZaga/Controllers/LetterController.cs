using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZagaZaga.Models;

namespace ZagaZaga.Controllers
{
    public class LetterController : Controller
    {
        private mvcEntities db = new mvcEntities();
        //
        // GET: /Letter/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(letter_writeups lw)
        {
            if (ModelState.IsValid)
            {
                db.letter_writeups.Add(lw);
                db.SaveChanges();
                ViewBag.Message = "Submitted";

            }

            return RedirectToAction("Index", "Admin_Dashboard");
        }

    }
}
