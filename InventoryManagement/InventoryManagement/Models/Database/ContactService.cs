using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models.Database
{
    public class ContactService
    {
        private static InventoryDBEntities db = new InventoryDBEntities();

        public static Contact GetFirstContact(int vendorid)
        {
            return db.Contacts.Where(x => x.VendorID == vendorid).First();
        }

        public static List<Contact> GetContacts()
        {
            return db.Contacts.OrderBy(x => x.ContactID).ToList();
        }

        public static List<Contact> GetContactsPerVendor(Vendor vendor)
        {
            return db.Contacts.Where(x => x.VendorID == vendor.VendorID).ToList();
        }
    }
}