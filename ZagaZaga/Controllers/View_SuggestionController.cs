using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZagaZaga.Models;

namespace ZagaZaga.Controllers
{
    public class View_SuggestionController : Controller
    {
        private mvcEntities db = new mvcEntities();
        //
        // GET: /View_Suggestion/

        public ActionResult Index()
        {
            var view_sugg = db.suggest.Where(x => x.id != 000);
            ViewBag.sugg = view_sugg.ToList();
            return View(view_sugg.ToList());
        }

    }
}
