
using BootLeg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootLeg.Controllers
{
    public class ReservationController : Controller
    {
        private BootLegEntities db = new BootLegEntities();
        // GET: Reservation
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TableView()
        {
            return View();
        }

        // GET: Reservation
        public ActionResult TableList()
        {
            var tableList = db.Tables.Select(
                x => new DinningTableModel
                {
                    Id = x.Id,
                    TableName = x.TableName,
                    Seats = x.Seats,
                    Description = x.Description
                })
                .ToList();


            return View(tableList);
        }
        public ActionResult TableRemove(int Id)
        {
            Console.WriteLine("{0} has been delete from database", Id);
            var rmTable = db.Tables.Find(Id);
            db.Tables.Remove(rmTable);
            db.SaveChanges();

            return RedirectToAction("TableView", "Reservation");
        }
        public ActionResult TableEntry(int Idd)
        {
            if (Idd == 0)
            {
                var model = new DinningTableModel(0,"",2,"");
                return Json(model, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
    }
}