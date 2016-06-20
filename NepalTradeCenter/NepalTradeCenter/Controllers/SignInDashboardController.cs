using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NepalTradeCenter.NepalTradeCenterServiceReference;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NepalTradeCenter.Controllers
{
    public class SignInDashboardController : Controller
    {
        NepalTradeCenterServiceClient nepalTradeCenterServiceClient = new NepalTradeCenterServiceClient();

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

            NepalTradeCenterServiceReference.User user = nepalTradeCenterServiceClient.authentiateUser(username, password);

            if(user == null)
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

    [TestClass]
    public class SignInDashboardControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            SignInDashboardController signInDashboardController = new SignInDashboardController();

            // Act
            var result = signInDashboardController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void authenticationTest()
        {
            // Arrange
            string username;
            string password;
            NepalTradeCenterServiceClient client;
            NepalTradeCenterServiceReference.User user;

            // Act
            username = "admin";
            password = "P@ssw0rd";
            client = new NepalTradeCenterServiceClient();
            user = new NepalTradeCenterServiceReference.User();
            user = client.authentiateUser(username, password);

            // Assert
            Assert.IsNotNull(user);
        }
        [TestMethod]
        public void authenticationTest1()
        {
            // Arrange
            string username;
            string password;
            NepalTradeCenterServiceClient client;
            NepalTradeCenterServiceReference.User user;

            // Act
            username = "admin";
            password = "wrong password";
            client = new NepalTradeCenterServiceClient();
            user = new NepalTradeCenterServiceReference.User();
            user = client.authentiateUser(username, password);

            // Assert
            Assert.IsNull(user);
        }


    }
}