using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NepalTradeCenterWebAPI.Models
{
    public class Authentication
    {
        public string username { get; set; }
        public string password { get; set; }
        User user = null;

        public User authenticateUser(string username, string password)
        {
            this.username = username;
            this.password = password;

            using (var myContext = new MyContext())
            {
                var linqQuery = myContext.Users.Where(s => s.username == username && s.password == password);
                user = linqQuery.FirstOrDefault<User>();
            }

            return user;
        }
    }
}