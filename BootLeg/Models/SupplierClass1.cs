using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootLeg.Models
{
    public class SupplierClass1
    {
        public List<Supplier> Supplier { get; set; }
        public List<SupplierOrder> SupplierOrders { get; set; }
        public List<Product> Product { get; set; }
        public List<SupplierType> SupplierType { get; set; }
        public List<Person> Person { get; set; }
        public Supplier SelectedSupplier { get; set; }
        public string displayResult { get; set; }
    }
}