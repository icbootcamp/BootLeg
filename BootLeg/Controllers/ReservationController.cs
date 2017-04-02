
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
                x => new TableModel
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
        public ActionResult TableEntryView(int Idd)
        {
            TableEntryModel model;
            if (Idd == 0)
            {
                model = new TableEntryModel
                {
                    Id = 0,
                    TableName = "",
                    Seats = 2,
                    Description = "",
                    OpinSeats = SeatsItemGen(10)};
                    
            }
            else
            {
                model = db.Tables.Where(x => x.Id == Idd).Select(x => 
                                new TableEntryModel
                                {
                                    Id = x.Id,
                                    Seats = x.Seats,
                                    TableName = x.TableName,
                                    Description = x.Description,
                                
                                }
                ).First();;
                model.OpinSeats = SeatsItemGen(10);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult TableEntied(TableEntryModel x)
        {
            
            if (x.Id == 0)
            {

                db.Tables.Add(
                    new Table
                    {
                        TableName = x.TableName.Trim(),
                        Seats = x.Seats,
                        Description = x.Description
                    });
            }
            else
            {
                var updatingData = db.Tables.Find(x.Id);

                updatingData.TableName = x.TableName.Trim();
                updatingData.Seats = x.Seats;
                updatingData.Description = x.Description.Trim();
            }


            db.SaveChanges();
            return RedirectToAction("TableView", "Reservation");
        }
        public List<SelectListItem> SeatsItemGen(int maxSeatLength)
        {
            List<SelectListItem> rstList = new List<SelectListItem>();
            for (int i = 2; i <= maxSeatLength; i++)
            {
                SelectListItem x = new SelectListItem();
                x.Text = Convert.ToString(i);
                x.Value = Convert.ToString(i);
                rstList.Add(x);
            }
            return rstList;
        }
    }
}