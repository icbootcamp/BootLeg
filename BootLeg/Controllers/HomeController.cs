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

       public ActionResult StaffManagement ()
        {
            BootLegEntities db = new BootLegEntities();

            //var staffList = db.Staffs.Select(x => new StaffModel
            //{
            //    Id = x.Id,
            //    HourlyRate = x.HourlyRate,
            //    HireDate = x.HireDate
            //}).ToList();


            //var staffList = db.People.Select(x => new PersonModel
            //{
            //    Id = x.Id,
            //    FirstName = x.FirstName,
            //    LastName= x.LastName
            //}).ToList();

            var staffList = (from x in db.People
                             join y in db.Staffs
                             on x.Id equals y.Id

                             join a in db.StaffPositions
                             on x.Id  equals a.Id

                             join b in db.StaffTypes
                             on x.Id equals b.Id
                    
                             select new StaffModel
                             {
                                 Id = x.Id,
                                 FirstName = x.FirstName,
                                 HireDate = y.HireDate,
                                 HourlyRate = y.HourlyRate,
                                 Position = a.Position,
                                 Type = b.Type
                             }).ToList();

            return View(staffList);
        }
    }
}