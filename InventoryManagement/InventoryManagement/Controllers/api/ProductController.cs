using InventoryManagement.Models;
using InventoryManagement.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace InventoryManagement.Controllers.Api
{
    public class ProductController : ApiController
    {
        [System.Web.Http.HttpGet]
        public IEnumerable<string> GetProductType()
        {
            return ProductService.GetProducts().Select(y => y.Type);
        }
    }
}