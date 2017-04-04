using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootLeg.Models
{
    public class SupplierModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int SuppplierTypeId { get; set; }
        public decimal CreditLimit { get; set; }
    }
}