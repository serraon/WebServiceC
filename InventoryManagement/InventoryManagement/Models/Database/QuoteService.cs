using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models.Database
{
    public class QuoteService
    {
        private static InventoryDBEntities db = new InventoryDBEntities();

        public static List<Quote> GetQuotes()
        {
            return db.Quotes.OrderBy(x => x.OrderID).ToList();
        }

        public static Quote GetQuoteByName(string quotename)
        {
            return db.Quotes.Where(x => x.QuoteName == quotename).First();
        }

        public static void AddQuote(Quote quote)
        {
            db.Quotes.Add(quote);
            db.SaveChanges();
        }

        public static List<string> GetVendorType()
        {
            return db.Vendors.Select(p => p.VendorType).Distinct().ToList();
        }

        public static Quote GetQuoteById(int quoteid)
        {
            return db.Quotes.Where(c => c.QuoteID == quoteid).First();
        }


        public static Vendor GetVendorByQuoteId(int quoteid)
        {
            Quote quote = GetQuoteById(quoteid);
            return db.Vendors.Where(c => c.VendorID == quote.VendorID).First();
        }

        public static Contact GetContactByVendorId(int vendorid)
        {
            return db.Contacts.Where(x => x.VendorID == vendorid).First();

        }
    }
}