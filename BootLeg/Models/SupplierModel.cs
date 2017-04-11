using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BootLeg.Models
{
    public class SupplierModel 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }

        public List<Supplier> supplier { get; set; }
        public string CompanyName { get; internal set; }
        public decimal CreditLimit { get; internal set; }
    }
}