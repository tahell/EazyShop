//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Products
    {
        public int Product_Code { get; set; }
        public string product_name { get; set; }
        public int Kod_Category { get; set; }
        public int Location_Code { get; set; }
        public double Price { get; set; }
        public int Kod_Column { get; set; }
        public int Shelf_number { get; set; }
    
        public virtual Columns Columns { get; set; }
        public virtual Department Department { get; set; }
        public virtual Location Location { get; set; }
        public virtual Products_for_lists Products_for_lists { get; set; }
    }
}
