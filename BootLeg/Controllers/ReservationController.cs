
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
            DinningTableModel model;
            if (Idd == 0)
            {
                model = new DinningTableModel(0, "", 2, "");
                
            }
            else
            {
                model = db.Tables.Where(x => x.Id == Idd).Select(x => 
                            new DinningTableModel {
                                Id = x.Id,
                                Seats = x.Seats,
                                TableName = x.TableName,
                                Description = x.Description
                            }).First();
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult TableEntied(string x)
        {
            var sArray = x.Split('&');
            Dictionary<string, string> htmlFromModal = new Dictionary<string, string>();
            foreach (string str in sArray)
            {
                var st = str.Split('=');
                htmlFromModal.Add(st[0], st[1]);
            }
            if (Convert.ToInt16(htmlFromModal["Id"]) == 0)
            {

                db.Tables.Add(
                    new Table
                    {
                        TableName = htmlFromModal["PopModal-p1-input"],
                        Seats = Convert.ToInt16(htmlFromModal["PopModal-p2-input"]),
                        Description = htmlFromModal["PopModal-p3-input"]
                    });
            }
            else
            {
                var updatingData = db.Tables.Find(Convert.ToInt16(htmlFromModal["Id"]));
                updatingData.TableName = htmlFromModal["PopModal-p1-input"].Trim();
                updatingData.Seats = Convert.ToInt16(htmlFromModal["PopModal-p2-input"]);
                updatingData.Description = htmlFromModal["PopModal-p3-input"].Trim();
            }


            db.SaveChanges();
            return RedirectToAction("TableView", "Reservation");
        }

    }
}