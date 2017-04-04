
using BootLeg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootLeg.Controllers
{
    public class ReservationController : AbstractBootLegController
    {
        private BootLegEntities db = new BootLegEntities();
        // GET: Reservation

        public new ActionResult Index()
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
                    OpinSeats = GenSelectItemGen(2,10)};
                    
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
                model.OpinSeats = GenSelectItemGen(2,10);
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

        [HttpPost]
        public ActionResult ReservationEntied(ReservationEntryModel itemForChange)
        {
            if (itemForChange.Id == 0)
            {
                db.Reservations.Add(new Reservation
                {
                    PersonId = itemForChange.PersonId,
                    TableId = itemForChange.TableId,
                    PartySize = itemForChange.PartySize,
                    SittingTime = itemForChange.SittingTime
                });
            }
            else
            {
                var itemForUpdate = db.Reservations.Find(itemForChange.Id);
                itemForUpdate.PersonId = itemForChange.PersonId;
                itemForUpdate.TableId = itemForChange.TableId;
                itemForUpdate.PartySize = itemForChange.PartySize;
                itemForUpdate.SittingTime = itemForChange.SittingTime;
            }

            db.SaveChanges();
            return RedirectToAction("ReservationView", "Reservation");
        }
        public ActionResult ReservationRemove(int Id)
        {
            var itemToRemove = db.Reservations.Find(Id);
            db.Reservations.Remove(itemToRemove);
            db.SaveChanges();
            return RedirectToAction("ReservationView", "Reservation"); 
        }
        public ActionResult ReservationView()
        {
            return View();
        }

        public ActionResult ReservationList()
        {
            var modelLst = (from r in db.Reservations
                            join p in db.People
                                 on r.PersonId equals p.Id
                            join t in db.Tables
                                 on r.TableId equals t.Id
                            
                            select new ReservationViewModel
                            {
                                Id = r.Id,
                                PersonId = r.PersonId,
                                TableId = r.TableId,
                                SittingTime = r.SittingTime,
                                PartySize = r.PartySize,
                                PersonName = p.FirstName + " " + p.LastName,
                                TableName = t.TableName
                            }).ToList();

            return View(modelLst);
        }
        public ActionResult ReservationEntryView(int rId)
        {
            var modal = new ReservationEntryModel();


            if (rId == 0)
            {
                modal.Id = 0;
                modal.PersonId = 0;
                modal.TableId = 0;
                modal.PartySize = 1;
                modal.TableName = "";
                modal.PersonName = "";
                modal.SittingTime = System.DateTime.Now;

            }
            else
            {
                modal = db.Reservations.Where(x => x.Id == rId).Select(x => new ReservationEntryModel
                {
                    Id = x.Id,
                    PartySize = x.PartySize,
                    PersonId = x.PersonId,
                    TableId = x.TableId
                }).First();
            }
            modal.PersonList = PersonItemGen();
            modal.TableList = TableItemGen();
            modal.PartySizeList = this.GenSelectItemGen(1, 20);
            return View(modal);
        }
        public ActionResult ReservationOrderList()
        {
            var modal = db.ReservationOrders.Select(x => new ReservationOrderModel
            {
                Id = x.Id,
                ReservationId = x.ReservationId,
                OrderId = x.OrderId
            }).ToList();
            return View(modal);
        }
        public ActionResult ReservationOrderEntry(int Id)
        {
            var modal = new ReservationOrderEntryModel();
            if (Id == 0)
            {
                modal.Id = 0;
                modal.ReservationId = 0;
                modal.OrderId = 0;
            }
            else
            {
                modal = db.ReservationOrders.Where(x => x.Id == Id).Select(x => new ReservationOrderEntryModel
                {
                    Id = x.Id,
                    ReservationId = x.ReservationId,
                    OrderId = x.OrderId
                }).First();

            }
            modal.OrderList = this.OrderItemGen();
            modal.ReservationList = this.ReservationItemGen();
            return View(modal);
        }

        [HttpPost]
        public ActionResult ReservationOrderEntid(ReservationOrderEntryModel x)
        {
            if (x.Id == 0)
            {
                db.ReservationOrders.Add(new ReservationOrder
                {
                    OrderId = x.OrderId,
                    ReservationId = x.ReservationId
                });
            }
            else
            {
                var itemForUpdate = db.ReservationOrders.Find(x.Id);
                itemForUpdate.ReservationId = x.ReservationId;
                itemForUpdate.OrderId = x.OrderId;
            }
            db.SaveChanges();
            return RedirectToAction("ReservationView", "Reservation");
        }

        public ActionResult ReservationOrderRemove(int Id)
        {
            var itemForRemove = db.ReservationOrders.Find(Id);
            db.ReservationOrders.Remove(itemForRemove);
            db.SaveChanges();
            return RedirectToAction("ReservationView", "Reservation");
        }
        public List<SelectListItem> PersonItemGen()
        {
            return db.People.Select(x => new SelectListItem {
                Text = x.Id + ": " + x.FirstName + " " + x.LastName,
                Value = "" + x.Id
                }).ToList();
        }
        public List<SelectListItem> TableItemGen()
        {
            return db.Tables.Select(x => new SelectListItem
            {
                Text = x.Id + ": " + x.TableName,
                Value = "" + x.Id
            }).ToList();
        }
        public List<SelectListItem> OrderItemGen()
        {
            return db.Orders.Select(x => new SelectListItem
            {
                Text = "" + x.Id,
                Value = "" + x.Id
            }).ToList();
        }
        public List<SelectListItem> ReservationItemGen()
        {
            return db.Reservations.Select(x => new SelectListItem
            {
                Text = "Reservation No.:" + x.Id + "," + x.Person.Id + " :" + x.Person.LastName + " @:" + x.SittingTime,
                Value = "" + x.Id
            }).ToList();
        }
        public List<SelectListItem> GenSelectItemGen(int minLength, int maxLength)
        {
            List<SelectListItem> rstList = new List<SelectListItem>();

            for (int i = minLength; i <= maxLength; i++)
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