using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NepalTradeCenterWebAPI.Models;
using Newtonsoft.Json.Linq;

namespace NepalTradeCenterWebAPI.Controllers
{
    public class AuthenticationController : ApiController
    {
        public User Post(TempUser tempUser)
        {
            Authentication authentication = new Authentication();
            return authentication.authenticateUser(tempUser.username, tempUser.password);
        }
    }

    public class TempUser
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
