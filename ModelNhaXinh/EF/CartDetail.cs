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
    
    public partial class CartDetail
    {
        public string ProID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> MoneyTotal { get; set; }
    
        public virtual Product Product { get; set; }
    }
}