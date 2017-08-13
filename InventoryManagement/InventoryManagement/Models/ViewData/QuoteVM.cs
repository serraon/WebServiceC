using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models.ViewData
{
    public class QuoteVM
    {
        public Quote Quote { get; set; }
        public Vendor Vendor { get; set; }
        public int ProductID { get; set; }
        public List<string> VendorType {get; set; }
        
    }
}