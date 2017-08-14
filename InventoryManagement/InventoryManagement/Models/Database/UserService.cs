using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models.Database
{
    public class UserService
    {
        public static InventoryDBEntities db = new InventoryDBEntities();

        public static string GetUserId(User user)
        {
            return db.Users.Where(x => (x.Username == user.Username && x.Password == user.Password)).Select(c => c.Username).First();

        }

        public static User GetUser(string username)
        {
            return db.Users.Where(x => x.Username == username).First();

        }

        public static bool ValidateUserCredentials(User user)
        {
            var isValid = db.Users.Where(x => (x.Username == user.Username && x.Password == user.Password)).ToList();

            if (isValid.Count() > 0)
            {
                return (true);
            }

            return (false);
        }

        public static bool ValidateUsername(User user)
        {
            var isValid = db.Users.Where(x => x.Username == user.Username);

            if (isValid.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}