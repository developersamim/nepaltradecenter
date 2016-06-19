using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NepalTradeCenter.DAL;
using NepalTradeCenter.ViewModels;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NepalTradeCenter.Controllers
{
    public class ProductController : Controller
    {

        const string productUploadAddress = "~/Content/upload/product/";
        const string defaultImageAddress = "~/Content/upload/product/default.jpg";
        // GET: Product
        public ActionResult Index()
        {
            ProductListViewModel productListViewModel = new ProductListViewModel();
            productListViewModel.setProductList();

            return View(productListViewModel);
        }

        public ActionResult addProduct()
        {
            AddProductViewModel addProductViewModel = new AddProductViewModel();
            addProductViewModel.setCategoryList();

            return View(addProductViewModel);
        }

        [HttpPost]
        [ActionName("addProduct")]
        public ActionResult addProductPost()
        {
            ProductDAL productDAL = new ProductDAL();


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

            int productId = productDAL.insertProduct(product);

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
                    if (productDAL.updateProduct(productId, imageAddress) > 0)
                        file.SaveAs(path);
                }
            }

            return RedirectToAction("Index", "Product");
        }
        private DateTime? dateCreated;
        public DateTime DateCreated
        {
            get { return dateCreated ?? DateTime.Now; }
            set { dateCreated = value; }
        }
    }

    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void IndexProductControllerTest()
        {
            // Arrange
            ProductController productController = new ProductController();

            // Act
            var result = productController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }

}