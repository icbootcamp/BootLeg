
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
    }
}