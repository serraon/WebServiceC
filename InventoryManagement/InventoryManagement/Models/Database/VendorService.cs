using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models.Database
{
    public class VendorService
    {
        private static InventoryDBEntities db = new InventoryDBEntities();

        public static List<Vendor> GetVendors()
        {
            return db.Vendors.OrderBy(x => x.CompanyName).ToList();
        }
    }
}