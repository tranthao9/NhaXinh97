//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelNhaXinh.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Price
    {
        public string PriID { get; set; }
        public string ProID { get; set; }
        public Nullable<int> Cost { get; set; }
        public Nullable<int> PreCost { get; set; }
        public Nullable<System.DateTime> StartedDate { get; set; }
        public Nullable<System.DateTime> StopedDate { get; set; }
        public bool Status { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
