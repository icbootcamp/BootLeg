//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BootLeg
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReservationOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ReservationId { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
