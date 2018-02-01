using System;
using System.Collections.Generic;
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
            return View(p_chk.ToList());
        }

        public ActionResult company_chk()
        {
            var c_chk = db.company_chk.Where(x => x.id != 000);
            ViewBag.cc = c_chk.ToList();
            return View(c_chk.ToList());
        }

    }
}
