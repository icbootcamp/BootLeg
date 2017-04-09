using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootLeg.Models
{
    public class ReservationOrderModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Reservation Id")]
        public int ReservationId { get; set; }
        [Display(Name = "Order Id")]
        public int OrderId { get; set; }
    }
    public class ReservationOrderEntryModel : ReservationOrderModel
    {
        [Display(Name = "Reservation List")]
        public List<SelectListItem> ReservationList { get; set; }
        [Display(Name = "Order List")]
        public List<SelectListItem> OrderList { get; set; }
    }
}