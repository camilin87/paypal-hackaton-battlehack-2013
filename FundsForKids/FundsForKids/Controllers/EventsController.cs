using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using FundsForKids.Helpers;
using FundsForKids.Models;
using Ninject;

namespace FundsForKids.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        [Inject]
        public IPaymentsManager PaymentsManager { get; set; }

        [Inject]
        public IEventsManager EventsManager { get; set; }

        //
        // GET: /Events/
        [AllowAnonymous]
        public ActionResult Event(int eventId)
        {
            return View(new EventModel(){Event = EventsManager.Event(eventId), AvailableDenoms = EventsManager.Denominations(eventId)});
        }

        [AllowAnonymous]
        public void Fund(EventModel model, int amount)
        {
            //string senderEmail = "user2@abdolphin.com";

            string receiverEmail = EventsManager.Coordinator(User.Identity.Name).PaypalEmail;  //"user1@abdolphin.com"; //Get email for receiver
            var redirectUrl = PaymentsManager.Pay(model.PaypalEmail, receiverEmail, Convert.ToDecimal(amount), String.Format("http://localhost:8098/Events/Thankyou?cEvent={0}&amount={1}&email={2}", model.Event.EventId, amount, model.PaypalEmail),
                                "http://localhost:8098/Events/CancelPayment");


            //Session["CurrentEmail"] = senderEmail;
            //Session["CurrentAmount"] = amount;
            //Session["CurrentEvent"] = eventId;

            Response.Redirect(redirectUrl);
        }

        [AllowAnonymous]
        public ActionResult Thankyou(int cEvent, int amount, string email)
        {
            //Add donation record to our database

            EventsManager.RecordDonation(cEvent, amount, email);
            return View();
        }

        [AllowAnonymous]
        public ActionResult CancelPayment()
        {
            return View();
        }

        #region Admin

        public ActionResult CreateEvent()
        {
            var model = new EventModel() {AvailableDenoms = EventsManager.Denominations(), Event = new Event()};
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateEvent(EventModel model)
        {
            EventsManager.SaveEvent(model.Event, User.Identity.Name, new List<int>(){model.Denomination1, model.Denomination2, model.Denomination3});
            return View("GenerateQr", model.Event.EventId);
        }

        public ActionResult GenerateQr(int eventId)
        {
            ViewBag.EventId = eventId;
            return View();
        }

        public ActionResult EditEvent(int eventId)
        {
            return View(new Event());
        }

        public ActionResult EventDetails(int eventId)
        {
            return View(new Event());
        }

        #endregion Admin

    }
}
