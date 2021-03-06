﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZagaZaga.Models;

namespace ZagaZaga.Controllers
{
    public class SupportController : Controller
    {
        private mvcEntities db = new mvcEntities();
        //
        // GET: /Support/

        public ActionResult Index()
        {
            if (Session["user_id"] != null)
            {
                return RedirectToAction("Index", "Support");
            }
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(user u)
        {
            var userdetails = db.user.Where(x => x.email == u.email && x.userpass == u.userpass).FirstOrDefault();
            if (userdetails != null)
            {


                Session["user_id"] = userdetails.id;
                Session["user_name"] = userdetails.email;


                ViewBag.Message = "Login Successfully";
                return RedirectToAction("Index", "Support");


            }
            else
            {
                ViewBag.Message = "Wrong Username Or Password";
                return RedirectToAction("Index", "Support");
            }
            return View(u);
        }


        public ActionResult Support_Dashboard()
        {
            string user_name = Session["user_name"].ToString();
            var all_ticket = db.ticket.Where(x => x.u_name == user_name);
            ViewBag.ticket = all_ticket.ToList();
            return View();

        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Support_Dashboard(ticket t)
        {
            if (ModelState.IsValid)
            {
                db.ticket.Add(t);
                db.SaveChanges();
                ViewBag.Message = "Registered Successfully";

            }

            return RedirectToAction("Support_Dashboard", "Support");



        }

        public ActionResult Ticket(int id)
        {
            var all_ticket = db.ticket.Where(x => x.id == id).FirstOrDefault();
            ViewBag.TicketTitle = all_ticket.title;
            ViewBag.TicketDesc = all_ticket.desc;
            ViewBag.TicketID = all_ticket.id;

            //if (ModelState.IsValid)
            //{
            //    db.ticket.Add(t);
            //    db.SaveChanges();
            //    ViewBag.Message = "Registered Successfully";

            //}

            //return RedirectToAction("Support_Dashboard", "Support");


            return View(db.chat.Where(x=> x.TicketID == id).ToList());



        
        }


        [HttpPost]
        public ActionResult Ticket(int ticketID, string messageBox)
        {
            int UserID = Convert.ToInt32(Session["user_id"]);
            chat c = new chat();
            c.AdminID = 9999;
            c.UserID = UserID;
            c.TicketID = ticketID;
            c.MessageBody = messageBox;
            c.SentDate = DateTime.Now.ToString();
            c.SentBy = "U";
            db.chat.Add(c);
            db.SaveChanges();

            var all_ticket = db.ticket.Where(x => x.id == ticketID).FirstOrDefault();
            ViewBag.TicketTitle = all_ticket.title;
            ViewBag.TicketDesc = all_ticket.desc;
            ViewBag.TicketID = all_ticket.id;

            return View(db.chat.Where(x => x.TicketID == ticketID).ToList());

        }

        public ActionResult Resolve_Ticket()
        {
            string user_name = Session["user_name"].ToString();
            var res_ticket = db.ticket.Where(x => x.type == "resolve" && x.u_name == user_name);
            ViewBag.res_tic = res_ticket.ToList();
            return View();

        }
        [HttpGet]
        public ActionResult Open_Ticket()
        {
            string user_name = Session["user_name"].ToString();
            var open_ticket = db.ticket.Where(x => x.type == "open" && x.u_name == user_name);
            ViewBag.op_tic = open_ticket.ToList();
            return View();

        }

    }
}
