using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BootLeg.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier

        BootLegEntities db = new BootLegEntities();

        public ActionResult SupplierName()
            
        {
            var supplierName = db.Suppliers.ToList();


            return View(supplierName.ToList());
        }





    }
}