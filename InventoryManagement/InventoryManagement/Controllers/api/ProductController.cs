using InventoryManagement.Models;
using InventoryManagement.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace InventoryManagement.Controllers.Api
{
    public class ProductController : ApiController
    {
        [HttpGet]
        public List<string> GetProductType()
        {
            return ProductService.GetProducts().Select(y => y.Type).Distinct().ToList();
        }
    }
}