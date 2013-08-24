using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Funds4Kids.Helpers;
using Ninject;

namespace Funds4Kids.Controllers
{
    public class EventsController : Controller
    {
        [Inject]
        public IPaymentsManager PaymentsManager { get; set; }

        //
        // GET: /Events/

        public ActionResult Event()
        {
            //Get event info from database

            return View();
        }

        [HttpPost]
        public void Fund(int eventId, int amount, string senderEmail)
        {
            string receiverEmail = "user1@abdolphin.com"; //Get email for receiver
            var redirectUrl = PaymentsManager.Pay(senderEmail, receiverEmail, Convert.ToDecimal(amount), "http://localhost/Events/Thankyou",
                                "http://localhost/Events/CancelPayment");

            Session["CurrentEmail"] = senderEmail;
            Session["CurrentAmount"] = amount;

            Response.Redirect(redirectUrl);
        }

        public ActionResult Thankyou()
        {
            //Add donation record to our database

            return View();
        }

        public ActionResult CancelPayment()
        {
            return View();
        }

    }
}
