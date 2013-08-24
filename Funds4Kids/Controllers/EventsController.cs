using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Funds4Kids.Helpers;
using Funds4Kids.Models;
using Ninject;

namespace Funds4Kids.Controllers
{
    public class EventsController : Controller
    {
        [Inject]
        public IPaymentsManager PaymentsManager { get; set; }

        [Inject]
        public IEventsManager EventsManager { get; set; }

        //
        // GET: /Events/

        public ActionResult Event(int eventId)
        {
            var currentEvent = EventsManager.GetEvent(eventId);
            return View(currentEvent);
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

        #region Admin

        public ActionResult CreateEvent()
        {
            return View(new EventInfo());
        }

        [HttpPost]
        public ActionResult CreateEvent(EventInfo model)
        {
            return View("EventDetails", model);
        }

        public ActionResult EditEvent(int eventId)
        {
            return View(new EventInfo());
        }

        public ActionResult EventDetails(int eventId)
        {
            return View(new EventInfo());
        }

        #endregion Admin

    }
}
