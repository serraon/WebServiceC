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
    }
}