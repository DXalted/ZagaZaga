using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZagaZaga.Models;

namespace ZagaZaga.Controllers
{
    public class TicketsController : Controller
    {
        private mvcEntities db = new mvcEntities();
        //
        // GET: /Tickets/

        public ActionResult Index()
        {

            var ticket = db.ticket.Where(x => x.id != 000 );
            ViewBag.tick = ticket.ToList();
            return View(ticket.ToList());

        }


        public ActionResult Data_Update(int id)
        {

            var ticket = db.ticket.Where(x => x.id == id).FirstOrDefault();
            if (ticket != null)
            {

                if (ticket.type != "resolved" || ticket.type != "RESOLVED")
                {
                    ticket.type = "Resolved";
                    ticket.date = DateTime.Now.ToString();
                    db.Entry(ticket).State = EntityState.Modified;
                    //db.user.Add(userdetails);
                    db.SaveChanges();




                    ViewBag.Message = "Resolved";
                }
                else
                {
                    ViewBag.Message = "Already Resolved";
                }

                
            }
            return RedirectToAction("Index", "Tickets");

        }


    }
}
