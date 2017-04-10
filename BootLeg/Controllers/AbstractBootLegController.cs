using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootLeg.Controllers
{
    public class AbstractBootLegController : Controller
    {
        // GET: AbstractBootLeg
        public ActionResult Index()
        {
            return View();
        }
        //to be implement for search
        public ActionResult Search()
        {

            return View();
        }
    }
}