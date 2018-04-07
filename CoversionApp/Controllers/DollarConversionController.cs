using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoversionApp.Controllers
{
    public class DollarConversionController : Controller
    {
        // GET: DollarConversion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Convert()
        {
            return View("~/Views/DollarConversion/Convert.cshtml");
        }
    }
}