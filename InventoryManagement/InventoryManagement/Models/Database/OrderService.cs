using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models.Database
{
    public class OrderService
    {
        private static InventoryDBEntities db = new InventoryDBEntities();

        public static List<Order> GetOrders()
        {
            return db.Orders.OrderBy(x => x.OrderID).ToList();
        }
    }
}