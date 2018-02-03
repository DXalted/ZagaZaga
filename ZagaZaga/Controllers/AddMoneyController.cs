using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZagaZaga.GoUrlCore;
using ZagaZaga.Models;
using ZagaZaga.Models.GoUrl;

namespace ZagaZaga.Controllers
{
    public class AddMoneyController : Controller
    {
        //
        // GET: /AddMoney/

        public ActionResult Index()
        {
            ViewBag.Message = "";
            //ViewBag.Message = "";
            return View();


        }

        [HttpPost]
        public ActionResult Index(string block_btc)
        {
            if (Session["user_id"] == null)
            {
                return RedirectToAction("Index", "User_Login");
            }
            if (block_btc != "" || block_btc != null)
            {
                decimal btcVal = 0;
                try { btcVal = Convert.ToDecimal(block_btc); } catch { btcVal = 0; }

                OptionsModel options = new OptionsModel()
                {
                    public_key = "22510AAvn8jcBitcoin77BTCPUBkB5D8USTCmH9BRJ4P9HZbSe",
                    private_key = "22510AAvn8jcBitcoin77BTCPRVUUx70UN62wTaUBvlZeUKraD",
                    webdev_key = "",
                    orderID = "invoice000383",
                    userID = Session["user_id"].ToString(),
                    userFormat = "COOKIE",
                    amount = 0,
                    amountUSD = btcVal,
                    period = "24 HOUR",
                    iframeID = "",
                    language = "EN"
                };
                using (Cryptobox cryptobox = new Cryptobox(options))
                {
                    DisplayCryptoboxModel model = cryptobox.GetDisplayCryptoboxModel();
                    // A. Process Received Payment
                    if (cryptobox.is_paid())
                    {
                        ViewBag.Message = "A. User will see this message during 24 hours after payment has been made!" +
                                          "<br/>" + cryptobox.amount_paid() + " " + cryptobox.coin_label() +
                                          "  received<br/>";
                        // Your code here to handle a successful cryptocoin payment/captcha verification
                        // For example, give user 24 hour access to your member pages

                        // B. One-time Process Received Payment
                        if (!cryptobox.is_processed())
                        {
                            ViewBag.Message += "B. User will see this message one time after payment has been made!";
                            // Your code here - for example, publish order number for user
                            // ...

                            // Also you can use is_confirmed() - return true if payment confirmed 
                            // Average transaction confirmation time - 10-20min for 6 confirmations  

                            // Set Payment Status to Processed
                            cryptobox.set_status_processed();

                            // Optional, cryptobox_reset() will delete cookies/sessions with userID and 
                            // new cryptobox with new payment amount will be show after page reload.
                            // Cryptobox will recognize user as a new one with new generated userID
                            // cryptobox_reset(); 
                        }
                    }
                    ViewBag.Message = "The payment has not been made yet";

                    return View(model);
                }
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult PerfectMoney(string block_pm)
        {
            if (Session["user_id"] == null)
            {
                return RedirectToAction("Index", "User_Login");
            }
            if (block_pm != "" || block_pm != null)
            {
                decimal pmVal = 0;
                try { pmVal = Convert.ToDecimal(block_pm); } catch { pmVal = 0; }

                PerfectMoney PM = new PerfectMoney();
                Dictionary<string, string> returnVal = PM.Transfer("3618934", "bRuce1000", "U15490977", "U15490977", 10, 3, 20200);

                return View();
            }
            else
            {
                return View();
            }
        }
    }
}
