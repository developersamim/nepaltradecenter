using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NepalTradeCenter.NepalTradeCenterServiceReference;
using System.IO;
using NepalTradeCenter.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NepalTradeCenter.Controllers
{
    public class HomeController : Controller
    {
        NepalTradeCenterServiceClient nepalTradeCenterServiceClient = new NepalTradeCenterServiceClient();
        const string productUploadAddress = "~/Content/upload/product/";
        //const string productDatabaseAddress = "Content/upload/product/";
        const string defaultImageAddress = "~/Content/upload/product/default.jpg";

        public ActionResult Index()
        {
            ViewBag.defaultImageAddress = defaultImageAddress;

            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.setCategoryList();
            homeViewModel.setProductList();

            return View(homeViewModel);
        }

        public ActionResult categoryBasedProduct(int categoryId)
        {
            System.Diagnostics.Debug.WriteLine("category Id: " + categoryId);

            //ViewBag.productList = nepalTradeCenterServiceClient.getProductListByCategoryId(categoryId);
            ViewBag.defaultImageAddress = defaultImageAddress;

            //ViewBag.categoryList = nepalTradeCenterServiceClient.getAllCategory();

            CategoryBasedProductViewModel categoryBasedProductViewModel = new CategoryBasedProductViewModel();
            categoryBasedProductViewModel.setProductList(categoryId);
            categoryBasedProductViewModel.setCategoryList();

            return View(categoryBasedProductViewModel);
        }

        public ActionResult addCategory()
        {
            ViewBag.categoryList = nepalTradeCenterServiceClient.getAllCategory();
            return View();
        }

        [HttpPost]
        [ActionName("addCategory")]
        public ActionResult addCategoryPost()
        {
            string name;
            int selectParent;
            int parent;
            NepalTradeCenterServiceReference.Category category = new NepalTradeCenterServiceReference.Category();

            name = Request.Form["name"];
            selectParent = Convert.ToInt32(Request.Form["selectParent"]);
            System.Diagnostics.Debug.WriteLine("name: " + name + ", selectParent: " + selectParent);

            if(Request.Form["parent"].Trim() != "")
            {
                parent = Convert.ToInt32(Request.Form["parent"].Trim());
                category.parent = parent;
            }
            

            category.name = name;
            category.created = DateCreated;

            nepalTradeCenterServiceClient.insertCategory(category);

            ViewBag.categoryList = nepalTradeCenterServiceClient.getAllCategory();
            return View();
        }

        public ActionResult addProduct()
        {
            ViewBag.categoryList = nepalTradeCenterServiceClient.getAllCategory();
            return View();
        }

        [HttpPost]
        [ActionName("addProduct")]
        public ActionResult addProductPost()
        {
            if (ModelState.IsValid)
            {
                string name;
                string code;
                int quantity;
                decimal cost;
                decimal sellingPrice;
                int category;

                name = Request.Form["name"];
                code = Request.Form["code"];
                quantity = Convert.ToInt32(Request.Form["quantity"]);
                cost = Convert.ToDecimal(Request.Form["cost"]);
                sellingPrice = Convert.ToDecimal(Request.Form["sellingPrice"]);
                category = Convert.ToInt32(Request.Form["category"]);

                NepalTradeCenterServiceReference.Product product = new NepalTradeCenterServiceReference.Product();
                product.name = name;
                product.productCode = code;
                product.quantity = quantity;
                product.cost = cost;
                product.sellingPrice = sellingPrice;
                product.categoryId = category;
                product.productCreated = DateCreated;

                int productId = nepalTradeCenterServiceClient.insertProduct(product);

                System.Diagnostics.Debug.WriteLine("Name: " + name + ", code: " + code + ", quantity: " + quantity + ", cost: " + cost + ", sp: " + sellingPrice);

                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];
                    if (file != null && file.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(file.FileName);
                        var extension = Path.GetExtension(file.FileName);
                        var path = Path.Combine(Server.MapPath(productUploadAddress), productId + extension);
                        string imageAddress = productUploadAddress + productId + extension;
                        //System.Diagnostics.Debug.WriteLine("Path: " + path);
                        if (nepalTradeCenterServiceClient.updateProduct(productId, imageAddress) > 0)
                            file.SaveAs(path);
                    }
                }
            }
            ViewBag.categoryList = nepalTradeCenterServiceClient.getAllCategory();
            return View();
            
        }
        private DateTime? dateCreated;
        public DateTime DateCreated
        {
            get { return dateCreated ?? DateTime.Now; }
            set { dateCreated = value; }
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

    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}