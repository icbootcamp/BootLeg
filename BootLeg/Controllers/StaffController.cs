using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BootLeg.Models;

namespace BootLeg.Controllers
{
    public class StaffController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StaffManagement()
        {
            BootLegEntities db = new BootLegEntities();

            var staffList = (from x in db.People
                             join y in db.Staffs
                             on x.Id equals y.Id

                             join a in db.StaffPositions
                             on y.Id equals a.StaffId

                             join b in db.StaffTypes
                             on a.StaffTypeId equals b.Id

                             select new StaffModel
                             {
                                 StaffId = a.StaffId,
                                 FirstName = x.FirstName,
                                 HireDate = y.HireDate,
                                 HourlyRate = y.HourlyRate,
                                 Position = a.Position,
                                 Type = b.Type

                             }).ToList();

            return View(staffList);
        }

        public ActionResult editStaff(int staffId)
        {
            BootLegEntities db = new BootLegEntities();

            var StaffToEdit = (from x in db.People
                               join y in db.Staffs
                               on x.Id equals y.Id

                               join a in db.StaffPositions
                               on y.Id equals a.StaffId

                               join b in db.StaffTypes
                               on a.StaffTypeId equals b.Id
                               where x.Id == staffId

                               select new StaffModel
                               {
                StaffId = y.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address1 = x.Address1,
                Address2 = x.Address2,
                PhoneNumber = x.PhoneNumber,
                MobileNumber = x.MobileNumber,
                EmailAddress = x.EmailAddress,
                HourlyRate = y.HourlyRate,
                HireDate = y.HireDate,
                Position = a.Position,
                Type = b.Type
            }).ToList();

            return View();
        }
    }
}