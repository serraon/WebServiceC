using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models.ViewModel
{
    public class VendorContactViewModel
    {
        public Vendor Vendor { get; set; }
        public List<Contact> Contacts { get; set; }
        public Contact Contact { get; set; }


    }
}