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
    
    public partial class Menu
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public string Target { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<int> TypeId { get; set; }
    }
}