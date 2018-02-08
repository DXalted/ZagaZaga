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
        public ActionResult Ticket(int id)
        {
            var all_ticket = db.ticket.Where(x => x.id == id).FirstOrDefault();
            ViewBag.TicketTitle = all_ticket.title;
            ViewBag.TicketDesc = all_ticket.desc;
            ViewBag.TicketID = all_ticket.id;

            return View(db.chat.Where(x => x.TicketID == id).ToList());

        }
        [HttpPost]
        public ActionResult Ticket(int ticketID, string messageBox)
        {
            var User = db.chat.Where(x => x.TicketID == ticketID).FirstOrDefault();
            
            chat c = new chat();
            c.AdminID = 9999;
            c.UserID = User.UserID;
            c.TicketID = ticketID;
            c.MessageBody = messageBox;
            c.SentBy = "A";
            c.SentDate = DateTime.Now.ToString();

            db.chat.Add(c);
            db.SaveChanges();

            var all_ticket = db.ticket.Where(x => x.id == ticketID).FirstOrDefault();
            ViewBag.TicketTitle = all_ticket.title;
            ViewBag.TicketDesc = all_ticket.desc;
            ViewBag.TicketID = all_ticket.id;

            return View(db.chat.Where(x => x.TicketID == ticketID).ToList());

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
