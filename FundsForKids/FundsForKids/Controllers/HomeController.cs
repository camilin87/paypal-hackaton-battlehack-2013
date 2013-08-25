using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FundsForKids.Helpers;
using Ninject;

namespace FundsForKids.Controllers
{
    public class HomeController : Controller
    {

        [Inject]
        public IEventsManager EventsManager { get; set; }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            var model = EventsManager.Events();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
