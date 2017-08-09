//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventoryManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Quote
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quote()
        {
            this.QuoteLines = new HashSet<QuoteLine>();
        }
    
        public int QuoteID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> VendorID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<double> TotalCost { get; set; }
        public Nullable<int> OrderID { get; set; }
        public string QuoteName { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual Vendor Vendor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuoteLine> QuoteLines { get; set; }
    }
}
