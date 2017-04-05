using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BootLeg.Models;


namespace BootLeg.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier

        BootLegEntities db = new BootLegEntities();

        public ActionResult SupplierName()

        {
            var supplierName = (from p in db.People
                                join s in db.Suppliers
                               on p.Id equals s.Id
                                join so in db.SupplierOrders
                                on s.Id equals so.SupplierId
                                join sod in db.SupplierOrderDetails
                                on so.Id equals sod.SupplierOrderID
                                join pr in db.Products
                                on sod.ProductId equals pr.Id

                                select new SupplierModel

                                {
                                    FirstName = p.FirstName,
                                    LastName = p.LastName,
                                    Address1 = p.Address1,
                                    Address2 = p.Address2,
                                    PhoneNumber = p.PhoneNumber,
                                    MobileNumber = p.MobileNumber,
                                    EmailAddress = p.EmailAddress,
                                    CompanyName = s.CompanyName,
                                    CreditLimit = s.CreditLimit

                                }).ToList();

            return View(supplierName);
        }

        public ActionResult EditSupplier(int personId)

        {
            var supplierEdit = db.People.Find(personId);
            var supplier = db.Suppliers.ToList();
            SupplierModel model = new SupplierModel
            {
                Id = supplierEdit.Id,
                CompanyName = supplierEdit.Supplier.CompanyName,
                FirstName = supplierEdit.FirstName,
                LastName = supplierEdit.LastName,
                Address1 = supplierEdit.Address1,
                Address2 = supplierEdit.Address2,
                PhoneNumber = supplierEdit.PhoneNumber,
                MobileNumber = supplierEdit.MobileNumber,
                EmailAddress = supplierEdit.EmailAddress,
                CreditLimit = supplierEdit.Supplier.CreditLimit,


            };   

            return View(model);
        } 
        
        public ActionResult SaveEdit (SupplierModel model)
        {
            return Json(new { success = true});
        }

        private class BootLegEntities
        {
            public BootLegEntities()
            {
            }

            public object People { get; internal set; }
        }
    }



        }            


        




    
