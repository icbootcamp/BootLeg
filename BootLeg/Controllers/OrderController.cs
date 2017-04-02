using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BootLeg.Models;

namespace BootLeg.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            BootLegEntities bootLegEntities = new BootLegEntities();
            OrderViewModel orderViewModel = new OrderViewModel();
            orderViewModel.order = bootLegEntities.Orders.ToList();
            return View(orderViewModel);
        }

        [HttpGet]
        public ActionResult AddOrder()
        {
            Order order = new Order();
            return View(order);
        }
        [HttpPost]
        public ActionResult AddOrder(Order order)
        {
            BootLegEntities bootLegEntities = new BootLegEntities();
            bootLegEntities.Orders.Add(order);
            bootLegEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditOrder(int Id)
        {
            BootLegEntities bootLegEntities = new BootLegEntities();
            Order order = bootLegEntities.Orders.Single(x => x.Id == Id);
            return View(order);
            
        }
       [HttpPost]
        public ActionResult EditOrder(Order order)
        {
            BootLegEntities bootLegEntities = new BootLegEntities();
            Order order1 = bootLegEntities.Orders.SingleOrDefault(x => x.Id == order.Id);

            order1.Id = order.Id;
            order1.OrderTypeId = order.OrderTypeId;
            bootLegEntities.SaveChanges();
            return RedirectToAction("Index");

        }
      
    }
}