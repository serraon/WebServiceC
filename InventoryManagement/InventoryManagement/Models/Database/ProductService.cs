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
            db.Products.FirstOrDefault(c => c.ProductID == product.ProductID).Name = product.Name;
            db.Products.FirstOrDefault(c => c.ProductID == product.ProductID).Type = product.Type;
            db.Products.FirstOrDefault(c => c.ProductID == product.ProductID).Units = product.Units;
            db.SaveChanges();
        }

        public static void AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public static void DeleteProductById(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }
    }
}