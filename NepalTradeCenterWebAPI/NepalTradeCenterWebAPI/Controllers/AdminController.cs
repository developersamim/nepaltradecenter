using NepalTradeCenterWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NepalTradeCenterWebAPI.Controllers
{
    public class AdminController : ApiController
    {
        // GET api/User
        public IEnumerable<Admin> Get()
        {
            List<Admin> userList = new List<Models.Admin>();
            Admin user1 = new Admin();
            user1.userId = 1;
            user1.username = "admin";
            user1.password = "admin";
            user1.firstname = "admin";

            Admin user2 = new Admin();
            user2.userId = 2;
            user2.username = "admin2";
            user2.password = "admin2";

            Admin user3 = new Admin();
            user3.userId = 3;
            user3.username = "admin3";
            user3.password = "admin3";

            userList.Add(user1);
            userList.Add(user2);
            userList.Add(user3);

            return userList;
        }

    }
}
