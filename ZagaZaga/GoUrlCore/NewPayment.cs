using System;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web.Helpers;
using ZagaZaga.Models;
using ZagaZaga.Models.GoUrl;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


//* ########################################## 	

//* ###  PLEASE MODIFY THIS FILE !  ###

//* ##########################################

namespace ZagaZaga.GoUrlCore
{
    public static class NewPayment
    {
        public static void Main(int paymentId, IPNModel callback, string box_status)
        {
            //PLACE YOUR CODE HERE

            //Mail(paymentId, callback, box_status);

            //PLACE YOUR CODE HERE

            //Mail(paymentId, callback, box_status);

            if (box_status == "cryptobox_newrecord" || box_status == "cryptobox_newrecord")
            {
                mvcEntities db = new mvcEntities();
                transaction trans = new transaction();
                trans.u_id = callback.user;
                trans.amount = callback.amountusd.ToString();
                trans.desc = "Test Desciption";
                trans.type = "Add";
                db.transaction.Add(trans);
                db.SaveChanges();


                amount am = new amount();
                db = new mvcEntities();
                var amount = db.amount.Where(x => x.u_id == callback.user).FirstOrDefault();

                if (amount != null)
                {
                    amount.amount1 = (Convert.ToDecimal(amount.amount1) + Convert.ToDecimal(callback.amountusd.ToString())).ToString();
                    db.Entry(amount).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    amount amount1 = new amount();
                    amount1.u_id = callback.user;
                    amount1.amount1 = callback.amountusd.ToString();
                    db.amount.Add(amount1);
                }

                var amount2 = db.amount.Where(x => x.u_id == callback.user).FirstOrDefault();
                if (amount2 != null)
                {
                    HttpContext.Current.Session["user_amount"] = amount2.amount1;
                }
            }
        }

        private static void Mail(int paymentId, IPNModel callback, string box_status)
        {
            const string host = "";
            const string fromEmail = "";
            const string fromPassword = "";
            const string toEmail = "";

            if (host == "" || fromEmail == "" || fromPassword == "" || toEmail == "")
            {
                throw new ArgumentException("Please initialise smtp server for email.");
            }

            var fromAddress = new MailAddress(fromEmail, "From Test Payment Server");
            var toAddress = new MailAddress(toEmail, "To You");
            if (callback.err == null)
                callback.err = "";
            string details = Json.Encode(callback);
            Regex reg = new Regex(@"\\/Date\(\d+\)\\/");
            details = reg.Replace(details, callback.date.ToString("dd MMMM yyyy"), 1);
            details = reg.Replace(details, callback.datetime.ToString("yyyy-MM-dd HH:mm:ss"));
            const string subject = "Subject";
            string body = "Payment - " + paymentId + " - " + box_status + "\nDetails:\n" + details;

            var smtp = new SmtpClient
            {
                Host = host,
                Port = 25,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 10000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}