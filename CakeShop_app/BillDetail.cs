//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CakeShop_app
{
    using System;
    using System.Collections.Generic;
    
    public partial class BillDetail
    {
        public int CakeID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> Totality { get; set; }
        public int IDBill { get; set; }
    
        public virtual Bill Bill { get; set; }
        public virtual Cake Cake { get; set; }
    }
}
