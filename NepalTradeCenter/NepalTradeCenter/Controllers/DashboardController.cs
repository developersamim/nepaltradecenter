using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NepalTradeCenter.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            if (Session["user"] == null)
                return RedirectToAction("Index", "SignInDashboard");
            return View();
        }
    }

    [TestClass]
    public class DashboardControllerTest
    {
        //[TestMethod]
        //public void IndexDashboardTest()
        //{
        //    // Arrange
        //    DashboardController dashboardController = new DashboardController();

        //    // Act
        //    ViewResult result = dashboardController.Index() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void Index()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();

        //    // Act
        //    ViewResult result = controller.Index() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}
    }
}