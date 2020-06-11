using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceEmpire4XTracker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Economy()
        {
            ViewBag.Message = "Economy for the round";

            return View();
        }

        public ActionResult Admin()
        {
            ViewBag.Message = "Create and Maintain the data";

            return View();
        }
    }
}