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
    
    public partial class Promotion
    {
        public string ProMID { get; set; }
        public string ProMName { get; set; }
        public string Form { get; set; }
        public Nullable<int> SoGiam { get; set; }
        public bool Status { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> StopDate { get; set; }
        public string Apply { get; set; }
        public bool ShowMenu { get; set; }
        public string Type { get; set; }
    }
}
