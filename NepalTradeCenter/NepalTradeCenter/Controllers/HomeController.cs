using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NepalTradeCenter.NepalTradeCenterWCFProduct;
using NepalTradeCenter.NepalTradeCenterWCFCategory;
using System.IO;

namespace NepalTradeCenter.Controllers
{
    public class HomeController : Controller
    {
        ProductServiceClient productServiceClient = new ProductServiceClient();
        CategoryServiceClient categoryServiceClient = new CategoryServiceClient();
        const string productUploadAddress = "~/Content/upload/product/";
        //const string productDatabaseAddress = "Content/upload/product/";
        const string defaultImageAddress = "~/Content/upload/product/default.jpg";

        public ActionResult Index()
        {
            ViewBag.productList = productServiceClient.getLastNProduct();
            ViewBag.defaultImageAddress = defaultImageAddress;

            ViewBag.categoryList = categoryServiceClient.getAllCategory();

            return View();
        }

        public ActionResult addCategory()
        {
            ViewBag.categoryList = categoryServiceClient.getAllCategory();
            return View();
        }

        [HttpPost]
        [ActionName("addCategory")]
        public ActionResult addCategoryPost()
        {
            string name;
            int selectParent;
            int parent;
            NepalTradeCenterWCFCategory.Category category = new NepalTradeCenterWCFCategory.Category();

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

            categoryServiceClient.insertCategory(category);

            ViewBag.categoryList = categoryServiceClient.getAllCategory();
            return View();
        }

        public ActionResult addProduct()
        {
            ViewBag.categoryList = categoryServiceClient.getAllCategory();
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

                NepalTradeCenterWCFProduct.Product product = new NepalTradeCenterWCFProduct.Product();
                product.name = name;
                product.productCode = code;
                product.quantity = quantity;
                product.cost = cost;
                product.sellingPrice = sellingPrice;
                product.categoryId = category;
                product.productCreated = DateCreated;

                int productId = productServiceClient.insertProduct(product);

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
                        if (productServiceClient.updateProduct(productId, imageAddress) > 0)
                            file.SaveAs(path);
                    }
                }
            }

            ViewBag.categoryList = categoryServiceClient.getAllCategory();
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

        public ActionResult categoryBasedProduct(int categoryId)
        {
            System.Diagnostics.Debug.WriteLine("category Id: " + categoryId);
            ViewBag.productList = categoryServiceClient.getProductListByCategoryId(categoryId);
            ViewBag.defaultImageAddress = defaultImageAddress;

            ViewBag.categoryList = categoryServiceClient.getAllCategory();

            return View("categoryBasedProduct");
        }

    }
}