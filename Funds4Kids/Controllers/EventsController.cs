using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Funds4Kids.Helpers;

namespace Funds4Kids.Controllers
{
    public class EventsController : Controller
    {
        public IPaymentsManager PaymentsManager { get; set; }

        //
        // GET: /Events/

        public ActionResult Event()
        {
            //Get event info from database

            return View();
        }

        public ActionResult Fund()
        {
            var response = PaymentsManager.Pay("sender", "receiver", 1m, "http://localhost/Events/Thankyou",
                                "http://localhost/Events/CancelPayment");
            return View();
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
