//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp4
{
    using System;
    using System.Collections.Generic;
    
    public partial class MaterialCountHistory
    {
        public int ID { get; set; }
        public int MaterialID { get; set; }
        public System.DateTime ChangeDate { get; set; }
        public double CountValue { get; set; }
    
        public virtual Material Material { get; set; }
    }
}
