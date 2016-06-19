using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NepalTradeCenter.ViewModels;
using NepalTradeCenter.DAL;

namespace NepalTradeCenter.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            CategoryListViewModel categoryListViewModel = new CategoryListViewModel();
            categoryListViewModel.setCategoryList();
            return View(categoryListViewModel);
        }

        public ActionResult addCategory()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();
            addCategoryViewModel.setCategoryList();
            return View(addCategoryViewModel);
        }

        [HttpPost]
        [ActionName("addCategory")]
        public ActionResult addCategoryPost()
        {
            CategoryDAL categoryDAL = new CategoryDAL();
            string name;
            int selectParent;
            int parent;
            NepalTradeCenterServiceReference.Category category = new NepalTradeCenterServiceReference.Category();

            name = Request.Form["name"];
            selectParent = Convert.ToInt32(Request.Form["selectParent"]);
            System.Diagnostics.Debug.WriteLine("name: " + name + ", selectParent: " + selectParent);

            if (Request.Form["parent"].Trim() != "")
            {
                parent = Convert.ToInt32(Request.Form["parent"].Trim());
                category.parent = parent;
            }


            category.name = name;
            category.created = DateCreated;

            categoryDAL.insertCategory(category);

            return RedirectToAction("Index", "Category");
        }

        private DateTime? dateCreated;
        public DateTime DateCreated
        {
            get { return dateCreated ?? DateTime.Now; }
            set { dateCreated = value; }
        }
    }
}