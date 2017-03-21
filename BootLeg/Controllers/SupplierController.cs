using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootLeg.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        
        public ActionResult SupplierName()
            
        {
            BootLegEntities db = new BootLegEntities();

            var supplierName = db.SupplierTypes.ToList();

            return View(supplierName);
        }

        public ActionResult NewSupplier()
        {
            return View();
        }

    }
}