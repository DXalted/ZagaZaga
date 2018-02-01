using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZagaZaga.Models;

namespace ZagaZaga.Controllers
{
    public class FormatController : Controller
    {
        private mvcEntities db = new mvcEntities();
        //
        // GET: /Format/

        public ActionResult Index()
        {
            var format = db.leads.Where(x => x.id != 000);
            ViewBag.lead = format.ToList();
            return View(format.ToList());
        }

    }
}
