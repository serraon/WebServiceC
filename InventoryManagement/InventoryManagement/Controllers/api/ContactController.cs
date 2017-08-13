using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using InventoryManagement.Models;
using InventoryManagement.Models.Database;
using System.Web.Http;

namespace InventoryManagement.Controllers.Api
{
    public class ContactController : ApiController
    {
        [HttpGet]
        public Contact GetVendorContact(int vendorid)
        {
            return ContactService.GetFirstContact(vendorid);
        }
    }
}
