//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BangbooMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inventory
    {
        public int ID_Inventory { get; set; }
        public int Bangboo_ID { get; set; }
        public int Quantity { get; set; }
        public Nullable<System.DateTime> LastRestockDate { get; set; }
    
        public virtual Bangboo Bangboo { get; set; }
    }
}
