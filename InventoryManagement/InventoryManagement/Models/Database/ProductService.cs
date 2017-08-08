using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models.Database
{
    public class ProductService
    {
        private static InventoryDBEntities db = new InventoryDBEntities();

        public static List<Product> GetProducts()
        {
            return db.Products.OrderBy(x => x.Name).ToList();
        }

        public static Product GetProductById(int id)
        {
            return db.Products.Find(id);
        }

        public static void EditProduct(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}