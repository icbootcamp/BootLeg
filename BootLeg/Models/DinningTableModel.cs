using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BootLeg.Models.Dinningtable

{
    //Creating a class for base table
    public class DinningTableModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Table Name")]
        public string TableName { get; set; }
        [Display(Name = "No. of Seats")]
        public int Seats { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }

        public DinningTableModel() { }

        public DinningTableModel(int id, string tableName, int seats, string desc = null)
        {
            this.Id = id;
            this.Seats = seats;
            this.TableName = tableName;
            this.Description = desc;
        }
    }
}