using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootLeg.Models

{
    //Creating a class for base table
    public class TableModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Table Name")]
        public string TableName { get; set; }
        [Display(Name = "No. of Seats")]
        public int Seats { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
    public class TableEntryModel : TableModel
    {
        [Display(Name = "OpinSeats")]
        public List<SelectListItem> OpinSeats { get; set; }
    }
}