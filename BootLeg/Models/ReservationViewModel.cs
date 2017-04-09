using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BootLeg.Models
{
    public class ReservationViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Person")]
        public int PersonId { get; set; }
        [Display(Name = "Tabel")]
        public int TableId { get; set; }
        [Display(Name = "Sitting Time")]
        public DateTime SittingTime { get; set; }
        [Display(Name = "Party Size")]
        public int PartySize { get; set; }
        [Display(Name = "Person Name")]
        public String PersonName { get; set; }
        [Display(Name = "Table Name")]
        public String TableName { get; set; }
    }
    public class ReservationEntryModel : ReservationViewModel
    {
        [Display(Name = "Person List")]
        public List<SelectListItem> PersonList { get; set; }
        [Display(Name = "Table List")]
        public List<SelectListItem> TableList { get; set; }
        [Display(Name = "Party Size")]
        public List<SelectListItem> PartySizeList { get; set; }
    }
}