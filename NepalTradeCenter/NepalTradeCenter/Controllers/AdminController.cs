using NepalTradeCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using NepalTradeCenter.ServiceLayer;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Schema;

namespace NepalTradeCenter.Controllers
{
    public class AdminController : Controller
    {
        // GET: User
        public JsonResult Index()
        {
            AdminRESTService usersRESTService = new AdminRESTService();
            string jsonResponse = usersRESTService.getAllUser();
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
            //List<User> userList = new List<User>();

            //var items = JsonConvert.DeserializeObject<List<User>>(jsonResponse);
            
        }
    }
}