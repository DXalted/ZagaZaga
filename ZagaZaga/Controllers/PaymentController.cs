using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZagaZaga.Models;

namespace ZagaZaga.Controllers
{
    public class PaymentController : Controller
    {
        private mvcEntities db = new mvcEntities();
        //
        // GET: /Payment/

        public ActionResult Index()
        {
            var payment = db.trans_pay.Where(x => x.id != 000);
            ViewBag.trans = payment.ToList();
            return View(payment.ToList());
        }

    }
}
