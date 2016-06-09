using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NepalTradeCenter.NepalTradeCenterWCFProduct;

namespace NepalTradeCenter.Controllers
{
    public class HomeController : Controller
    {
        ProductServiceClient productServiceClient = new ProductServiceClient();

        public ActionResult Index()
        {
            //productServiceClient.insertProduct();
            int productId = 1;

            Product myProduct = productServiceClient.getProductById(productId);

            ViewBag.myProduct = myProduct;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}