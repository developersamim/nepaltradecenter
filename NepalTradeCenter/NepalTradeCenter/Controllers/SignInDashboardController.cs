using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NepalTradeCenter.NepalTradeCenterServiceReference;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NepalTradeCenter.ServiceLayer;

namespace NepalTradeCenter.Controllers
{
    public class SignInDashboardController : Controller
    {
        AuthenticationRESTService authenticationRESTService = new AuthenticationRESTService();

        // GET: SignInDashboard
        public ActionResult Index()
        {           
            
            ViewBag.status = "";
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost()
        {
            string username;
            string password;
            username = Request.Form["username"].Trim();
            password = Request.Form["password"].Trim();
            System.Diagnostics.Debug.WriteLine("username: " + username + ", password: " + password);

            NepalTradeCenter.Models.User user = authenticationRESTService.authenticate(username, password);

            if (user == null)
            {
                ViewBag.status = "Username or Password do not match";
                return View();
            }
            else
            {
                Session["user"] = user.username;
                return RedirectToAction("Index", "Dashboard");
            }
            
        }

    }
}