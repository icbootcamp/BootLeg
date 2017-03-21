using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BootLeg.Models;

namespace BootLeg.Controllers
{
    public class HomeController : Controller
    {
        BootLegEntities bootlegentities = new BootLegEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Mealviews()
        {
            
            List<Meal> meal = bootlegentities.Meals.ToList();
            MealView mealview = new MealView();
            mealview.meal = meal;
            
            return View(mealview);
        }
    }
}