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
    
    public partial class Products_for_lists
    {
        public int Product_Code { get; set; }
        public int Product_code_for_the_list_ { get; set; }
        public Nullable<int> Kod_List { get; set; }
    
        public virtual Products Products { get; set; }
        public virtual Reserved_lists Reserved_lists { get; set; }
    }
}
