using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryManagement.Models;
using InventoryManagement.Models.Database;

namespace InventoryManagement.Controllers
{
    public class UserController : Controller
    {
        private InventoryDBEntities db = new InventoryDBEntities();


        // Get: Login

        public ActionResult Index(User user)
        {

            if (user.Username == null)
            {
                ModelState.Clear();
                return View();
            }

            // If user exists
            if (UserService.ValidateUsername(user))
            {
                // If Credentials are valide
                if (UserService.ValidateUserCredentials(user))
                {


                    //Redirects to Vendor Page by default
                    return RedirectToAction("Index", "Vendor");
                }
                else
                {
                    // Redirect to same Login page
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return RedirectToAction("Signup");
            }
        }


    }
}
