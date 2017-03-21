using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootLeg.Models
{
    public class SupplierClass1
    {
        public List<Supplier> Suppliers { get; set; }
        public List<SupplierOrder> SupplierOrders { get; set; }
        public List<Product> Product { get; set; }
        public List<SupplierType> SupplierType { get; set; }

    }
}