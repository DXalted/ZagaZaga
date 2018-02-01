using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ZagaZaga.Controllers
{
    public class LogoutController : Controller
    {
        //
        // GET: /Logout/

        public ActionResult logout()
        {
            Session.Clear();
            if (Session["user_id"] != null)
            {
                return RedirectToAction("Index", "User_Login");
            }
            
            
            return View();
        }

    }
}
