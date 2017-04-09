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

        public ActionResult newStaff()
        {
            BootLegEntities db = new BootLegEntities();
           
            Staff x = new Staff();
            db.Staffs.Add(x);
            return View();
        }

        [HttpPost]
        public ActionResult newStaff(StaffModel dp)
        {
            BootLegEntities db = new BootLegEntities();
            db.People.Add(new Person
            {
                FirstName = dp.FirstName,
                LastName = dp.LastName,
                Address1 = dp.Address1,
                Address2 = dp.Address2,
                PhoneNumber = dp.PhoneNumber,
                MobileNumber = dp.MobileNumber,
                EmailAddress = dp.EmailAddress
            });
            db.Staffs.Add(new Staff
            {
                HireDate = dp.HireDate,
                HourlyRate = dp.HourlyRate,
                StaffPositionId = dp.StaffPositionId,                   
            });
            
            db.SaveChanges();
            return RedirectToAction("StaffManagement");
        }


        public ActionResult StaffManagement()
        {
            BootLegEntities db = new BootLegEntities();

            var staffList = (from x in db.People
                             join y in db.Staffs
                             on x.Id equals y.Id

                             join a in db.StaffPositions
                             on y.StaffPositionId equals a.Id

                             join b in db.StaffTypes
                             on a.StaffTypeId equals b.Id

                             select new StaffModel
                             {
                                 StaffId = y.Id,
                                 FirstName = x.FirstName,
                                 HireDate = y.HireDate,
                                 HourlyRate = y.HourlyRate,
                                 Position = a.Position,
                                 Type = b.Type

                             }).ToList();

            return View(staffList);
        }

        public ActionResult editStaff(int StaffId)
        {
            BootLegEntities db = new BootLegEntities();
           
            var currentStaff = db.People.Find(StaffId);
            var currentStaff1 = (from x in db.People
                                 join y in db.Staffs
                                 on x.Id equals y.Id
                                 join a in db.StaffPositions
                                 on y.StaffPositionId equals a.Id

                                 join b in db.StaffTypes
                                 on a.StaffTypeId equals b.Id

                                 where x.Id == StaffId
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
                                     HireDate = y.HireDate,
                                     StaffTypeId = b.Id,
                                     StaffPositionId = a.Id,
                                     HourlyRate = y.HourlyRate,
                                     sPosition = db.StaffPositions.Select(x => new SelectListItem { Text = x.Position, Value = ""+x.Id }).ToList(),
                                     sType = db.StaffTypes.Select(x => new SelectListItem { Text = x.Type, Value = ""+x.Id }).ToList()

                                 }).First();
            
                 return View(currentStaff1);
        }

        [HttpPost]
        public ActionResult SaveEdit(StaffModel currentStaff1)
        {
            BootLegEntities db = new BootLegEntities();
            var newStaff = db.People.Find(currentStaff1.StaffId);
            var newStaff1 = db.Staffs.Find(currentStaff1.StaffId);
            var newStaff2 = db.StaffPositions.Find(currentStaff1.StaffId);
            newStaff.FirstName = currentStaff1.FirstName;
            newStaff.LastName = currentStaff1.LastName;
            newStaff.Address1 = currentStaff1.Address1;
            newStaff.Address2 = currentStaff1.Address2;
            newStaff.PhoneNumber = currentStaff1.PhoneNumber;
            newStaff.MobileNumber = currentStaff1.MobileNumber;
            newStaff.EmailAddress = currentStaff1.EmailAddress;
            newStaff1.HireDate = currentStaff1.HireDate;
            newStaff1.HourlyRate = currentStaff1.HourlyRate;
            newStaff1.StaffPositionId = currentStaff1.StaffPositionId;
            newStaff2.StaffTypeId = currentStaff1.StaffTypeId;
            db.SaveChanges();
            return RedirectToAction("StaffManagement");
        }

    }
}