using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NepalTradeCenter.Controllers
{
    public class SignOutController : Controller
    {
        // GET: SignOut
        public ActionResult Index()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "SignInDashboard");
        }
    }

    [TestClass]
    public class SignOutControllerTest
    {
        //[TestMethod]
        //public void IndexSignOutController()
        //{
        //    // Arrange
        //    SignOutController signOutController = new SignOutController();

        //    // Act
        //    var result = signOutController.Index() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}
    }
}