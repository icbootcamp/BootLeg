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

        public ActionResult editStaff(int StaffId)
        {
            BootLegEntities db = new BootLegEntities();
            var sPosition = db.StaffPositions.ToList();
            var sType = db.StaffTypes.ToList();
            var currentStaff = db.People.Find(StaffId);

            var StaffToEdit = new StaffModel
            {
                StaffId = currentStaff.Staff.Id,
                FirstName = currentStaff.FirstName,
                LastName = currentStaff.LastName,
                Address1 = currentStaff.Address1,
                Address2 = currentStaff.Address2,
                PhoneNumber = currentStaff.PhoneNumber,
                MobileNumber = currentStaff.MobileNumber,
                EmailAddress = currentStaff.EmailAddress,
                HireDate = currentStaff.Staff.HireDate,
                HourlyRate = currentStaff.Staff.HourlyRate,
                sPosition = sPosition.Select(x => new SelectListItem { Text = x.Position, Value = Convert.ToString(x.Id) }).ToList(),
                sType = sType.Select(x => new SelectListItem { Text = x.Type, Value = Convert.ToString(x.Id) }).ToList()

            }; 
            return View(StaffToEdit);
        }
        public ActionResult SaveEdit(StaffModel model)
        {
            return Json(new { success = true });
        }

    }
}