using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZagaZaga.Models;

namespace ZagaZaga.Controllers
{
    public class Bnk_TController : Controller
    {
        private mvcEntities db = new mvcEntities();
        //
        // GET: /Bnk_T/

        public ActionResult Index()
        {
            
            return View();
        }

    }
}
