using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace BootLeg.Models
{
  

    public class PersonModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Address 1")]
        public int Address1 { get; set; }
        [Display(Name = "Address 2")]
        public int Address2 { get; set; }
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }
        [Display(Name = "Mobile Number")]
        public int MobileNumber { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
    }

    public class StaffModel : PersonModel
    {
        [Display(Name = "Hourly Rate")]
        public decimal HourlyRate { get; set; }
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }
        [Display(Name = "Position")]
        public string Position { get; set; }
        [Display(Name = "Staff Type")]
        public string Type { get; set; }

    }

  
}